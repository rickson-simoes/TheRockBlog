using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.CategoryScreen
{
    public class CategoryScreenCreation
    {
        private readonly SqlConnection _connection;
        public CategoryScreenCreation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Create a Category.");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("\nProvide a name for the new category that you want to create");

            var name = InputHelpers.NotNullOrWhiteSpace("Name");
            var slug = name.Trim().ToLower().Replace(" ","-");

            Category category = new Category { 
                Name = name,
                Slug = slug
            };

            var dbCategory = new Repository<Category>(_connection);

            dbCategory.Create(category);
            Console.WriteLine("======================");
            Console.WriteLine("Category Created.");
            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
