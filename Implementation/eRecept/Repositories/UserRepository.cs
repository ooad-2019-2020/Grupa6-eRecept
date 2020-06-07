using eRecept.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    public class UserRepository:DbContext
    {

        private static UserRepository instance = null;
        private static readonly object padlock = new object();

        UserRepository() { }

        public UserRepository(DbContextOptions<UserRepository> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }



        public static UserRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                    return instance;
                }
            }
        }

        public List<User> getAllUsers()
        {
            List<User> returnList = new List<User>();
            //TODO: get all users from database
            return returnList;
        }

        public User getUser(int id)
        {
            //TODO: get a user from the database by its id
            return null;
        }

        public void insertUser(User user)
        {
            //TODO: insert a user to the database
        }

        public void deleteUser(int id)
        {
            //TODO: delete a specific user from database
        }

        public void updateUser(User user)
        {
            //TODO: update the user by its id
        }


    }
}