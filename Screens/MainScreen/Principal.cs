using Blog.Screens.RoleScreen;
using Blog.Screens.UserScreen;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.MainScreen
{
    public class Principal
    {
        private readonly SqlConnection _connection;
        public Principal(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Main()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("Please choose an option");
            Console.WriteLine("1 - Create an User.");
            Console.WriteLine("2 - Create a Role.");
            Console.WriteLine("=================================");
            var opt = Console.ReadLine();
            var readOpt = int.TryParse(opt, out int optSelected);

            Console.Clear();
            switch(optSelected)
            {
                case 1:
                    var userCreation = new UserScreenCreation(_connection);
                    userCreation.Create();
                    Main();
                    break;
                case 2:
                    var roleCreation = new RoleScreenCreation(_connection);
                    roleCreation.Create();
                    Main();
                    break;
            }            
        }
    }
}
