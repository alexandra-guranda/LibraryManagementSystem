# LibraryManagementSystem
This is a C# console application that simulates a basic library system. The project is organized using a multi-layer architecture and uses SQLite as the database through Entity Framework Core.

# About the project

This application was developed as part of an internship assignment. It demonstrates my understanding of software architecture, database interaction, and practical C# programming skills. The goal was to implement a functional, extendable, and realistic library management system — and I chose to build something more than just the basic requirements.

# Core Features (CRUD)

- **Add Book** – Add a new book with title, author, quantity
- **View All Books** – Show all books with availability
- **Search Book** – Search by title and/or author
- **Lend Book** – Decreases available copies and tracks usage
- **Return Book** – Increases available copies
- **Delete Book** – Remove a book from the system

# Extended Features (Bonus Functionality)

These are extra features I added beyond the initial requirements:

- **Waitlist System**  
  When a book is unavailable, users can choose to be added to a waitlist. This simulates a real-world scenario where demand exceeds stock.

- **Top 5 Most Borrowed Books**  
  The system tracks how many times each book was borrowed and shows a live top chart based on that metric.

- **Borrow Count**  
  Each book tracks how often it was borrowed, allowing for future analytics or recommendation features.

- **Database Pre-Population**  
  I populated the database with real book titles — from personal development and classic literature to Romanian novels and cookbooks — for realistic testing and interface demonstration.

- **Portable SQLite Connection**  
  The application dynamically locates the database using the app directory, so it doesn't depend on any hardcoded paths.

# Technologies Used

- C# (.NET 8 Console App)
- Entity Framework Core
- SQLite
- Visual Studio 2022

#  Project Structure

- LibraryManagementSystem.Models – Book and WaitlistEntry models
- LibraryManagementSystem.DAL – Repositories, database context
- LibraryManagementSystem.BLL – Business logic (BookService)
- LibraryManagementSystem.UI – Console interface

#  Notes

- The project is written to be easy to extend with more features like borrow history, overdue checks, export to CSV, etc.

