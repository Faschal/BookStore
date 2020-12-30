using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;   
        }
        public ViewResult getAllBooks()
        {
            var data = _bookRepository.getAllBooks();

            return View(data);
        }

        [Route("book-detail/{id}", Name = "book.detail")]
        public ViewResult getBook(int id)
        {
            var data = _bookRepository.getBookById(id);

            return View(data);
        }

        public List<Book> searchBooks(string name, string author)
        {
            return _bookRepository.searchBook(name, author);
        }

        public ViewResult addBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addBook(Book book)
        {
            int id = await _bookRepository.addNewBook(book);
            if(id > 0)
            {
                return RedirectToAction(nameof(addBook), new { isSuccess = true, bookId = id });
            }
            return View();
        }
    }
}
