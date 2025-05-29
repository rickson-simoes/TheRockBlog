using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<User> GetWithRoles()
        {
            var query = @"SELECT U.*, R.* FROM [Blog].[dbo].[User] as U
                            left join [UserRole] as URole on
                            URole.UserId = U.Id

                            left join [Role] as R on
                            URole.RoleId = R.Id;";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(query, (user, role) =>
            {
                var usr = users.FirstOrDefault(u => u.Id == user.Id);

                if(usr == null)
                {
                    usr = user;
                    users.Add(usr);
                }

                if(role != null)
                    usr.Roles.Add(role);

                return user;
            }, splitOn: "Id");

            return users;
        }
        public IEnumerable<User> GetUsersByName(string name)
        {
            var query = "SELECT [Id], [Name], [Email] FROM [User] WHERE [Name] like @username;";

            IEnumerable<User> users = _connection.Query<User>(query, new { username = $"%{name}%" });

            return users;
        }
    }
}
