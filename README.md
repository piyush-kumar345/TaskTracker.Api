# TaskTracker.Api

A REST API for managing tasks, built with ASP.NET Core on .NET 10.

## Tech stack
- C#, .NET 10
- ASP.NET Core Web API (controllers)

## How to run
1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download)
2. Clone the repo:
```
   git clone https://github.com/piyush-kumar345/TaskTracker.Api.git
```
3. Go into the project folder and run:
```
   dotnet run
```
4. Use the `TaskTracker.Api.http` file to test the endpoints.

## Endpoints (planned)
| Method | Route | Description |
|--------|-------|-------------|
| GET | /api/tasks | Get all tasks |
| GET | /api/tasks/{id} | Get one task |
| POST | /api/tasks | Create a task |
| PUT | /api/tasks/{id} | Update a task |
| DELETE | /api/tasks/{id} | Delete a task |

## Roadmap
- [x] Project setup
- [ ] CRUD endpoints with in-memory data
- [ ] DTOs and validation
- [ ] Service layer + dependency injection
- [ ] EF Core + SQL Server
- [ ] JWT authentication

## Author
Piyush, learning .NET Core + Angular full-stack. Building in public.