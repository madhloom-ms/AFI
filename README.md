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
