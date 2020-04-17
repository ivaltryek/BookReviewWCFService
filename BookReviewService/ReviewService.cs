using BookReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace BookReviewService
{
    class ReviewService : IReviewService
    {
        public int CountBookReviewScore(string BookName)
        {
            int points = 0;
            int totals = 0;
            using(DatabaseContext context = new DatabaseContext())
            {
                List<Review> reviews = context.Reviews.Where(q => q.ReviewOn == BookName).ToList();
                foreach(var r in reviews)
                {
                    points += r.ReviewScale;
                    totals += 1;
                }
                Book book = context.Books.Where(p => p.BookName == BookName).FirstOrDefault();
                if(book.OverrallRating != points) 
                {
                    book.OverrallRating = points;
                    context.SaveChanges();
                }

                return points;
            }
        }

        public int DeleteReview(string reviewOn, string currentUser)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var reviewRecord = context.Reviews.Where(r => r.ReviewOn == reviewOn && r.ReviewBy == currentUser).FirstOrDefault();
                    context.Reviews.Remove(reviewRecord);
                    int row = context.SaveChanges();
                    if (row != 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public Review DoesReviewExists(string currentUser, string reviewOn)
        {
            Review notFoundAnyExistsOne = null;
            using(DatabaseContext context = new DatabaseContext())
            {
                var review = context.Reviews.Where(w => w.ReviewOn == reviewOn && w.ReviewBy == currentUser).FirstOrDefault();
                if(review != null)
                {
                    return review;
                }
                else
                {
                    return notFoundAnyExistsOne;
                }
            }
        }

        public Review EditReview(string reviewOn, string currentUser, Review review)
        {
            Review operationFailed = null;
            int row = 0;
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var reviewRecord = context.Reviews.FirstOrDefault(r => r.ReviewOn == reviewOn && r.ReviewBy == currentUser);
                    if(reviewRecord != null)
                    {
                        reviewRecord.ReviewBy = currentUser;
                        reviewRecord.ReviewScale = review.ReviewScale;
                        reviewRecord.ReviewComment = review.ReviewComment;
                        row  = context.SaveChanges();
                       
                    }
                    if (row != 0)
                    {
                        return reviewRecord;
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

        public List<Review> GetBookReviews(string BookName)
        {
            List<Review> notFoundAnyReviews = null;
            try
            {
                using(DatabaseContext context  =  new DatabaseContext())
                {
                    var reviewList = context.Reviews.Where(r => r.ReviewOn == BookName).ToList();
                    if(!reviewList.Any())
                    {
                        return notFoundAnyReviews;
                    }
                    return reviewList;
                }
            }
            catch(Exception)
            {
                return notFoundAnyReviews;
            }
        }

        public List<Review> GetMyReviews(string currentUser)
        {
            List<Review> notFoundAnyList = null;
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var reviewList = context.Reviews.Where(x => x.ReviewBy == currentUser).ToList();
                    if (reviewList != null)
                    {
                        return reviewList;
                    }
                    else
                    {
                        return notFoundAnyList ;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString() + " ====> EXCEPTION");
                return notFoundAnyList;
            }

            
            
           
        }

        public Review SetReview(Review review)
        {
            Review operationFailed = null;
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var newReview = new Review()
                    {
                        ReviewBy = review.ReviewBy,
                        ReviewComment = review.ReviewComment,
                        ReviewOn = review.ReviewOn,
                        ReviewScale = review.ReviewScale
                    };
                    context.Reviews.Add(newReview);
                    int row = context.SaveChanges();
                    if( row != 0)
                    {
                        return newReview;
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
    }
}
