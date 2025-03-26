# Customer Registration API

## Overview

This is a simple REST API built using .NET Core (ASP.NET Core) for managing customer registrations. The API validates incoming customer data, stores the customer in the database, and returns a unique customer ID.

The API supports the following:
- Creating a new customer.
- Validating customer input.
- Storing customer data in a database (MS SQL Server).
- Returning the unique Customer ID after a successful creation.

## Features

- **Customer Creation**: Allows for the creation of a new customer record.
- **Input Validation**: Validates various customer fields like first name, surname, policy reference, date of birth, and email.
- **Transaction Support**: Ensures database operations are atomic with support for transactions.
- **Swagger UI**: Provides a web interface for testing API endpoints (available in development mode).


## Test Cases

** 1. Test Case: Valid Customer with Date of Birth
Expected Response: 201 Created ** PASSED
![image](https://github.com/user-attachments/assets/f2ded040-0fca-44c0-ab08-69fe10501cbe)

** 2. Test Case: Valid Customer with Email
Expected Response: 201 Created ** PASSED
![image](https://github.com/user-attachments/assets/e482afb7-eb19-4586-a43f-90cbb78a152b)

** 3. Test Case: Valid Customer with Both Date of Birth and Email
Expected Response: 201 Created ** PASSED
![image](https://github.com/user-attachments/assets/380787da-8683-4bfc-8e3e-e00eced439a2)


** 4. Test Case: Missing Date of Birth and Email
Expected Response: 400 Bad Request ** PASSED
![image](https://github.com/user-attachments/assets/cfcf812f-b450-4331-859f-7a60247fc0b8)


** 5. Test Case: Invalid Email Format
Expected Response: 400 Bad Request ** PASSED
![image](https://github.com/user-attachments/assets/242f9aa8-89cf-44fa-a92d-b47259570fc4)


** 6. Test Case: Invalid Policy Reference Number Format
 Expected Response: 400 Bad Request ** PASSED
![image](https://github.com/user-attachments/assets/8084a4ca-d891-4601-8405-8cee3c84551b)


** 7. Test Case: Invalid Date of Birth (Under 18)
Expected Response: 400 Bad Request ** PASSED
![image](https://github.com/user-attachments/assets/ab081193-9c06-4cf6-b97c-0bdcd83effbf)


** 8. Test Case: Empty First Name
Expected Response: 400 Bad Request ** PASSED
![image](https://github.com/user-attachments/assets/c5c21613-af01-4826-ac33-8ea794948e13)


** 9. Test Case: Empty Surname
Expected Response: 400 Bad Request ** PASSED
![image](https://github.com/user-attachments/assets/c1a56c26-0d4f-4c3c-941a-122d6a8685ce)


** 10. Test Case: Missing First Name (Required)
Expected Response: 400 Bad Request ** PASSED
![image](https://github.com/user-attachments/assets/6ff25df3-bc21-42aa-9e2b-c3ba4a195892)

