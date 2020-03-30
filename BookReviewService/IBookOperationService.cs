using BookReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewService
{
    [ServiceContract]
    public interface IBookOperationService
    {
        [OperationContract]
        Book AddBook(Book book);
        [OperationContract]
        List<Book> GetBooks();
        [OperationContract]
        List<Book> FindBookByName(string query);
    }
}
