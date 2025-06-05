using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    internal class PostTagRepository
    {
        public readonly SqlConnection _connection;
        public PostTagRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(PostTag postTag)
        {
            _connection.Insert(postTag);
        }
    }
}
