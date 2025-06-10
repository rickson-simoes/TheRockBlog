using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen
{
    public class UserScreenCreation
    {
        private readonly SqlConnection _connection;
        public UserScreenCreation(SqlConnection connection)
        {
            _connection = connection;
        }
        public void Create()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: User creation");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("\n To create an user we are going to need a few informations");
            var name = InputHelpers.NotNullOrWhiteSpace("Name");
            var email = InputHelpers.NotNullOrWhiteSpace("E-mail");
            var pwd = InputHelpers.NotNullOrWhiteSpace("Password");
            var bio = InputHelpers.NotNullOrWhiteSpace("Please talk a bit about you (BIO)");

            var slug = name.ToLower().Replace(" ", "") + "#" + InputHelpers.MathRandomNumber(10000, 99999);

            var userRepository = new UserRepository(_connection);
            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = pwd,
                Bio = bio,
                Image = "https//ImageNotNecessary",
                Slug = slug
            };


            try
            {
                userRepository.Create(user);
                Console.WriteLine("======================");
                Console.WriteLine("User Created.");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Whoops... {err.Message}");
            }

            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
