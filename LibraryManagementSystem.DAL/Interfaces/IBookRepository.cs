using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book? GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        void AddToWaitlist(int bookId, string name);

    }
}
