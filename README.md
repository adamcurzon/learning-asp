# Learning-ASP 📚

A basic API written in ASP.net/C# for managing cars from a dealership.

### Tutorial followed:

👨 [General ASP](https://www.youtube.com/playlist?list=PL3ewn8T-zRWgO-GAdXjVRh-6thRog6ddg)

🔐 [JWT](https://www.youtube.com/watch?v=mgeuh8k3I4g)

💿 [EF Core](https://www.youtube.com/watch?v=39rSVOScx9c)

## Setting up MySQL
1. In `appsettings.json` edit the DefaultConnection to be the credentials for your mysql server.

2. In the `nuget package manager console` run the following commands to create a migration and publish it to the database.
    ```
    Add-Migration Initial
    Update-Database
    ```
3. Get filthy rich through selling cars 🚗💨 