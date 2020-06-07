using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using eRecept.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eRecept.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public List<User> getAllUsers()
        {
            return _userRepository.getAllUsers();
        }

        public User getUser(int id)
        {
            //TODO: get a user by its id
            return _userRepository.getUser(id);
        }

        public void deleteUser(int id)
        {
            //TODO: delete a specific user from database
             _userRepository.deleteUser(id);
        }

        public void saveUser(User user)
        {
            //TODO: save the user
            _userRepository.insertUser(user);
        }


        [HttpPost("/login")]
        public bool CheckUser(string username, string password)
        {
            List<User> allUsers = getAllUsers();

            for (int i = 0; i < allUsers.Count(); i++)
            {
                if (allUsers[i].Username.Equals(username) && allUsers[i].Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost("/register")]
        public bool CheckRegister(string username, string email, string password, string repeatPassword)
        {
            List<User> allUsers = getAllUsers();

            for (int i = 0; i < allUsers.Count(); i++)
            {
                if (allUsers[i].Username==username)
                {
                    //postoji vec jedan sa istim username-om
                    return false;
                }
            }

            if (!password.Equals(repeatPassword)) return false; //ne podudaraju se pass

            _userRepository.insertUser(new User(0, null, null, username, password, email, null, null, 0));
            return true;

        }





    }
}
