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
            Console.WriteLine("1 - Create an User");
            Console.WriteLine("=================================");
            var opt = Console.ReadLine();
            var readOpt = int.TryParse(opt, out int optSelected);

            Console.Clear();
            switch(optSelected)
            {
                case 1:
                    var userCreation = new Create(_connection);
                    userCreation.User();
                    Main();
                    break;
            }            
        }
    }
}
