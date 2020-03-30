using BookReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewService
{
    class BookOperationService : IBookOperationService
    {
        Book operationFailed = null;
        public Book AddBook(Book book)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var newBook = new Book()
                    {
                        Author = book.Author,
                        BookName = book.BookName,
                        Category = book.Category,
                        Description = book.Description,
                        OverrallRating = book.OverrallRating,
                        PublishedYear = book.PublishedYear,
                        Publisher = book.Publisher
                    };
                    context.Books.Add(newBook);
                    int row = context.SaveChanges();
                    if(row != 0)
                    {
                        return newBook;
                    }
                    else
                    {
                        return operationFailed;
                    }
                }
            }
            catch(Exception)
            {
                return operationFailed;
            }
           
        }

        public List<Book> FindBookByName(string query)
        {
            List<Book> notFoundAny = null;
            using(DatabaseContext context = new DatabaseContext())
            {
                var list = context.Books.Where(m => m.BookName.Contains(query)).ToList();
                if (!list.Any())
                {
                    return notFoundAny;
                }
                return list;
            }
        }

        public List<Book> GetBooks()
        {
            List<Book> notFoundAnyBooks = null;
            using(DatabaseContext context = new DatabaseContext())
            {
                var bookList = context.Books.ToList();
                if(!bookList.Any())
                {
                    return notFoundAnyBooks;
                }
                return bookList;
            }
        }
    }
}
