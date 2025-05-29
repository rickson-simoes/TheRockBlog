using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen
{
    public class UserAssignRole
    {
        private readonly SqlConnection _connection;
        public UserAssignRole(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Assign()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Assign user to a role");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Say the name of the user to be assigned with a role");
            Console.WriteLine("and we will show you a list of ids and names if possible:");
            var name = InputHelpers.NotNullOrWhiteSpace("Name");
            var users = new UserRepository(_connection).GetUsersByName(name);

            while (users.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("Whoops... seems like there's no users with that name.");
                Console.WriteLine("Want to try again? If no type 0 to return to main.");
                name = InputHelpers.NotNullOrWhiteSpace("Name");

                if (name == "0")
                    return;

                users = new UserRepository(_connection).GetUsersByName(name);
            }

            Console.WriteLine("============================================================");
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id} - User: {user.Name} - Email: {user.Email}");
                Console.WriteLine($"---");
            }
            Console.WriteLine("============================================================");
            Console.WriteLine();

            Console.Write("Please choose the user ID which you want to assign a role: ");
            int.TryParse(Console.ReadLine(), out int userId);
            User userSelected = users.First(usr => usr.Id == userId);
            int userIdSelected = userSelected.Id;

            Console.Clear();
            Console.WriteLine("User to be assigned:");
            Console.WriteLine($"{userSelected.Name}");
            Console.WriteLine($"{userSelected.Email}");
            Console.WriteLine($"{userSelected.Bio}");
            Console.WriteLine($"{userSelected.Slug}");
            Console.WriteLine();
            Console.WriteLine("Now select the type of role");
            var roles = new Repository<Role>(_connection).Get();

            Console.WriteLine("============================================================");
            foreach (var role in roles)
            {
                Console.WriteLine($"Id: {role.Id} - Name: {role.Name}");
            }
            Console.WriteLine("============================================================");
            Console.Write("Please choose the Role ID: ");
            int.TryParse(Console.ReadLine(), out int roleId);
            Role roleSelected = roles.First(role => role.Id == roleId);
            int roleIdSelected = roleSelected.Id;

            Console.WriteLine("======================");
            Console.WriteLine($"User: {userSelected.Name} - Id: {userSelected.Id} ");
            Console.WriteLine($"Role: {roleSelected.Name} - Id: {roleSelected.Id} ");
            Console.WriteLine("Please press 1 to continue or any button to leave this action.");
            int.TryParse(Console.ReadLine(), out int inputOption);
            if (inputOption == 1)
            {
                UserRole userRole = new UserRole { RoleId = roleIdSelected, UserId = userIdSelected };

                var userRoles = new UserRoleRepository(_connection);
                userRoles.Create(userRole);

                Console.WriteLine("======================");
                Console.WriteLine($"User: {userSelected.Name} assigned to the role: {roleSelected.Name}.");
                Console.WriteLine("Press any button to return to main screen.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
