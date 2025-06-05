using Blog.Repositories;
using Microsoft.Data.SqlClient;

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
            string userInfo = "";

            foreach (var user in users)
            {
                var getRolesCount = user.Roles.Count;
                userInfo += user.Name + ", ";
                userInfo += user.Email;

                if (user.Roles.Count != 0)
                {
                    userInfo += " | " + (getRolesCount > 1 ? "Roles: " : "Role: ");
                    var allRoles = user.Roles.Select(f => f.Name);
                    userInfo += string.Join(", ", allRoles) + '.';
                }

                Console.WriteLine(userInfo);
                Console.WriteLine($"====================================");
                userInfo = "";
            }

            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
