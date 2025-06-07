using Blog.DTOS.Post;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<PostGetOneCategoryDto> GetPostsFromOneCategory(int categoryId)
        {
            var query = @"SELECT [Title]
                        ,[Body]
                        ,[CreateDate] as Date
                        FROM [Blog].[dbo].[Post] where CategoryId = @CategoryId";

            var QConnection = _connection.Query<PostGetOneCategoryDto>(query, new { CategoryId = categoryId });

            return QConnection;
        }

        public IEnumerable<PostCategoryDto> GetAllPostsWithCategory()
        {
            var query = @"SELECT C.Name, P.Title, P.Body, P.CreateDate as [Date] FROM [Blog].[dbo].[Post] as P
                          LEFT JOIN Category as C on
                          p.CategoryId = C.Id;";

            var QConnection = _connection.Query<PostCategoryDto>(query);

            return QConnection;
        }
    }
}
