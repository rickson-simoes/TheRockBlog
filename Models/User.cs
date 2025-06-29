﻿using Blog.Interfaces;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]
    public class User : IEntity
    {
        public User() => Roles = new List<Role>();
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Slug { get; set; }

        [Write(false)] // Prevents Dapper from trying to write this property to the database
        public List<Role> Roles { get; set; }
    }
}
