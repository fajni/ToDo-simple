# ToDo-simple
Simple CRUD ToDo Application Made In .NET Framework Using Windows Forms. Main Idea Is To Track Obligations.

## Project Structure

```
├── source/TODO				# Contains all the source files for application.
│   │
│   ├── BusinessLayer			# Business logic for manipulating data, manage communications between repository and presentation layers.
│   │   ├── UserBusiness.cs
│   │   └── ObligationBusiness.cs
│   │
│   ├── PresentationLayer		# Contains user interface and logic responsible for presenting data to user, as well as user actions.
│   │   ├── Resources			# Contains symbols/images used in presentation layer.
│   │   ├── Program.cs
│   │   ├── LoginForm.cs
│   │   ├── MainForm.cs
│   │   ├── ObligationsForm.cs
│   │   ├── RegistrationForm.cs
│   │   └── UserForm.cs
│   │
│   ├── RepositoryLayer			# Data access layer that contains files for communication with the database.
│   │   ├── UserRepository.cs
│   │   ├── ObligationRepository.cs
│   │   └── Constants.cs		# Contains connection string for database.
│   │
│   ├── Shared				# Folder that contains other content.
│   │   ├── Models			# Available entities.
│   │   ├── Interfaces			
│   │   └── Tables			# Contains SQL files for creating tables and other SQL queries.
│   │
│   └── Tests				# Unit Testing
│
├── ER					# Contains ER diagrams.
│   └── entity-relationship diagram.png
└── README.md                   	# Project documentation (you are here!)
```