using Blog.DTOS.Post;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

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
        public List<Post> GetAllPostsWithTags()
        {
            var query = @"SELECT P.*, T.* FROM [Blog].[dbo].[Post] as P
                            left join PostTag as PT on
                            PT.PostId = p.Id

                            left join Tag as T on
                            PT.TagId = T.Id;";

            var posts = new List<Post>();
            var QConnection = _connection.Query<Post, Tag, Post>(query, (postRow, tagRow) =>
            {
                var post = posts.FirstOrDefault(p => p.Id == postRow.Id);

                if (post == null)
                {
                    post = postRow;
                    posts.Add(post);
                }

                if (tagRow != null)
                    post.Tags.Add(tagRow);

                return postRow;
            }, splitOn: "Id");

            return posts;
        }
    }
}
