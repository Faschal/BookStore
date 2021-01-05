using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> getAllBooks()
        {
            var data = await _bookRepository.getAllBooks();

            return View(data);
        }

        [Route("book-detail/{id}", Name = "book.detail")]
        public async Task<ViewResult> getBook(int id)
        {
            var data = await _bookRepository.getBookById(id);

            return View(data);
        }

        public List<Book> searchBooks(string name, string author)
        {
            return _bookRepository.searchBook(name, author);
        }

        public async Task<ViewResult> addBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new Book()
            {
                //Language = "2"
            };

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
          
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> addBook(Book book)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.addNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(addBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }
        
    }
}
