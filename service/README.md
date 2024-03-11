# service

- Set enviroment variables

```bash

export TOKEN_ACCESS_TOKEN_EXPIRATION=10000
export TOKEN_SECURITY_KEY="Erxkqb9amTxauDvpr"
export TOKEN_ISSUER="www.berk.com"
export TOKEN_AUDIENCE="www.berk.com"

export MAIL_ACCOUNT="berkslv@gmail.com"
export MAIL_HOST="smtp.sendinblue.com" 
export MAIL_USERNAME="berkslv"
export MAIL_PASSWORD="password"

export CONNECTION_STRING="server=localhost;user=root;password=12345678;database=hub"

```

- Run this project

```bash

dotnet watch run --project ./Service --launch-profile "Development"

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