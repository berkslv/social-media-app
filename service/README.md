# service

- Run this project

```bash

dotnet watch run --project ./Service

```

- Ef core scripts

```bash

dotnet ef database drop --project ./DataAccess
dotnet ef migrations remove --project ./DataAccess
dotnet ef migrations add InitalCreate --project ./DataAccess
dotnet ef database update --project ./DataAccess

```

# Services

Currently, there are 9 main services, these are as follows:

- [Auth](./service/Service/Controllers/AuthController.cs)
- [User](./service/Service/Controllers/UserController.cs)
- [University](./service/Service/Controllers(Controllers/UniversityController.cs))
- [Faculty](./service/Service/Controllers/FacultyController.cs)
- [Department](./service/Service/Controllers/DepartmentController.cs)
- [Department Code](./service/Service/Controllers/DepartmentCodeController.cs)
- [Tag](./service/Service/Controllers/TagController.cs)
- [Post](./service/Service/Controllers/TagController.cs)
- [Comment](./service/Service/Controllers/CommentController.cs)