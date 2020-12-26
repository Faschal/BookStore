﻿using System;
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
        private readonly BookRepository  bookRepository = null;
        
        public BookController()
        {
            bookRepository = new BookRepository();
        }
        public ViewResult getAllBooks()
        {
            var data = bookRepository.getAllBooks();

            return View(data);
        }

        [Route("book-detail/{id}", Name = "book.detail")]
        public ViewResult getBook(int id)
        {
            var data = bookRepository.getBookById(id);

            return View(data);
        }

        public List<Book> searchBooks(string name, string author)
        {
            return bookRepository.searchBook(name, author);
        }

        public ViewResult addBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult addBook(Book book)
        {
            return View();
        }
    }
}
