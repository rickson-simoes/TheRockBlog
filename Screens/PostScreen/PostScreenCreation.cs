using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.PostScreen
{
    public class PostScreenCreation
    {
        private readonly SqlConnection _connection;

        public PostScreenCreation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Create a Post.");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("\nProvide a user id to create a post \n");

            var userRepository = new UserRepository(_connection);
            var categoryRepository = new CategoryRepository(_connection);

            User? user = userSelection(userRepository);
            if (user == null)
            {
                Console.WriteLine("User not found. Press any key to return to main menu.");
                Console.ReadLine();
                return;
            }

            Category? category = categorySelection(categoryRepository);

            if (category == null)
            {
                Console.WriteLine("Category not found. Press any key to return to main menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\n Post from the user: {user.Name} with selected category: {category.Name} \n");

            var title = InputHelpers.NotNullOrWhiteSpace("Title");
            var summary = InputHelpers.NotNullOrWhiteSpace("Summary");
            var body = InputHelpers.NotNullOrWhiteSpace("Body");
            var slug = title.Trim().Replace(" ", "-");

            Post postPayload = new Post
            {
                CategoryId = category.Id,
                AuthorId = user.Id,
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            var post = new PostRepository(_connection);

            try
            {
                post.Create(postPayload);
                Console.WriteLine("======================");
                Console.WriteLine("Post Created.");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Whoops... {err.Message}");
            }

            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }

        private User? userSelection(Repository<User> userRepository)
        {
            var users = userRepository.Get();

            Console.WriteLine("============================================================");
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id} - User: {user.Name} - Email: {user.Email}");
            }
            Console.WriteLine("============================================================");

            Console.Write("\nUser Id: ");
            int.TryParse(Console.ReadLine(), out int userId);
            var userSelected = users.FirstOrDefault(usr => usr.Id == userId);

            return userSelected;
        }
        private Category? categorySelection(Repository<Category> categoryRepository)
        {
            var categories = categoryRepository.Get();

            Console.WriteLine("============================================================");
            foreach (var user in categories)
            {
                Console.WriteLine($"Id: {user.Id} - User: {user.Name}");
            }
            Console.WriteLine("============================================================");

            Console.Write("\nCategory Id: ");
            int.TryParse(Console.ReadLine(), out int userId);
            var categorySelected = categories.FirstOrDefault(ctgry => ctgry.Id == userId);

            return categorySelected;
        }
    }
}
