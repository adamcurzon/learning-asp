# Learning-ASP 📚

A basic API written in ASP.net / C# for managing cars in a dealership. 🚗💨


## ✅ Current functionality

### Public
- `POST /api/User/` 🔐 Login & get JWT token
- `GET /api/Car/All` Gets all cars
- `GET /api/Car/{guid}` Gets a single car by guid

### Authorize
- `DELETE /api/Car/{guid}` Deletes a single car by guid
- `POST /api/Car/` Creates a car

#### Seed User Credentials
✉️ Email: `adam@example.com`

🔑 Password: `password`

## ⚙️ Setup

### 📂 Setting up MySQL
1. In `appsettings.json` edit the DefaultConnection to be the credentials for your mysql server.

2. In the `nuget package manager console` run the following commands to create a migration and publish it to the database.
    ```
    Add-Migration Initial
    Update-Database
    ```

### 🔐 Setting up JWTs
1. In `appsettings.json` ensure the issuer & audience matches production details.

2. Ensure a secure secret key is added that is 16 characters or longer.

3. TODO: In production these will nee to be moved somewhere more secure.

## 📚 Tutorial followed:

👨 [General ASP](https://www.youtube.com/playlist?list=PL3ewn8T-zRWgO-GAdXjVRh-6thRog6ddg)

🔐 [JWT](https://www.youtube.com/watch?v=4cFhYUK8wnc)

🤔 [JWT Issues](https://www.reddit.com/r/dotnet/comments/11dekla/jwt_token_not_being_authorized_by_authorize/)

💿 [EF Core](https://www.youtube.com/watch?v=39rSVOScx9c)

🤐 [BCrypt](https://www.youtube.com/watch?v=UwruwHl3BlU)