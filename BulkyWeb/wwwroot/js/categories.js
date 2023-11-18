
var dataTable;

$(document).ready(function () {
    LoadDataTable();
});


function LoadDataTable() {
    dataTable = $('#myTable').DataTable({
        ajax: {
            url: '/admin/category/getall'
        },
        columns: [

            { data: 'name', 'width' : '20%'},
            { data: 'displayOrder', 'width': '20%' },
            {
                data: 'id', 'render': function (data) {

                    return `<div>
                    <a href="/admin/category/edit?id=${data}" class="btn btn-outline-info">Edit</a>
                    <a onClick="Delete('/admin/category/delete?id=${data}')" class="btn btn-outline-danger">Delete</a>
                    </div>`
                }
            }
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
                
            })
        }
    })
}