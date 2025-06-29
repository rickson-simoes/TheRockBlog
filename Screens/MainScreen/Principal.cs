﻿using Blog.Screens.CategoryScreen;
using Blog.Screens.PostScreen;
using Blog.Screens.RoleScreen;
using Blog.Screens.TagScreen;
using Blog.Screens.UserScreen;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.MainScreen
{
    public class Principal
    {
        private readonly SqlConnection _connection;
        public Principal(SqlConnection connection) => _connection = connection;

        public void Main()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("Please choose an option");
                Console.WriteLine("0 - To exit.");
                Console.WriteLine("1 - Create an User.");
                Console.WriteLine("2 - Create a Role.");
                Console.WriteLine("3 - Assign an User to a Role.");
                Console.WriteLine("4 - Create a Category.");
                Console.WriteLine("5 - Create a tag.");
                Console.WriteLine("6 - Create a post.");
                Console.WriteLine("7 - Assign a Post to a Tag.");
                Console.WriteLine("8 - List users.");
                Console.WriteLine("9 - List categories with posts count.");
                Console.WriteLine("10 - List Tags with posts count.");
                Console.WriteLine("11 - List posts with the selected category.");
                Console.WriteLine("12 - List posts with categories.");
                Console.WriteLine("13 - List posts with their tags.");
                Console.WriteLine("=================================");
                Console.Write("\nOption: ");
                int.TryParse(Console.ReadLine(), out int optSelected);

                Console.Clear();
                switch(optSelected)
                {
                    case 0:
                        return;

                    case 1:
                        var userCreation = new UserScreenCreation(_connection);
                        userCreation.Create();
                        break;

                    case 2:
                        var roleCreation = new RoleScreenCreation(_connection);
                        roleCreation.Create();
                        break;

                    case 3:
                        var userRole = new UserScreenAssignRole(_connection);
                        userRole.Assign();
                        break;

                    case 4:
                        var categoryCreation = new CategoryScreenCreation(_connection);
                        categoryCreation.Create();
                        break;

                    case 5:
                        var tagCreation = new TagScreenCreation(_connection);
                        tagCreation.Create();
                        break;

                    case 6:
                        var postCreation = new PostScreenCreation(_connection);
                        postCreation.Create();
                        break;

                    case 7:
                        var postTag = new PostScreenAssignTag(_connection);
                        postTag.Assign();
                        break;

                    case 8:
                        var users = new UserScreenGetUsers(_connection);
                        users.Get();
                        break;

                    case 9:
                        var categoryPostCountList = new CategoryScreenGetPostCount(_connection);
                        categoryPostCountList.Get();
                        break;

                    case 10:
                        var tagPostCountList = new TagScreenGetPostCount(_connection);
                        tagPostCountList.Get();
                        break;

                    case 11:
                        var postCategoryCountList = new PostScreenGetOneCategory(_connection);
                        postCategoryCountList.Get();
                        break;

                    case 12:
                        var postCategoryList = new PostScreenGetCategories(_connection);
                        postCategoryList.Get();
                        break;

                    case 13:
                        var postTagList = new PostScreenGetTags(_connection);
                        postTagList.Get();
                        break;
                }
            }
        }
    }
}
