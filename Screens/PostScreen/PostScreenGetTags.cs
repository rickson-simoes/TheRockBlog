using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.PostScreen
{
    public class PostScreenGetTags
    {
        private readonly SqlConnection _connection;

        public PostScreenGetTags(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Get()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: List all posts with all their tags.");
            Console.WriteLine("---------------------------------");

            var postRepository = new PostRepository(_connection);
            var posts = postRepository.GetAllPostsWithTags();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post Title: {post.Title} - ({post.CreateDate})");
                Console.WriteLine($"Post Tag: {string.Join(", ", post.Tags.Select(t => t.Name)) + '.'}\n");
                Console.WriteLine($"Post Body: {post.Body}");
                Console.WriteLine($"---------------\n");
            }

            Console.WriteLine("\nPress any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
