# Foodee Web API powered by ASP.NET Core MVC

This project is a food website developed using .NET Core 8, incorporating Web API and MVC Core. The architecture follows the Onion Design Pattern, implementing the Mediator Pattern and emphasizing Folder Structure and Code First approach. Features include the utilization of Fluent Validation for user input validation and View Components for reusable UI elements, enhancing user experience and maintaining clean code. An admin panel enables dynamic content management, empowering site owners to easily update and manage content.

**Many entity-specific methods have been written on the API**
![api foods](https://github.com/senerdag/Foodee-AspNetCore-WebApi/assets/79213168/5b5ab9f1-223c-4deb-b1da-c40334f5c986)
**Most parts of our site, which we have divided into parts with view components, are dynamic and all are controlled through the admin panel.**
![Admin food](https://github.com/senerdag/Foodee-AspNetCore-WebApi/assets/79213168/54cdc986-5e73-492a-befd-a3f356bee1a4)
![featured dishes](https://github.com/senerdag/Foodee-AspNetCore-WebApi/assets/79213168/fb8a6cc1-203e-4bc3-b87a-a43bdd5ae0a0)

![Menu](https://github.com/senerdag/Foodee-AspNetCore-WebApi/assets/79213168/a64df450-3750-4d6b-819a-1a8e7f67fa15)
![admin event](https://github.com/senerdag/Foodee-AspNetCore-WebApi/assets/79213168/61db502d-36d6-4a24-9f36-5f3ce23620f8)
![admin reservation](https://github.com/senerdag/Foodee-AspNetCore-WebApi/assets/79213168/509fae7a-0326-453a-b4c7-5df524e100fa)
![reserve a table](https://github.com/senerdag/Foodee-AspNetCore-WebApi/assets/79213168/de2ffe11-2057-40ac-b556-d079589dabab)
# Technologies Used
**Backend**
- **Web Development Framework:** ASP.NET Core 8.0
- **C#:** In the backend, the C# language has been utilized.
- **MSSQL:** Microsoft SQL Server has been used as the database.
- **Swagger:** Swagger has been used for API documentation.
- **Code First Approach**


 
**Frontend**
- **HTML:** HTML has been used for structuring the pages.
- **CSS:** CSS has been used for determining styles.
- **Bootstrap:** Bootstrap is used for fast and effective interface design.
- **JavaScript:** JavaScript is used for page interactions.


# **Design Patterns**
- **Mediator:** It is a pattern based on providing communication between objects derived from the same interface through a single point.

 
# **Project Structure and Layered Architecture**
 The project follows the following layered architecture structure:
 - **Core:** In the Core layer we have Domain (class project where we define Entities) and Application (we have Design Pattern, Interfaces and mostly services)
 - **Frontends:** In our Frontends layer, we have Dto (Mapping) and WebUI (MVC) projects.
 - **Infrastructure:** In our Persistence project, we have the string connection to which we connect our database, migrations and repositories of our interfaces.
 - **Presentation:** Presentation layer contains the Web API to which we send requests for our Web Application.

   
# **Requirements**
- .NET Core SDK
- Microsoft SQL Server

  
# **API Endpoints**
**There are many entity specific query operations inside the project(statistics, filtering operations etc.), the following are just normal crud enpoints.**
- GET: Lists all items 
- GET By Id: Fetches according to ID. 
- POST: Creates a new item. 
- DELETE: Deletes the fetched item by ID. 
- PUT: Updates fetched item according to ID 
