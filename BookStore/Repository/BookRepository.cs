﻿using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> addNewBook(Book model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

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
                new Book(){Id = 1, Title = "Dragon Ball", Author = "Toriyama", Description = "Display short description of Book 1", Category = "Action", Language = "English", TotalPages = 120}, 
                new Book(){Id = 2, Title = "Lord of the Ring", Author = "Tolkien", Description = "Display short description of Book 2", Category = "Fantasy", Language = "English", TotalPages = 400},
                new Book(){Id = 3, Title = "Naruto", Author = "Kishimoto", Description = "Display short description of Book 3", Category = "Action", Language = "Japan", TotalPages = 140},
                new Book(){Id = 4, Title = "One Piece", Author = "Oda", Description = "Display short description of Book 4", Category = "Adventure", Language = "English", TotalPages = 120},
                new Book(){Id = 5, Title = "Berserk", Author = "Miura", Description = "Display short description of Book 5", Category = "Fantasy", Language = "English", TotalPages = 200},
            };
        }
    }
}
