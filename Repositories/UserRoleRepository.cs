using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Blog.Models;

namespace Blog.Repositories
{
    public class UserRoleRepository
    {
        public readonly SqlConnection _connection;
        public UserRoleRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(UserRole userRole)
        {
            _connection.Insert<UserRole>(userRole);
        }
    }
}
