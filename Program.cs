using Blog.Models;
using Blog.Repositories;
using Blog.Screens.MainScreen;
using Microsoft.Data.SqlClient;

namespace Blog
{  
    public class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;
                                                    Database=blog;
                                                    User ID=sa;
                                                    Password=a1b2c3d4#@!;
                                                    TrustServerCertificate=True;";

        static void Main()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            var screen = new Principal(connection);
            screen.Main();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var userRepository = new Repository<User>(connection);
            var users = userRepository.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Slug);
                Console.WriteLine("============================");
            }           
        }
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var userRepository = new UserRepository(connection);
            var users = userRepository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"PasswordHash: {user.PasswordHash}");
                Console.WriteLine($"Bio: {user.Bio}");
                Console.WriteLine($"Image: {user.Image}");
                Console.WriteLine($"Slug: {user.Slug}");
                foreach (var role in user.Roles)
                {                    
                    Console.WriteLine($"Role Id: {role.Id}");
                    Console.WriteLine($"Role Name: {role.Name}");
                    Console.WriteLine($"Role Slug: {role.Slug}");                    
                }
                Console.WriteLine($"====================================");
            }
        }
    }
}
