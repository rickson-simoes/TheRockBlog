using Blog.Interfaces;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category : IEntity
    {
        public Category()
        {
            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        [Write(false)] // Prevents Dapper from trying to write this property to the database
        public List<Post> Posts { get; set; }
    }
}
