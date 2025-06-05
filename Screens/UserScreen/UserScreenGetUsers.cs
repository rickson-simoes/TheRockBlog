using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System.Text;

namespace Blog.Screens.UserScreen
{
    public class UserScreenGetUsers
    {
        private readonly SqlConnection _connection;
        public UserScreenGetUsers(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Get()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: List users and their roles.");
            Console.WriteLine("---------------------------------");

            var userRepository = new UserRepository(_connection);
            var users = userRepository.GetWithRoles();
            StringBuilder sBuilder = new StringBuilder();

            foreach (var user in users)
            {
                var getRolesCount = user.Roles.Count;
                sBuilder.Append(user.Name + ", ");
                sBuilder.Append(user.Email);

                if (user.Roles.Count != 0)
                {
                    sBuilder.Append(" | " + (getRolesCount > 1 ? "Roles: " : "Role: "));
                    var allRoles = user.Roles.Select(f => f.Name);
                    sBuilder.Append(string.Join(", ", allRoles) + '.');
                }

                Console.WriteLine(sBuilder.ToString());
                Console.WriteLine($"====================================");
                sBuilder.Clear();
            }

            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
