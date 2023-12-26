var dataTable;

$(document).ready(function () {
    LoadDataTable();
});


function LoadDataTable(){
    dataTable = $('#myTable').DataTable({
        ajax: {
            url: '/admin/product/getall',
        },
        columns: [
            { data: 'name' },
            { data: 'price' },
            { data: 'stock' },
            { data: "category.name" },         // Needs Solution
            { data: 'rate' },
            {
                data: 'id', 'render': function(data) {
                    return `<div>
                    <a href="/admin/product/upsert?id=${data}" class="btn btn-info">Edit</a>
                    <a onClick="Delete('/admin/product/delete?id=${data}')" class="btn btn-danger">Delete</a>
                </div>`
            }}

        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });

}