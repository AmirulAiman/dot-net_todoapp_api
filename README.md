# .Net TodoApp api
Back-end api for the Vuejs [Todo app](https://github.com//AmirulAiman/vue-todo-app) front-end

# Setup
- Open appSettings.json and update the `DefaultConnection` to database connection string
- Make sure the following package are installed
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
- Open the Packakge Manager Console and run below command to generate the database table

            Update-database

- Run it
- Open swagger page (http://localhost:[port number]>/swagger/v1/swagger.json) to check the Api