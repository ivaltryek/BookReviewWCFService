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

        public Review EditReview(string reviewOn, string currentUser, Review review)
        {
            Review operationFailed = null;
            int row = 0;
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var reviewRecord = context.Reviews.SingleOrDefault(r => r.ReviewOn == reviewOn && r.ReviewBy == currentUser);
                    if(reviewRecord != null)
                    {
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

        public List<Review> GetMyReviews(string currentUser)
        {
            List<Review> notFoundAnyList = null;
            Review r = null;
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
