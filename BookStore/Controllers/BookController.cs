using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
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
                if (book.CoverFoto != null)
                {
                    string folder = "books/cover/";
                    book.CoverImageUrl = await UploadImage(folder, book.CoverFoto);
                }

                if (book.GalleryFiles != null)
                {
                    string folder = "books/gallery/";
                    book.Gallery = new List<GalleryModel>();

                    foreach (var file in book.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file),
                        };

                        book.Gallery.Add(gallery);                        
                    }
                    
                }

                int id = await _bookRepository.addNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(addBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {            
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;            

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
