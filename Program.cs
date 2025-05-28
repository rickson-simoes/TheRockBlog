using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog
{
     /*
      Infos:
      
     - Um POST tem muitas TAGS e uma tag pode estar em muitos posts
     - O MESMO acontece com o usuario, um usuario tem muitos roles e um role muitos usuarios
     - Uma categoria tem muitos posts mas um post não tem muitas categorias


     - @DESAFIO:
        Cadastrar um usuário.
        Cadastrar um perfil.
        Vincular um usuário a um perfil.

        Cadastrar uma categoria.

        Cadastrar uma Tag.

        Cadastrar um Post.

        Vincular um post a uma tag.

        Listar os usuários (Nome, Email e Perfis separados por vírgula)
        Listar categorias com quantidade de posts
        Listar tags com quantidade de posts
        Listas os posts de uma categoria
        Listar todos os posts com sua categoria
        Listar os posts com suas tags (separados por vírgula)
    */

  
    public class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;
                                                    Database=blog;
                                                    User ID=sa;
                                                    Password=a1b2c3d4#@!;
                                                    TrustServerCertificate=True;";

        static void Main()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var userRepository = new Repository<User>(connection);
            var users = userRepository.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Slug);
                Console.WriteLine("============================");
            }           
        }
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var userRepository = new UserRepository(connection);
            var users = userRepository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"PasswordHash: {user.PasswordHash}");
                Console.WriteLine($"Bio: {user.Bio}");
                Console.WriteLine($"Image: {user.Image}");
                Console.WriteLine($"Slug: {user.Slug}");
                foreach (var role in user.Roles)
                {                    
                    Console.WriteLine($"Role Id: {role.Id}");
                    Console.WriteLine($"Role Name: {role.Name}");
                    Console.WriteLine($"Role Slug: {role.Slug}");                    
                }
                Console.WriteLine($"====================================");
            }
        }
        public static void CreateUser(SqlConnection connection)
        {
            var userRepository = new Repository<User>(connection);
            var user = new User 
            { 
                Email = "paul@hotmail.com",
                Bio = "This is a bio from Paul",
                Image = "https://example.com/image.jpg",
                Name = "Paul Doe",
                PasswordHash = "hashedpassword123",
                Slug = "paul-doe"
            };

            userRepository.Create(user);
        }
    }
}
