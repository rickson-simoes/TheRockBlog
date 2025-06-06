using Blog.DTOS.Category;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.CategoryScreen
{
    public class CategoryScreenGetPostCount
    {
        private readonly SqlConnection _connection;
        public CategoryScreenGetPostCount(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Get()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: List all categories and the count of each one.");
            Console.WriteLine("---------------------------------\n");

            var categoryRepository = new CategoryRepository(_connection);
            IEnumerable<CategoryPostCountDto> categoriesPosts = categoryRepository.GetCategoryPostCount();

            if (categoriesPosts == null || categoriesPosts.Count() == 0)
            {
                Console.WriteLine("No categories yet. Type any button to return");
                Console.ReadLine();
                return;
            }

            foreach (var catPost in categoriesPosts)
            {
                Console.WriteLine($"Category: {catPost.Name} - Counting: {catPost.Amount}");
                Console.WriteLine("-------------");
            }

            Console.WriteLine("\nPress any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
