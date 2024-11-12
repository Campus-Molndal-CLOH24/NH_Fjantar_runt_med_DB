Author and creator of this project [ Niklas Häll ]

# Fjantar_runt_med_DB

### Note / README reptetition:

This document includes documentation of the work progress.
README.md has a brief introduction to the project folder and its files.
LICENCE has the MIT-licence agreement for this project.
.gitignore handles which files should not be added to the github repository.

# Documentation

## Goals with the project

1. Have a dynamic switch menu that can chose between different database connections through a menu
2. Use Repository Pattern at least once
3. Utilize a Connection pool
4. Implement Async commands where it is logical to do should
5. Create dynamic CRUD-systems so we can use the same code for different databases / syntaxes
6. Dependency Injection
7. Write this as a console program in C#

## Conceptual layout before the creation

```
Fjantar_runt
│
├── Core
│   ├── DatabaseType.cs               # Enum for database types (MySQL, SQLite, MongoDB, etc.)
│   ├── IDatabaseConnection.cs        # Interface for connection pooling, async support
│   ├── IDatabaseManager.cs           # Interface for DatabaseManager
│   └── ICrudRepository.cs            # Generic CRUD interface for repository pattern
│
├── UI
│   ├── Menu.cs                       # Manages user interactions, selection of database type
│   └── BaseRepository.cs             # Handle connection to repositories to avoid duplicated code
│
├── DatabaseConnections
│   ├── DatabaseManager.cs            # Main manager for handling database connections
│   ├── MySqlConnectionPool.cs        # Implements connection pool, async commands for MySQL
│   ├── SQLiteConnectionPool.cs       # Implements connection pool, async commands for SQLite
│   ├── MongoDBConnectionPool.cs      # Implements MongoDB async support
│   └── ApiConnection.cs              # Handles API interactions
│
├── Repositories
│   ├── MySqlRepository.cs            # Repository for MySQL implementing ICrudRepository
│   ├── SQLiteBookRepository.cs       # Repository for SQLite implementing ICrudRepository - Books
│   └── MongoDbRepository.cs          # Repository for MongoDB implementing ICrudRepository
│
├── SQLiteEntities
│   └── Books.cs                      # Handles SQLite Books-table/class
│
├── CRUDOperations                    # Folder for dynamic CRUD commands
│   ├── Create.cs                     # Generalized create commands for each DB type
│   ├── Read.cs                       # Generalized read commands for each DB type
│   ├── Update.cs                     # Generalized update commands for each DB type
│   └── Delete.cs                     # Generalized delete commands for each DB type
│
├── Services
│   └── DatabaseService.cs            # Handles logic for dynamic CRUD operations using DI
│
└── Program.cs                        # Application entry point
```

## Initial creation

- Created the Menu-method call and the ApplicationShutdown method in Program.Main
- Created UI.Menu.cs
- Created DatabaseConnections.DatabaseManager.cs
- Created Core.ICrudRepository.cs  
- Created SQLiteBookRepository.cs
- Created SQLiteEntities.Books.cs
- Created UI.BaseRepository.cs

## Moving on