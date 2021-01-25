using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBookRepository
    {
        Task<int> addNewBook(Book model);
        Task<List<Book>> getAllBooks();
        Task<Book> getBookById(int id);
        Task<List<Book>> getTopBooksAsync(int count);
        List<Book> searchBook(string title, string author);

        string getAppName();
    }
}