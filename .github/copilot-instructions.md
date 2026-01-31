You are helping maintain a professional ASP.NET Core solution that follows modern C# best practices.

### General Rules:
- Always prefer **explicit types** over `var`.
- All async methods must end with the suffix `Async`.
- Use `CancellationToken` for public async APIs and pass it through where possible.
- Treat nullable reference types as enabled; avoid `!` unless absolutely necessary.
- Do not swallow exceptions; either handle them meaningfully or let them bubble up.
- Prefer the Result pattern (`Result<T>`) over throwing exceptions for domain or validation failures.
- Use xUnit for tests and FluentAssertions for assertions when generating new tests.

### Formatting & Style:
- Follow standard C# conventions: PascalCase for types/methods, camelCase for locals/fields.
- Keep methods small and focused; if a method grows beyond ~30-40 lines, suggest refactoring.
- Use expression-bodied members when they improve readability, not just to be clever.

### Razor & UI (High Level):
- Keep business logic out of views; use view models and tag helpers instead of inline C# logic.
- Prefer built-in TagHelpers and HTML helpers over manual HTML when possible.
- Never write JavaScript/CSS inline in Razor files — use separate `.js` and `.css` files.
- Use `@inject` only for services needed in the view, and always dispose them if required.

### Testing:
- Write tests that are isolated, fast, and readable.
- Use `[Fact]` for simple cases, `[Theory]` with `[InlineData]` for parameterized tests.
- Mock dependencies using Moq or similar — don’t instantiate real services.