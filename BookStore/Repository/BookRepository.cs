using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<Book> getAllBooks()
        {
            return dataSource();
        }

        public Book getBookById(int id)
        {
            return dataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Book> searchBook(string title, string author)
        {
            return dataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }

        private List<Book> dataSource()
        {
            return new List<Book>()
            {
                new Book(){Id = 1, Title = "Dragon Ball", Author = "Toriyama"},
                new Book(){Id = 2, Title = "Lord of the Ring", Author = "Tolkien"},
                new Book(){Id = 3, Title = "Naruto", Author = "Kishimoto"},
                new Book(){Id = 4, Title = "One Piece", Author = "Oda"},
                new Book(){Id = 5, Title = "Berserk", Author = "Miura"},
            };
        }
    }
}
