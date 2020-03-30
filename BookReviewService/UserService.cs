using BookReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookReviewService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        public User LoginUser(string email, string password)
        {
           using(DatabaseContext databaseContext = new DatabaseContext())
            {
                User user = databaseContext.Users.Where(u => u.UserEmail == email && u.UserPassword == password).FirstOrDefault();
                if(user !=null)
                {
                    return user;
                }
                else
                {
                    User notFoundUserData = null;
                    return notFoundUserData;
                }
                
            }
        }

        public void RegisterUser(User user)
        {
            using(DatabaseContext databaseContext = new DatabaseContext())
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserEmail = user.UserEmail,
                    UserName = user.UserName,
                    UserPassword = user.UserPassword
                };
                databaseContext.Users.Add(newUser);
                databaseContext.SaveChanges();
            }
        }
    }
}
