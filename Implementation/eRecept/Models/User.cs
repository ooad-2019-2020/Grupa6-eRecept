using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class User
    {

        private int userId;
        private string name;
        private string lastName;
        private string mail;
        private string address;
        private string country;
        private int userRole;
        private List<Recipe> savedRecipes;

        public User(int userId, string name, string lastName, string mail, string address, string country, int userRole, List<Recipe> savedRecipes)
        {
            this.userId = userId;
            this.name = name;
            this.lastName = lastName;
            this.mail = mail;
            this.address = address;
            this.country = country;
            this.userRole = userRole;
            this.savedRecipes = savedRecipes;
        }

        public int UserId { get => userId; set => userId = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Address { get => address; set => address = value; }
        public string Country { get => country; set => country = value; }
        public int UserRole { get => userRole; set => userRole = value; }
        public List<Recipe> SavedRecipes { get => savedRecipes; set => savedRecipes = value; }
    }
}
