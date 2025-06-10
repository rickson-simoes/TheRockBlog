using Blog.DTOS.Category;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(SqlConnection connection) : base(connection) { }

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
