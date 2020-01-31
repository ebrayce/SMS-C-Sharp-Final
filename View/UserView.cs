using SMS.Controller;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.View
{
    class UserView
    {

        public static User addUser(String name, String username, String password)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Name    = name
            };

            user = UsersController.createUser(user);

            return user;


        }
    }
}
