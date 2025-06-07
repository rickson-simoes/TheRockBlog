using Blog.DTOS.Tag;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository
    {
        private readonly SqlConnection _connection;

        public TagRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TagPostCountDto> GetTagPostCount()
        {
            var query = @"SELECT T.Name, Count(P.Id) as Quantity FROM [Blog].[dbo].[Tag] AS T 
                        INNER JOIN [PostTag] AS PT ON
                        T.Id = PT.TagId
                        INNER JOIN [Post] as P ON
                        PT.PostId = P.Id
                        group by T.Name;";

            var QConnection = _connection.Query<TagPostCountDto>(query);

            return QConnection;
        }
    }
}
