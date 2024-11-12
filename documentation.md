Author and creator of this project [ Niklas Häll ]

# Fjantar_runt_med_DB

### Note / README reptetition:

This document includes documentation of the work progress.
README.md has a brief introduction to the project folder and its files.
LICENCE has the MIT-licence agreement for this project.
.gitignore handles which files should not be added to the github repository.

# Documentation

## Conceptual layout before the creation

```
Fjantar_runt_med_DB
│
├── Core
│   ├── DatabaseType.cs               # Enum for database types (MySQL, SQLite, MongoDB, etc.)
│   ├── IDatabaseConnection.cs        # Interface for connection pooling, async support
│   ├── IDatabaseManager.cs           # Core interface for DatabaseManager operations
│   └── ICrudRepository<T>.cs         # Generic CRUD interface for repository pattern
│
├── UI
│   └── Menu.cs                       # Manages user interactions, selection of database type
│
├── DatabaseConnections
│   ├── MySqlConnectionPool.cs        # Implements connection pool, async commands for MySQL
│   ├── SQLiteConnectionPool.cs       # Implements connection pool, async commands for SQLite
│   ├── MongoDBConnectionPool.cs      # Implements MongoDB async support
│   └── ApiConnection.cs              # Handles API interactions
│
├── Repositories
│   ├── MySqlRepository.cs            # Repository for MySQL implementing ICrudRepository
│   ├── SQLiteRepository.cs           # Repository for SQLite implementing ICrudRepository
│   └── MongoDbRepository.cs          # Repository for MongoDB implementing ICrudRepository
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

## Moving on