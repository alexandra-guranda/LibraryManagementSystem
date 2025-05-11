using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository()
        {
            _context = new LibraryContext();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book? GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
        public void AddToWaitlist(int bookId, string name)
        {
            var entry = new WaitlistEntry
            {
                BookId = bookId,
                Name = name,
                RequestDate = DateTime.Now
            };

            _context.WaitlistEntries.Add(entry);
            _context.SaveChanges();
        }
    }
}
