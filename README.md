# Minimalistic Facebook Clone

This API was developed using .Net and Monolithic architecture, taking as an example the structure of Facebook in its early days, which was only open to university students.

The project is open to university students who are affiliated with universities, faculties and departments in Turkey and have a university e-mail address. In addition, business and admin users are also available.


# Development

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

# Documentation

OpenApi V3 documentation is available on [APItree](https://hub.apitree.com/berkslv/minimalistic-facebook-clone/) and source code contains as many comments as possible.

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

# Admin panel

It's available through the [./admin](./admin/) directory. Currently, only users with Admin role can use it.