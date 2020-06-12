
# _Family Parks API_
#### _Epicodus Project June 12, 2020_

#### By _**Julia Seidman**_


## Description

_A basic web API created in C#/.Net Core 2.2.0. and MySQL.  The API is a database of local parks with search and ratings focused on the things that make parks most useable and enjoyable for families with young children._

## Setup/Installation Requirements

1. Clone this repository from GitHub.
2. Install MySQL on your computer.
3. Open the downloaded directory in a text editor of your choice. (VSCode, Atom, etc.)
4. In your terminal, navigate to the project directory and run the commands dotnet restore and dotnet build to download dependencies and build the configuration.
5. Currently, the mySQL database is set up with an appsettings.json file that was not uploaded to Github.  Once you have saved the SQL database on your computer, create an appsettings.json file in the project root directory, and update it with your MySQL installation information in this format:
  ```
  {
    "ConnectionStrings": 
    {
      "DefaultConnection": "Server=localhost;Port=YOUR PORT NUMBER HERE;database=DATABASE NAME AS YOU SAVED IT;uid=YOUR USER ID HERE;pwd=YOUR PASSWORD HERE;"
    }
  }
```
6. To run MySQL migrations and create a database in your MySQL installation, enter the following command in your terminal: ```dotnet ef database update```.
7. This API uses Swagger. To launch the Swagger/OpenAPI utility in your browser, from the project directory in your terminal, enter ```dotnet run``` and open a browser page at localhost:5000.  You can now see all API routes grouped by controller, including a summary of what each route does and necessary information for using it properly.  Clicking on a route will expand it and show details of that route, and give you the option to "Try It Out."


## Known Bugs

There are no known bugs at the time of this update.

## Support and contact details

_Have a bug or an issue with this application? [Open a new issue] here on GitHub._

## Technologies Used

* C#
* .NET Core
* ASP.NET Core MVC
* MySQL
* Identity
* MSBuild
* Git and GitHub
* Swagger/OpenAPI


### Specs

|                          Specification                     | Input  | Output  |
| :--------------------------------------------------------: | :----: | :-----: |
| Allow user to search for a park by a range of criteria | 'Location = Issaquah' | 'Lake Sammamish State Park, Pine Lake Park' |
| Allow user to search parks by categorized ratings | 'cleanliness = 4' | 'Marymoor Park, Clean: 4, Accessible: 4, etc.' |
| Allow user to add parks to the database | "Cougar Mountain Regional Wildlands" | park and data added to database |
| Require new Parks to use standard "type" and parking permit" language to ensure consistency | "Type = local" | "That is not an accepted type of park.  Accepted park types are in the header of API GET responses." |
| Allow users to edit and delete park entries they have created. | "Cougar Mountain Park" | *park edited* |
| Alert users when they attempt to edit a park with a different userID | "User Id = 7374652" | "This user is not permitted to edit this park entry. |
| Allow users to post reviews for parks. | "Clean: 4, Accessible: 3, Fun For Kids: 3, Fun For Parents: 4" | *rating added* |



### License
This software is licensed under the MIT license.

Copyright (c) 2020 **_Julia Seidman_**