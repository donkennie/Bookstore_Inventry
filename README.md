# Bookstore Inventory Management System

## Overview

The **Bookstore Inventory Management System** is a RESTful web API built with **.NET 8.0** and **PostgreSQL**. It provides functionalities to manage a bookstore's inventory, including adding books, updating stock quantities, retrieving book details, and filtering books based on criteria such as author or price range.

## Features

- **Add a Book**: Add a book with properties like title, author, price, and stock quantity.
- **Retrieve All Books**: Fetch a list of books with optional filters (author, price range).
- **Update Stock**: Update the stock for a specific book, ensuring non-negative stock values.
- **Validation**: Input validation for adding/updating books, including constraints like price > 0, stock >= 0, and non-empty title/author.
- **Logging**: Logs database operations for tracking.
- **Error Handling**: Middleware to handle exceptions globally.
  
## Technologies

- **Backend**: .NET 8.0
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Validation**: Fluent Validation
- **Logging**: Serilog
- **Dependency Injection**: Built-in .NET DI
- **Asynchronous Programming**: Used for database operations

## Prerequisites

Before you begin, ensure that you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio or Visual Studio Code](https://code.visualstudio.com/) (Optional, but recommended for development)

## Setup and Installation

### 1. Clone the repository

```bash
git clone https://github.com/donkennie/Bookstore_Inventry.git
cd Bookstore_Inventry
