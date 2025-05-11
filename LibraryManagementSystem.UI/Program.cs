using System;
using LibraryManagementSystem.BLL.Services;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookService = new BookService();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Library Management System ===");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Show All Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Lend Book");
                Console.WriteLine("5. Return Book");
                Console.WriteLine("6. Show Top 5 Most Borrowed Books");
                Console.WriteLine("7. Delete Book");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBook(bookService);
                        break;
                    case "2":
                        ShowAllBooks(bookService);
                        break;
                    case "3":
                        SearchBooks(bookService);
                        break;
                    case "4":
                        LendBook(bookService);
                        break;
                    case "5":
                        ReturnBook(bookService);
                        break;
                    case "6":
                        ShowTopBorrowedBooks(bookService);
                        break;
                    case "7":
                        DeleteBook(bookService);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void AddBook(BookService bookService)
        {
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Author: ");
            string author = Console.ReadLine() ?? string.Empty;

            Console.Write("Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 1)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            var book = new Book
            {
                Title = title,
                Author = author,
                Quantity = quantity
            };

            bookService.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }

        static void ShowAllBooks(BookService bookService)
        {
            var books = bookService.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found in the library.");
                return;
            }

            Console.WriteLine("\n--- Book List ---");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id} | Title: {book.Title} | Author: {book.Author} | Total: {book.Quantity} | Available: {book.AvailableCopies}");
            }
        }
        static void SearchBooks(BookService bookService)
        {
            Console.Write("Search by title (leave empty to skip): ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Search by author (leave empty to skip): ");
            string author = Console.ReadLine() ?? string.Empty;

            var results = bookService.SearchBooks(title, author);

            if (results.Count == 0)
            {
                Console.WriteLine("No books found matching your criteria.");
                return;
            }

            Console.WriteLine("\n--- Search Results ---");
            foreach (var book in results)
            {
                Console.WriteLine($"ID: {book.Id} | Title: {book.Title} | Author: {book.Author} | Total: {book.Quantity} | Available: {book.AvailableCopies}");
            }
        }
        static void LendBook(BookService bookService)
        {
            Console.Write("Enter the ID of the book to lend: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            bool success = bookService.LendBook(id);

            if (success)
            {
                Console.WriteLine("Book lent successfully.");
            }
            else
            {
                Console.WriteLine("Book is not available right now.");
                Console.Write("Would you like to be added to the waitlist? (y/n): ");
                string? response = Console.ReadLine()?.Trim().ToLower();

                if (response == "y")
                {
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine() ?? "Anonymous";
                    bookService.AddToWaitlist(id, name);
                    Console.WriteLine($"You have been added to the waitlist for book ID {id}.");
                }
                else
                {
                    Console.WriteLine("You were not added to the waitlist.");
                }
            }
        }

        static void ReturnBook(BookService bookService)
        {
            Console.Write("Enter the ID of the book to return: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            bool result = bookService.ReturnBook(id);
            if (result)
            {
                Console.WriteLine("Book returned successfully.");
            }
            else
            {
                Console.WriteLine("Return failed. Either the book doesn't exist or all copies are already returned.");
            }
        }
        static void ShowTopBorrowedBooks(BookService bookService)
        {
            var topBooks = bookService.GetTopBorrowedBooks();

            if (topBooks.Count == 0)
            {
                Console.WriteLine("No books have been borrowed yet.");
                return;
            }

            Console.WriteLine("\n--- Top 5 Most Borrowed Books ---");
            foreach (var book in topBooks)
            {
                Console.WriteLine($"Title: {book.Title} | Author: {book.Author} | Times Borrowed: {book.BorrowCount}");
            }
        }
        static void DeleteBook(BookService bookService)
        {
            Console.Write("Enter the ID of the book to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var book = bookService.GetBookById(id);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete '{book.Title}' by {book.Author}? (y/n): ");
            string? confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "y")
            {
                bookService.DeleteBook(id);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }


    }
}
