using eRecept.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Users")]
    public class UserRepository:DbContext
    {

        UserRepository() { }

        public UserRepository(DbContextOptions<UserRepository> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }



        public List<User> getAllUsers()
        {
            return new List<User>(this.Users);
        }

        public User getUser(int id)
        {
            return this.Users.Find(id);
        }

        public void insertUser(User user)
        {

            this.Add(user);
            this.SaveChanges();
            //TODO: insert a user to the database
        }

        public void deleteUser(int id)
        {
            this.Remove(id);
            //TODO: delete a specific user from database
        }

        public void updateUser(User user)
        {
            this.Update(user);
            //TODO: update the user by its id
        }


    }
}