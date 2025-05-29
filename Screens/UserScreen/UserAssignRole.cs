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
                Console.WriteLine($"User: {user.Name} - Email: {user.Email} - Id: {user.Id}");
                Console.WriteLine($"---");
            }
            Console.WriteLine("============================================================");
            Console.WriteLine();

            Console.Write("Please choose the user ID which you want to assign a role: ");
            var isInputValid = int.TryParse(Console.ReadLine(), out int userId);
            User userChoosen = users.First(usr => usr.Id == userId);
            int userChoosenId = userChoosen.Id;

            Console.Clear();
            Console.WriteLine("User to be assigned:");
            Console.WriteLine($"{userChoosen.Name}");
            Console.WriteLine($"{userChoosen.Email}");
            Console.WriteLine($"{userChoosen.Bio}");
            Console.WriteLine($"{userChoosen.Slug}");
            Console.WriteLine($"-------------------");
            Console.WriteLine();

            //Console.WriteLine("Now select the type of role");
            // fazer um get all de todas as roles mostrando em um foreach o id e o nome da role
            // e assim fazer o insert na tabela associativa UserRole com os ids.

            // code

            //Console.WriteLine("======================");
            //Console.WriteLine("User bounded with success.");
            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
