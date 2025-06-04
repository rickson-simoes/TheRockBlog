using Blog.Helpers;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

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

            Console.WriteLine("\n Assign an user to a role by choosing an user and a type of role.");

            var users = new UserRepository(_connection);
            var roles = new Repository<Role>(_connection);

            User selectedUser = SelectUser(users);

            if (selectedUser.Id == 0)
            {
                return;
            }

            SelectRole(roles, selectedUser);

            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }

        private User SelectUser(UserRepository UserRepository)
        {
            var name = InputHelpers.NotNullOrWhiteSpace("Name");
            var users = UserRepository.GetUsersByName(name);

            users = CheckUsers(users, name);

            if (users.IsNullOrEmpty())
            {
                return new User();
            }

            User userSelected = UserSelection(users);

            if (userSelected == null || userSelected.Id == 0)
            {
                return new User();
            }

            int userIdSelected = userSelected.Id;

            Console.Clear();
            Console.WriteLine($"User to be assigned:");
            Console.WriteLine($"Name: {userSelected.Name}");
            Console.WriteLine($"Email:{userSelected.Email}");
            Console.WriteLine("\nPress any button to move forward with the assignment.");
            Console.ReadLine();
            Console.Clear();

            return userSelected;
        }

        private User UserSelection(IEnumerable<User> users)
        {
            User? userSelected = UserList(users);

            while (userSelected == null)
            {
                Console.Clear();
                Console.WriteLine("That ID does not exist in the list. Please choose any ID that is shown in the list.");
                Console.WriteLine("If you want to leave this action just type 0. \n");
                userSelected = UserList(users);
            }

            return userSelected;
        }

        private User? UserList(IEnumerable<User> users)
        {
            Console.WriteLine("============================================================");
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id} - User: {user.Name} - Email: {user.Email}");
            }
            Console.WriteLine("============================================================");
            Console.WriteLine();

            Console.Write("Please choose the user ID to which you want to assign a role: ");
            int.TryParse(Console.ReadLine(), out int userId);
            if (userId == 0)
            {
                return new User { Id = 0};
            }
            User userSelected = users.FirstOrDefault(usr => usr.Id == userId);

            return userSelected;
        }

        private void SelectRole(Repository<Role> RoleRepository, User user) 
        {
            Console.WriteLine("Now select the type of role");
            var roles = RoleRepository.Get();

            Console.WriteLine("============================================================");
            foreach (var role in roles)
            {
                Console.WriteLine($"Id: {role.Id} - Name: {role.Name}");
            }
            Console.WriteLine("============================================================");
            Console.Write("Please choose the Role ID: ");
            int.TryParse(Console.ReadLine(), out int roleId);
            Role roleSelected = roles.FirstOrDefault(role => role.Id == roleId);
            
            if(roleSelected == null)
            {
                return;
            }

            int roleIdSelected = roleSelected.Id;

            Console.Clear();
            Console.WriteLine($"User: {user.Name} - Id: {user.Id} ");
            Console.WriteLine($"Role: {roleSelected.Name} - Id: {roleSelected.Id} ");
            Console.Write("\nPlease press 1 to continue or any button to leave this action: ");
            int.TryParse(Console.ReadLine(), out int inputOption);
            if (inputOption == 1)
            {
                UserRole userRole = new UserRole { RoleId = roleIdSelected, UserId = user.Id };

                var userRoles = new UserRoleRepository(_connection);
                userRoles.Create(userRole);
            }
        }

        private IEnumerable<User> CheckUsers(IEnumerable<User> users, string name)
        {
            while (users.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("No users with that name, try again or type 0 to return to main.");
                name = InputHelpers.NotNullOrWhiteSpace("Name");

                if (name == "0")
                    return Enumerable.Empty<User>();

                users = new UserRepository(_connection).GetUsersByName(name);
            }

            return users;
        }

    }
}
