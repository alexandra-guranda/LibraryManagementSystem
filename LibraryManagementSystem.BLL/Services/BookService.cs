using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Repositories;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService()
        {
            _repository = new BookRepository();
        }

        public List<Book> GetAllBooks() => _repository.GetAllBooks();

        public Book? GetBookById(int id) => _repository.GetBookById(id);

        public void AddBook(Book book)
        {
            book.AvailableCopies = book.Quantity; // initialize available copies
            _repository.AddBook(book);
        }

        public void UpdateBook(Book book)
        {
            _repository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            _repository.DeleteBook(id);
        }

        public List<Book> SearchBooks(string title, string author)
        {
            return _repository.GetAllBooks()
                .Where(b =>
                    (string.IsNullOrEmpty(title) || b.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(author) || b.Author.Contains(author, System.StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        public bool LendBook(int id)
        {
            var book = _repository.GetBookById(id);
            if (book == null || book.AvailableCopies <= 0)
                return false;

            book.AvailableCopies--;
            book.BorrowCount++; 
            _repository.UpdateBook(book);
            return true;
        }


        public bool ReturnBook(int id)
        {
            var book = _repository.GetBookById(id);
            if (book == null || book.AvailableCopies >= book.Quantity)
                return false;

            book.AvailableCopies++;
            _repository.UpdateBook(book);
            return true;
        }
        public List<Book> GetTopBorrowedBooks(int top = 5)
        {
            return _repository.GetAllBooks()
                .OrderByDescending(b => b.BorrowCount)
                .Take(top)
                .ToList();
        }
        public void AddToWaitlist(int bookId, string name)
        {
            _repository.AddToWaitlist(bookId, name);
        }


    }
}
