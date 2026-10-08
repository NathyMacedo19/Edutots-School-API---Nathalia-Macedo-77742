# School Directory Dashboard

## CA1 Assignment – School Directory Dashboard using the Edutots School API

A Blazor Web Application developed as part of the CA1 assignment.  
The application consumes the Edutots School API and provides an interactive School Directory Dashboard where users can search, sort, favourite, refresh and view detailed information about schools.

---

## Project Description

The School Directory Dashboard retrieves school information from the Edutots School API and presents the data through a clean and responsive user interface.

The application allows users to:

- View a list of schools.
- Search schools by name.
- Select a school to view detailed information.
- Sort schools alphabetically.
- Mark schools as favourites.
- Refresh the school data.
- View school statistics.
- See loading feedback while data is being retrieved.
- Receive an error message if the API cannot be reached.

The project was developed using Blazor and C# with `HttpClient` for API communication.

---

## Technologies Used

- C#
- .NET
- Blazor
- ASP.NET Core
- HttpClient
- REST API
- System.Net.Http.Json
- Bootstrap
- HTML
- CSS
- Git
- GitHub
- Visual Studio

---

## API

The application consumes the following Edutots School API:

**API Endpoint:**

https://edutots.net/api/school

The API returns school information in JSON format.

The application deserializes the JSON response into a C# `School` model.

---

## Main Features

### School List

The application displays school information including:

- School ID
- School Name
- Address
- Phone Number
- Email Address
- Proprietor Full Name
- Head Full Name

### Search

Users can search schools by name using the search field.

The search is performed as the user types and is case-insensitive.

Example:

<input @bind="Search" @bind:event="oninput" class="form-control" placeholder="Search school..." />


### School Details

When a school is selected, the application displays detailed information about that school.

The details include:

- School ID
- School Name
- Address
- Phone Number
- Email Address
- Proprietor Full Name
- Head Full Name

### Loading State

While school information is being retrieved from the API, the application displays a loading message/spinner.

Example:

Loading schools...


### Error Handling

If the API request fails, the application displays an error message instead of crashing.

Example:

Unable to retrieve school data.


### Sorting

Schools can be sorted alphabetically by school name.

### Favourite Schools

Users can mark schools as favourites for easier identification.

### Refresh

A refresh button allows the user to retrieve the latest school information from the API.

### School Statistics

The dashboard displays statistics such as:

- Total number of schools
- Number of schools currently displayed
- Number of favourite schools

---

## Project Structure

The main project files are organised as follows:

Edutots School API - Nathalia Macedo 77742 │ ├── Models │ └── School.cs │ ├── Services │ └── SchoolService.cs │ ├── Components │ └── Pages │ ├── Schools.razor │ ├── SchoolCard.razor │ └── SchoolDetails.razor │ ├── Program.cs │ └── README.md


---

## Components

### School.cs

The `School` model represents the school information retrieved from the API.

The model contains:

SchoolId SchoolName Address PhoneNo EmailAddress ProprietorFullName HeadFullName


Only the fields required by the assignment are used.

---

### SchoolService.cs

`SchoolService` is responsible for communicating with the Edutots API.

It uses `HttpClient` to retrieve school information and deserialize the JSON response into a list of `School` objects.

---

### SchoolCard.razor

`SchoolCard` is a reusable Blazor component used to display individual schools.

It receives a `School` object through a `[Parameter]`:

[Parameter] public School School { get; set; }


The component also uses `EventCallback` to notify the parent component when a school is selected:

[Parameter] public EventCallback<School> OnSelect { get; set; }


---

### SchoolDetails.razor

`SchoolDetails` is responsible for displaying the detailed information of the selected school.

It displays only the fields required by the assignment.

---

### Schools.razor

`Schools.razor` is the main dashboard page.

It is responsible for:

- Loading schools from the API.
- Displaying the school list.
- Searching schools.
- Sorting schools.
- Selecting schools.
- Displaying school details.
- Handling loading states.
- Handling API errors.
- Managing favourites.
- Refreshing the data.
- Displaying statistics.

---

## Data Flow

The application follows this basic flow:

Edutots School API | v SchoolService | v HttpClient | v School.cs Model | v Schools.razor | +----------------+ | | v v SchoolCard SchoolDetails


---

## Error and Loading States

The application provides feedback to the user during API communication.

### Loading

When the application is retrieving data:

Loading schools...


is displayed.

### Error

If the API cannot be reached or an error occurs:

Unable to retrieve school data.


is displayed.

This prevents the application from failing silently and provides feedback to the user.

---

## How to Run the Application

### Requirements

Before running the application, make sure you have:

- .NET SDK installed.
- Visual Studio 2022 or another compatible IDE.
- Internet connection for accessing the Edutots API.

### Steps

1. Clone the repository:

git clone https://github.com/NathyMacedo19/Edutots-School-API---Nathalia-Macedo-77742.git


2. Open the project in Visual Studio.

3. Restore the project dependencies.

4. Build the project.

5. Run the application using Visual Studio or:

dotnet run


6. Open the application in the browser.

7. Navigate to the School Directory page.

---


The source code and commit history are available on GitHub:

https://github.com/NathyMacedo19/Edutots-School-API---Nathalia-Macedo-77742.git

Author
Nathalia Macedo
CA1 Assignment School Directory Dashboard using the Edutots School API


