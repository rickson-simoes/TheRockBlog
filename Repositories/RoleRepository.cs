using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(SqlConnection connection) : base(connection) { }
    }
}
