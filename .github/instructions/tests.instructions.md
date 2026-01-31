---
applyTo: "**/*Tests.cs"
---

These instructions apply to test files in the project.

### Testing Guidelines:
- Use xUnit for unit/integration tests.
- Use FluentAssertions for readable assertions.
- Name tests using `MethodName_State_ExpectedBehavior` convention.
- Each test should have one assertion (unless testing multiple related outcomes).
- Mock dependencies using Moq — do not instantiate real services.
- Use `[Fact]` for simple cases, `[Theory]` with `[InlineData]` for parameterized tests.
- Always dispose resources (like `Mock<...>`, `MemoryStream`, etc.) if needed.
- Avoid `async void` — all test methods must return `Task`.
- Use `Assert.ThrowsAsync<...>` for testing exceptions in async code.
- Don’t use `Thread.Sleep` — use `Task.Delay` or test-specific time providers.