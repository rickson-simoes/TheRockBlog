using Blog.DTOS.Post;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostScreen
{
    public class PostScreenGetOneCategory
    {
        private readonly SqlConnection _connection;

        public PostScreenGetOneCategory(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Get()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Get all Posts choosing one category.");
            Console.WriteLine("---------------------------------\n");

            Repository<Category> categoryRepository = new Repository<Category>(_connection);
            var categories = categoryRepository.Get();

            foreach (var category in categories)
            {
                Console.WriteLine($"Id: {category.Id} - {category.Name}");
                Console.WriteLine($"---------------");
            }
            Console.Write("\nChoose one category ID to list all posts with that: ");
            int.TryParse(Console.ReadLine(), out int categoryId);

            if (categoryId == 0)
            {
                return;
            }

            PostRepository postRepository = new PostRepository(_connection);

            IEnumerable<PostGetOneCategoryDto> posts = postRepository.GetPostsFromOneCategory(categoryId);
            Console.Clear();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post Title: {post.Title} - ({post.Date})");
                Console.WriteLine($"Post Body: {post.Body}");
                Console.WriteLine($"---------------\n");
            }

            Console.WriteLine("\nPress any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
