using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreen
{
    public class TagScreenCreation
    {
        private readonly SqlConnection _connection;
        public TagScreenCreation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Create a Tag.");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("\nProvide a name for the new tag that you want to create");

            var name = InputHelpers.NotNullOrWhiteSpace("Name");
            var slug = name.ToLower().Trim().Replace(' ', '-');

            Tag tag = new Tag
            {
                Name = name,
                Slug = slug
            };

            var dbTag = new Repository<Tag>(_connection);

            dbTag.Create(tag);
            Console.WriteLine("======================");
            Console.WriteLine("Tag Created.");
            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
