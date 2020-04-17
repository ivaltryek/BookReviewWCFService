using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BookReviewService.Models;

namespace BookReviewService
{
    [ServiceContract]
    public interface IReviewService
    {
        [OperationContract]
        Review SetReview(Review review);
        [OperationContract]
        List<Review> GetMyReviews(string currentUser);
        [OperationContract]
        Review EditReview(string reviewOn, string currentUser, Review review);
        [OperationContract]
        int DeleteReview(string reviewOn, string currentUser);
        [OperationContract]
        int CountBookReviewScore(string BookName);
        [OperationContract]
        List<Review> GetBookReviews(string BookName);
        [OperationContract]
        Review DoesReviewExists(string currentUser, string reviewOn);
    }
}
