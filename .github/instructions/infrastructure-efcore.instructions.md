---
applyTo: "src/Infrastructure/**/*.cs"
---

These instructions apply to the layer using EF Core.

### EF Core Guidelines:
- Use `AsNoTracking()` for read-only queries.
- Prefer async methods (e.g., `ToListAsync()`, `FirstOrDefaultAsync()`) with `CancellationToken`.
- Do not expose `DbContext` directly to the Presentation layer; use repositories or query services.
- Avoid N+1 queries; use `Include` / `ThenInclude` judiciously.
- For transactional operations, prefer `IDbContextTransaction` or application-level units of work.
- Avoid putting domain logic in the Infrastructure layer; keep it in Domain/Application.
- Use `ValueConverter<T>` for complex value objects when mapping to DB.
- Never call `.SaveChanges()` inside a repository without explicit transaction control.