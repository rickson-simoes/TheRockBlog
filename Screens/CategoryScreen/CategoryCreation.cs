using Microsoft.Data.SqlClient;

namespace Blog.Screens.NewFolder
{
    public class CategoryCreation
    {
        private readonly SqlConnection _connection;
        public CategoryCreation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void CreateCategory()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Create a Category.");
            Console.WriteLine("---------------------------------");
        }
    }
}
