# Insurance Policy Management API

## Overview
The Insurance Policy Management API is a RESTful service built using C# and .NET that allows users to manage insurance policies. This API supports CRUD operations for insurance policies, enabling users to create, read, update, and delete policy records.

## Project Structure
```
insurance-policy-management-api
├── Controllers
│   └── PoliciesController.cs
├── Models
│   └── Policy.cs
├── Services
│   └── PolicyService.cs
├── Data
│   └── ApplicationDbContext.cs
├── DTOs
│   └── PolicyDto.cs
├── Program.cs
├── Startup.cs
├── appsettings.json
├── appsettings.Development.json
└── InsurancePolicyManagementApi.csproj
```

## Setup Instructions

1. **Clone the Repository**
   ```
   git clone <repository-url>
   cd insurance-policy-management-api
   ```

2. **Install Dependencies**
   Ensure you have the .NET SDK installed. Run the following command to restore the dependencies:
   ```
   dotnet restore
   ```

3. **Configure Database**
   Update the `appsettings.json` file with your database connection string.

4. **Run Migrations**
   If using Entity Framework Core, run the following command to apply migrations:
   ```
   dotnet ef database update
   ```

5. **Start the API**
   Run the application using:
   ```
   dotnet run
   ```

## API Endpoints

- **GET /api/policies**: Retrieve a list of all insurance policies.
- **GET /api/policies/{id}**: Retrieve a specific insurance policy by ID.
- **POST /api/policies**: Create a new insurance policy.
- **PUT /api/policies/{id}**: Update an existing insurance policy.
- **DELETE /api/policies/{id}**: Delete an insurance policy.

## Usage Examples

### Create a Policy
```http
POST /api/policies
Content-Type: application/json

    {
      "id": "11",
      "company": "APP Compnay ",
      "policy": "Long-Term Disability Insurance Most long-term disability insurance policies categorize disabilities as own occupation or any occupation. 1 Own occupation means the insured, due to disability, is unable to perform their regular job or a similar job. Any occupation means the insured, due to disability, is unable to perform any job for which they are qualified.",
      "issuedOn": "2024-11-30T21:00:00.000Z",
      "expiringOn": "2024-12-02T21:00:00.000Z",
      "status": "renew"
    }
```

### Get All Policies
```http
GET /api/policies
```

## Error Handling
The API implements proper error handling and validation to ensure that all requests are processed correctly. In case of an error, appropriate HTTP status codes and messages will be returned.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
