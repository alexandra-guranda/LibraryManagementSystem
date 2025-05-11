using System.Collections.Generic;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book? GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        List<Book> SearchBooks(string title, string author);
        bool LendBook(int id);
        bool ReturnBook(int id);
    }
}
