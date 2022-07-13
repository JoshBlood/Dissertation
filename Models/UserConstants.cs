using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "josh_admin", EmailAddress = "finchironacc@gmail.com", Password =
                "Password1", GivenName = "Josh", Surname = "Bloodworth", Role = "Administrator", UserId = 1 },
            new UserModel() { Username = "josh_student", EmailAddress = "student@gmail.com", Password =
                "Password1", GivenName = "Test", Surname = "Learner", Role = "Student", UserId = 2 },
        };
    }
}
