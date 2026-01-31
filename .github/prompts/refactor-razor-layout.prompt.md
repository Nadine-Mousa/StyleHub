---
description: "Refactor a large Razor view into partials/components"
---

You are helping refactor a large Razor view into better-structured components.

### Task:
- Inspect the attached `.cshtml` file.
- Identify logical sections that can become:
  - Partial views
  - View components
  - Tag Helpers (if appropriate)
- Propose a new structure (what to extract and how to name it).
- Then rewrite the original view to use the new partials/components.
- Ensure existing model binding and validation still work.
- Do not introduce new frameworks or dependencies beyond what is already used in the project.
- Prefer reusable components over one-off partials.