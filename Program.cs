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
            // note.: I can provide a static prop to receive the connection here
            // this will avoid the use of ctor connection property
            // and use it straight to the db connections instead.

            using var connection = new SqlConnection(CONNECTION_STRING);

            new Principal(connection).Main();
        }        
    }
}
