using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostScreen
{
    public class PostScreenCreation
    {
        private readonly SqlConnection _connection;

        public PostScreenCreation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create()
        {
            // code
        }
    }
}
