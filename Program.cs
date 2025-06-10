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

            new Principal(connection).Main();
        }        
    }
}
