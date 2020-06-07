﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class User
    {
        public User(int userId, string name, string lastName, string username, string password, string mail, string address, string country, int userRole)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            Username = username;
            Password = password;
            Mail = mail;
            Address = address;
            Country = country;
            UserRole = userRole;
            //SavedRecipes = savedRecipes;
        }
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Mail { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Country { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(1)")]
        public int UserRole { get; set; }
       // public List<Recipe> SavedRecipes { get; set; }
    }
}
