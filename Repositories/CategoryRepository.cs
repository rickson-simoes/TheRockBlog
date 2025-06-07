using Blog.DTOS.Category;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<CategoryPostCountDto> GetCategoryPostCount()
        {
            var query = @"SELECT TOP (1000) [C].[Name], COUNT([C].[Name]) as Quantity
                          FROM [Category] as C LEFT JOIN [Post] as P ON
                          [C].[Id] = [P].[CategoryId] group by [C].[Name];";

            var QConnection = _connection.Query<CategoryPostCountDto>(query);

            return QConnection;
        }
    }
}
