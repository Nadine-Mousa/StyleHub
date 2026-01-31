---
applyTo: "**/*.cshtml"
---

These instructions apply to Razor views and components in an ASP.NET Core MVC app.

### Razor Guidelines:
- Keep business logic out of Razor files. Use view models and HTML/TagHelpers.
- Use `@model` for strongly-typed views, not `ViewBag` or `ViewData` for primary data.
- Prefer built-in tag helpers: `<form asp-action="...">`, `<input asp-for="...">`, `<label asp-for="...">`.
- Use `asp-validation-summary` and `asp-validation-for` for validation messages.
- Always HTML-encode user-visible content (Razor does this by default; avoid `@Html.Raw` unless absolutely necessary).
- Use partials or view components when a UI fragment is reused more than once.
- Keep Razor files focused: if a `.cshtml` file becomes too complex, suggest extracting partials or components.
- Prefer Bootstrap utility classes instead of inline `style` attributes for layout/styling.
- Use localization helpers (e.g., `IViewLocalizer` or `@Localizer["Key"]`) for user-facing strings where applicable.
- Never write JavaScript/CSS inline — always externalize.
- Use `@section` for scripts/styles that need to be included in specific views.
- Follow accessibility best practices: use semantic HTML, ARIA attributes, and ensure keyboard navigability.
- Comment complex Razor logic to explain intent.
- Use consistent indentation and spacing for readability.
- Name files clearly to reflect their purpose (e.g., `Edit.cshtml`, `Details.cshtml`).
- Avoid hardcoding URLs; use `asp-controller` and `asp-action` tag helpers for links and forms.
- Leverage layout pages (`_Layout.cshtml`) to maintain consistent structure across views.
- Use `@inject` to bring services into views when necessary, but keep service usage minimal.
- Make the ui pretty, attractive,and user friendly, and follow the theme of the application.
- Follow modern design principles, but avoid overuse of animations or effects that can distract from usability.