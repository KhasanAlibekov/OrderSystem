To set up and run the application, please follow these instructions:

1. Browser Installation:
   - Download Mozilla Firefox, Google Chrome, or Microsoft Edge browser from their official websites.
   - Install the browser of your choice by running the downloaded installer.

2. Visual Studio .NET 8 2022 Preview Installation:
   - Download Visual Studio .NET 8 2022 Preview from the official Microsoft website.
   - Run the downloaded installer and follow the installation instructions.
   - Make sure to select the necessary components for .NET development.

3. MS SQL 2022 Installation:
   - Download Microsoft SQL Server 2022 from the official Microsoft website.
   - Run the downloaded installer and follow the installation instructions.
   - Choose the appropriate options based on your requirements and set up a new SQL Server instance.

4. Project Download:
   - Download the project files from the source or repository where they are available.
   - Extract the downloaded project files to a directory of your choice.

5. Connection String Configuration:
   - Open the API project and MVC project in Visual Studio.
   - Locate the `appsettings.json` file in both projects.
   - Check the connection string configuration in both `appsettings.json` files.
   - Ensure that the connection string points to your SQL Server instance.

6. Update Connection String in `Program.cs`:
   - Open the `Program.cs` file in the API project.
   - Find the code that sets up the connection string.
   - Use the same connection string from the `appsettings.json` file.

7. Migrations using Terminal:
   - Open the terminal in Visual Studio (View -> Terminal).
   - Use the `ls` command to navigate to the correct location where the DataAccess project or class is located.
   - Change the directory using the `cd <name of the project or class with DataAccess>` command.
   - Use the `ls` command to verify that you are in the correct directory.
   - Perform migration by running the command `dotnet ef migrations add <Name>`.
   - If the migration is successful, update the database by running the command `dotnet ef database update`.

8. Migrations using Package Manager Console:
   - Open the Package Manager Console in Visual Studio (Tools -> NuGet Package Manager -> Package Manager Console).
   - In the Package Manager Console, execute the following commands:
     - `Add-Migration <NameOfMigration>` to add the migration.
     - `Update-Database` to update the database.

9. Run the Application:
   - Build the solution in Visual Studio to ensure all dependencies are resolved.
   - Start the application by running the API project or the MVC project (depending on your requirements).
   - Once the application is running, open your browser and navigate to the appropriate URL (usually localhost).
   - On the right corner, above the "Register" and "Login" links, you should see the user registration option.
   - Register as a user to become an automatically registered user.

10. Extra Steps to Become an Admin:
   - Go to "Ordersystem.Web" -> "Views" -> "Shared" -> "_Layout.cshtml".
   - Comment out line 38: `@if (User.IsInRole(ApplicationRoles.Role_Admin))`.
   - Go to "Ordersystem.Web" -> "Areas" -> "Identity" -> "Pages" -> "Account" -> "Register.cshtml".
   - Comment out line 63: `@if (User.IsInRole(ApplicationRoles.Role_Admin))`.
   - Save the changes.

11. Run the Application as Admin:
   - Run the application again.
   - When you go to the registration page, you will see a dropdown to choose roles, including admin, user, and employee.
   -

 Choose the "admin" role to register as an admin user.

These instructions should guide you through the process of setting up and running the application successfully. If you encounter any issues, please make sure to review the steps and ensure that all prerequisites are met.
