# dotnet-project

## How to run it

You need to clone the project using git clone and then create a MySQL database. 

Then simply enter the database connection string to the "DefaultConnection" field that is located at appsettings.json file.

## Features implemented 
• Provide a CRUD Project API. A project will contain a title, description, name, progress
(0-100), start date and finish date.

• Provide a CRUD Task API. A task will contain a title, description, parent project,
progress (0-100), status (TODO, IN-PROGRESS, IN-REVIEW, DONE), start date and
finish date.

• When a Project is retrieved, its related tasks should be retrieved as well.

• Provide a Swagger API documentation for the application.

• Feel free to use one of the following databases: PostgreSQL, MariaDB, MySQL.

## Features that I would like to implement 
• Your application and database must run in docker containers and use docker-
compose.


## How I built it 

Basically I tried to follow the MVC pattern that I have learned throught university and my experience. 
I tried to divide the entities "projects and tasks" into services and dtos in order to make my code scalable and easy to navigate.
