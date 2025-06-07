using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.PostScreen
{
    public class PostScreenGetCategories
    {
        private readonly SqlConnection _connection;

        public PostScreenGetCategories(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Get()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: List all posts with categories.");
            Console.WriteLine("---------------------------------\n");

            var postRepository = new PostRepository(_connection);
            var posts = postRepository.GetAllPostsWithCategory();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post Title: {post.Title} - ({post.Date})");
                Console.WriteLine($"Post Category: {post.Name}\n");
                Console.WriteLine($"Post Body: {post.Body}");
                Console.WriteLine($"---------------\n");
            }

            Console.WriteLine("\nPress any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
