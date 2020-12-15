using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public string getAllBooks()
        {
            return "All books";
        }

        public string getBook(int id)
        {
            return $"book with id = {id}";
        }

        public string searchBooks(string name, string author)
        {
            return $"Book with name = {name} and author = {author}";
        }
    }
}
