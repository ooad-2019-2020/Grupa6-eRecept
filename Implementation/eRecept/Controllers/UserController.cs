using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using Microsoft.AspNetCore.Mvc;

namespace eRecept.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<User> getAllUsers()
        {
            List<User> returnList = new List<User>();
            //TODO: get all users
            return returnList;
        }

        public User getUser(int id)
        {
            //TODO: get a user by its id
            return null;
        }

        public void deleteUser(int id)
        {
            //TODO: delete a specific user from database
        }

        public void saveUser(User user)
        {
            //TODO: save the user
        }








    }
}
