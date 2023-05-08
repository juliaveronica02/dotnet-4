1. open xampp.
2. start apache and mySQL.
3. On mysql, start admin to for redirect to localhost database mysql.
4. create database name, example: dotnet-crud.
5. create table inside database name, example: user.
6. make the form what user should field, example: username, firstname, lastname, password, createdAt, and updatedAt.
7. open visual studio 2022.
8. create new project - select ASP.NET Core Web API (core 7).
9. To access database with entity framework, install below three NuGet packages:
    a. Microsoft.EntityFrameworkCore.Design.
    b. Microsoft.EntityFrameworkCore.Tools.
    c. MySql.EntityFrameworkCore.
10. open the package manager console to write a command that will allow us to perform scaffolding from the database: "Scaffold-DbContext "server=localhost;port=3306;user=root;password=Hallo123$;database=dotnet-crud" MySql.EntityFrameworkCore -OutputDir Entities -f"
11. To open package manager we can go to view toolbar - select other windows - choose package manager console.
12. the result we will have new folder and files is called entities folder and two new files inside that folder.
13. the "DotnetCrudContext.cs" file name change to "DBContext.cs".
14. make a comment on entities (folder) files, example: "user.cs" add some comment as models.
15. on "appsettings.json" files add connection strings.
16. at "program.cs" file add as a service to the DBContext and reference the DefaultConnection the property specified in the "appsettings.json" file. the code put in below comment "// Add services to the container."
17. don't forget on "program.cs" file add dependency "using WebApplication3.Entities;".
18. to transport data between the processes for the management of the database and the processes for working with web services, it's advisable to establish DTO classes for each entity of the project.
19. to do this, we create a new folder within the project called DTO and create a class called UserDTO, whose attributes will be the same as the `user.cs` defined in the entities folder.
20. create class: right click on the mouse - add - class.
21. add controller: right click on the mouse - controller - API - API empty controller.
22. controller folder goal: perform CRUD operations (Create, read, update, and delete). method: post (create), get (read), put (update) and delete.
23. to clear record on database with ID start from zero again, we can press "empty" on xampp phpymyadmin.

------
## push to github repo
1. `git init`.
2. `git add .`
3. `git commit -m "enter your comment"`
4. `git remote add origin <your github repo link>`
5. `git push origin master`
6. done.
