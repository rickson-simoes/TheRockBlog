using Blog.DTOS.Post;
using Blog.DTOS.Tag;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
