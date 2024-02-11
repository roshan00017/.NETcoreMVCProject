# Project Documentation: .NET Core MVC Project

## Introduction

This documentation provides an overview of a .NET Core MVC project that implements CRUD operations on tasks, users, and categories, along with sorting, searching, pagination, and exporting tasks to Excel. The project utilizes the AdminLTE UI library for the frontend.

## Features

1. **CRUD Operations:**
   - Allows creating, reading, updating, and deleting tasks, users, and categories.
   
2. **Sorting:**
   - Provides sorting functionality for tasks, users, and categories based on different criteria such as title, user, etc.

3. **Searching:**
   - Implements search functionality to find tasks, users, and categories based on keywords or specific criteria.

4. **Pagination:**
   - Implements pagination to display a limited number of records per page and navigate through multiple pages of data.

5. **Export to Excel:**
   - Allows exporting tasks to Excel format for further analysis or reporting.

6. **AdminLTE UI:**
   - Utilizes the AdminLTE UI library for the frontend, providing a responsive and user-friendly interface.

## Setup and Usage

1. **Clone the Repository:**
   - Clone the project repository from the GitHub repository URL.

2. **Install Dependencies:**
   - Ensure that you have .NET Core SDK installed on your system.
   - Restore the project dependencies by running `dotnet restore` command in the project directory.

3. **Database Setup:**
   - Configure the database connection string in the `appsettings.json` file.
   - Run the migrations to create the database schema by executing `dotnet ef database update` command in the Package Manager Console.

4. **Run the Application:**
   - Build and run the application using `dotnet run` command.
   - Access the application through the provided URL (e.g., `https://localhost:5001`).

5. **Explore Features:**
   - Navigate through different sections of the application to explore CRUD operations, sorting, searching, pagination, and exporting tasks to Excel.
   - Use the provided UI elements and controls to interact with the application features.

## Project Structure

- **Controllers:** Contains controller classes responsible for handling HTTP requests and implementing application logic.
- **Models:** Defines the data models representing tasks, users, and categories.
- **Views:** Contains the HTML templates and UI components rendered by the application.
- **Data:** Includes database context and migrations for managing database operations.
- **Services:** Contains service classes for implementing business logic and data manipulation.
- **Scripts and Styles:** Includes JavaScript and CSS files for frontend functionality and styling.

## Dependencies

- **.NET Core SDK:** Required for building and running .NET Core applications.
- **Entity Framework Core:** ORM framework for database interactions.
- **AdminLTE UI Library:** Provides frontend templates and components for building responsive web applications.

## Contributing

If you'd like to contribute to this project, please follow the standard GitHub workflow:

1. Fork the repository.
2. Create a new branch for your feature or bug fix (`git checkout -b feature-name`).
3. Make changes and commit them (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-name`).
5. Create a new pull request.

## License

This project is licensed under the [MIT License](LICENSE).

## Authors

- [Your Name](https://github.com/roshan00017) - Developer



![Screenshot (5)](https://github.com/roshan00017/.NETcoreMVCProject/assets/57831675/d31c171f-0bea-4683-8743-b0e1b7676c87)

![Screenshot (3)](https://github.com/roshan00017/.NETcoreMVCProject/assets/57831675/794bbbf2-dfcd-4e30-8d10-d2f9a00e247f)

