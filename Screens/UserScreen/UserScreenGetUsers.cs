using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen
{
    public class UserScreenGetUsers
    {
        private readonly SqlConnection _connection;
        public UserScreenGetUsers(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Get()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: List users and their roles.");
            Console.WriteLine("---------------------------------");

            var userRepository = new UserRepository(_connection);
            var users = userRepository.GetWithRoles();
            var infos = "";
            int count = 0;

            foreach (var user in users)
            {
                var getCount = user.Roles.Count;
                infos += user.Name + ", ";

                if (user.Roles.Count == 0)
                    infos += user.Email + ".";
                else
                {
                    infos += user.Email + ", Roles: ";

                    foreach (var role in user.Roles)
                    {
                        count++;

                        if (count == getCount)
                        {
                            infos += role.Name + ".";
                        }
                        else
                        {
                            infos += role.Name + ", ";
                        }
                    }

                }

                Console.WriteLine(infos);
                Console.WriteLine($"====================================");
                count = 0;
                infos = "";
            }


            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
