# Task Manager API

A **RESTful API** built with **ASP.NET Core** to manage tasks and todo lists. Demonstrates full-stack .NET development skills.

## Features

- ✅ **RESTful API Design** - Clean, documented endpoints
- ✅ **Entity Framework Core** - Database-first approach
- ✅ **CRUD Operations** - Create, Read, Update, Delete
- ✅ **SQL Server** - Relational database
- ✅ **Swagger UI** - Interactive API documentation
- ✅ **Clean Architecture** - Separation of concerns

## Tech Stack

- **Backend:** ASP.NET Core 8.0, C#
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Documentation:** Swagger/OpenAPI

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks` | Get all tasks |
| GET | `/api/tasks/{id}` | Get task by ID |
| POST | `/api/tasks` | Create new task |
| PUT | `/api/tasks/{id}` | Update task |
| DELETE | `/api/tasks/{id}` | Delete task |

## Task Object

```json
{
  "id": 1,
  "title": "Learn .NET",
  "description": "Complete .NET tutorial",
  "priority": 3,
  "completed": true,
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": "2024-01-15T14:45:00Z"
}
```

## How to Run

1. Install dependencies:
   ```bash
   dotnet restore
   ```

2. Run migrations (if needed):
   ```bash
   dotnet ef database update
   ```

3. Build and run:
   ```bash
   dotnet build
   dotnet run
   ```

4. Open Swagger UI at: `https://localhost:7001/swagger`

## Example Requests

```bash
# Create a task
curl -X POST https://localhost:7001/api/tasks \
  -H "Content-Type: application/json" \
  -d '{
    "title": "New Task",
    "description": "Task description",
    "priority": 5
  }'

# Get all tasks
curl https://localhost:7001/api/tasks

# Get task by ID
curl https://localhost:7001/api/tasks/1

# Update a task
curl -X PUT https://localhost:7001/api/tasks/1 \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Updated Title",
    "description": "Updated description",
    "priority": 1,
    "completed": true
  }'

# Delete a task
curl -X DELETE https://localhost:7001/api/tasks/1
```

## Skills Demonstrated

- ✅ **ASP.NET Core** - Web API development
- ✅ **Entity Framework Core** - ORM and migrations
- ✅ **RESTful API Design** - Resource-oriented architecture
- ✅ **SQL Server** - Database design and queries
- ✅ **Clean Code** - Separation of concerns
- ✅ **API Documentation** - Swagger/OpenAPI

---

**Built by:** Mohammad Thiab  
**Location:** Ramallah, West Bank, Palestine  
**Available for:** Freelance projects, remote work

Let's build something amazing together! 🚀
