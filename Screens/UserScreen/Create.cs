using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen
{
    public class Create
    {
        private readonly SqlConnection _connection;
        public Create(SqlConnection connection)
        {
            _connection = connection;
        }
        public void User()
        {
            Console.WriteLine("To create an user we are going to need a few informations");
            string name = InputHelpers.NotNullOrWhiteSpace("Name");
            var email = InputHelpers.NotNullOrWhiteSpace("E-mail");
            var pwd = InputHelpers.NotNullOrWhiteSpace("Password");            
            var bio = InputHelpers.NotNullOrWhiteSpace("Please talk a bit about you (BIO):");

            var mathRandom = new Random();
            var slug = name.ToLower().Replace(" ", "-") + "#" + mathRandom.Next(10000, 99999);

            var userRepository = new Repository<User>(_connection);
            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = pwd,
                Bio = bio,
                Image = "https//ImageNotNecessary",
                Slug = slug
            };

            userRepository.Create(user);
            Console.WriteLine("======================");
            Console.WriteLine("User Created.");
            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
        }
    }
}
