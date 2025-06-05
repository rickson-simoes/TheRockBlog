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
        
    }
}
