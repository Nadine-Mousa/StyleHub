---
description: "Generate unit tests for a given C# class using xUnit and FluentAssertions"
---

You are helping generate clean, maintainable unit tests for a C# class.

### Task:
- Inspect the attached `.cs` file.
- Identify public methods and their inputs/outputs.
- Generate tests that cover:
  - Happy path
  - Edge cases (null, empty, invalid input)
  - Exception cases (if applicable)
- Use xUnit `[Fact]` or `[Theory]` appropriately.
- Use FluentAssertions for assertions.
- Mock dependencies using Moq.
- Ensure tests are isolated and do not depend on external systems.
- Do not introduce new frameworks or dependencies beyond what is already used in the project.