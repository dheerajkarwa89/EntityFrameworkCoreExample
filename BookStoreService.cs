using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample
{
    internal class BookStoreService
    {
        private readonly BookStoreContext _context;

        public BookStoreService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<BookAuthorDto>> GetBooksWithAuthorsAsync()
        {
            var booksWithAuthors = await (from book in _context.Books
                                          join author in _context.Authors
                                          on book.AuthorId equals author.AuthorId
                                          select new BookAuthorDto
                                          {
                                              BookTitle = book.Title,
                                              AuthorName = author.Name
                                          }).ToListAsync();

            return booksWithAuthors;
        }
    }

    public class BookAuthorDto
    {
        public string BookTitle { get; set; }

        public string AuthorName { get; set; }
    }
}
