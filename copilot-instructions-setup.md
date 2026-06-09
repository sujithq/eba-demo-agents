# Copilot Instructions Setup for .NET 10

Use this document as the baseline prompt/policy when configuring Copilot for .NET 10 projects.

## Core principles

- Prefer clear, maintainable code over clever code.
- Optimize only where profiling indicates a bottleneck.
- Default to secure-by-default patterns and least privilege.
- Keep architectural boundaries explicit and enforceable.

## Architecture guidance

- Use a layered or clean architecture with clear boundaries between API, application, domain, and infrastructure concerns.
- Keep domain logic independent of frameworks and transport layers.
- Use dependency injection for all infrastructure concerns; depend on abstractions, not implementations.
- Favor small, focused services and handlers with single responsibilities.
- Use asynchronous APIs end-to-end for I/O paths and always propagate `CancellationToken`.
- Keep DTOs separate from domain models; map explicitly.
- Design APIs for versioning and backward compatibility from day one.

## Performance guidance

- Prefer async/non-blocking I/O; avoid sync-over-async patterns.
- Reduce allocations in hot paths (avoid unnecessary LINQ/materialization, use pooling where beneficial).
- Use pagination/streaming for large result sets; avoid loading full datasets in memory.
- Use caching deliberately (in-memory/distributed) with explicit invalidation and TTL strategies.
- Use compiled queries or optimized data access patterns for high-frequency database calls.
- Avoid N+1 query patterns and fetch only required columns/fields.
- Add benchmarks for critical paths and validate changes with measurements.
- Enable trimming/AOT readiness where applicable and avoid reflection-heavy patterns unless required.

## Security guidance

- Never hardcode secrets; use secure secret providers and environment-based configuration.
- Enforce authentication and authorization on every sensitive endpoint.
- Validate all external input and fail safely with sanitized error responses.
- Use parameterized queries/ORM protections to prevent injection vulnerabilities.
- Encode/escape output for the target context to reduce XSS risks.
- Use HTTPS everywhere and secure cookie/token settings.
- Add rate limiting, request size limits, and anti-abuse protections for public endpoints.
- Keep dependencies updated and monitor vulnerability advisories.
- Log security-relevant events without leaking sensitive data.

## API and data design guidance

- Return consistent error contracts (e.g., Problem Details) and meaningful status codes.
- Make endpoints idempotent where appropriate and support retries safely.
- Use optimistic concurrency controls for mutable shared data.
- Define explicit validation rules close to request boundaries.
- Prefer UTC timestamps and stable, explicit serialization formats.

## Observability and operations guidance

- Use structured logging with correlation/trace IDs.
- Instrument with OpenTelemetry traces, metrics, and logs.
- Add health/readiness checks for runtime dependencies.
- Define SLO-aligned alerts with actionable runbooks.
- Ensure graceful shutdown and resilient startup behavior.

## Testing and quality guidance

- Require unit tests for domain/application logic and integration tests for infrastructure boundaries.
- Cover auth, validation, error handling, and edge cases.
- Add performance regression checks for critical endpoints.
- Enforce analyzers and treat critical warnings as build failures.

## Copilot behavior expectations

When Copilot generates .NET 10 code:

- Prefer idiomatic modern C# and ASP.NET Core patterns.
- Include cancellation, validation, and error-handling paths by default.
- Avoid introducing new dependencies unless clearly justified.
- Favor secure defaults and explicit configuration.
- Include tests for new behavior and risky changes.
- Document architectural or operational trade-offs in PR descriptions.
