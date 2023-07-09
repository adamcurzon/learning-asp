# Learning-ASP 📚

A basic API written in ASP.net/C# for managing cars from a dealership.

### Tutorial followed:

👨 [General ASP](https://www.youtube.com/playlist?list=PL3ewn8T-zRWgO-GAdXjVRh-6thRog6ddg)

🔐 [JWT](https://www.youtube.com/watch?v=4cFhYUK8wnc)

🤔 [JWT Issues](https://www.reddit.com/r/dotnet/comments/11dekla/jwt_token_not_being_authorized_by_authorize/)

💿 [EF Core](https://www.youtube.com/watch?v=39rSVOScx9c)

## 📂 Setting up MySQL
1. In `appsettings.json` edit the DefaultConnection to be the credentials for your mysql server.

2. In the `nuget package manager console` run the following commands to create a migration and publish it to the database.
    ```
    Add-Migration Initial
    Update-Database
    ```
3. Get filthy rich through selling cars 🚗💨

## 🔐 Setting up JWTs
1. In `appsettings.json` ensure the issuer & audience matches production details.

2. Ensure a secure secret key is added that is 16 characters or longer.

3. TODO: In production these will nee to be moved somewhere more secure.