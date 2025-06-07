using Blog.DTOS.Tag;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreen
{
    public class TagScreenGetPostCount
    {
        private readonly SqlConnection _connection;
        public TagScreenGetPostCount(SqlConnection connection) => _connection = connection;

        public void Get()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: List all tags and the count of each one.");
            Console.WriteLine("---------------------------------\n");

            var tagRepository = new TagRepository(_connection);
            IEnumerable<TagPostCountDto> tagsPosts = tagRepository.GetTagPostCount();

            if (tagsPosts == null || tagsPosts.Count() == 0)
            {
                Console.WriteLine("No tags yet. Type any button to return");
                Console.ReadLine();
                return;
            }

            foreach (var tagPost in tagsPosts)
            {
                Console.WriteLine($"Tag: {tagPost.Name} - Counting: {tagPost.Quantity}");
                Console.WriteLine("-------------");
            }

            Console.WriteLine("\nPress any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
