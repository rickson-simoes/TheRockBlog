using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;


namespace Blog.Screens.RoleScreen
{
    public class RoleScreenCreation
    {
        private readonly SqlConnection _connection;

        public RoleScreenCreation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Role creation");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("\n Create a role by providing the name and the slug");

            var name = InputHelpers.NotNullOrWhiteSpace("Name");
            var slug = InputHelpers.NotNullOrWhiteSpace("Slug");

            var role = new Role
            {
                Name = name,
                Slug = slug,
            };

            var roleRepository = new Repository<Role>(_connection);

            try
            {
                roleRepository.Create(role);
                Console.WriteLine("======================");
                Console.WriteLine("Role Created.");
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
