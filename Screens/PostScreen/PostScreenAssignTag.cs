using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostScreen
{
    public class PostScreenAssignTag
    {
        private readonly SqlConnection _connection;

        public PostScreenAssignTag(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Assign()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("=========== Screen: Assign a Post to a tag.");
            Console.WriteLine("---------------------------------");

            // vincular o ID do post com id da tag na tabela PostTag

            Repository<Post> postRepository = new Repository<Post>(_connection);
            Repository<Tag> tagRepository = new Repository<Tag>(_connection);

            var postSelected = selectAPost(postRepository);
            if (postSelected == null)
            {
                Console.WriteLine("No post found, press any key to return to main menu.");
                Console.ReadLine();
                return;
            }

            var tagSelected = selectATag(tagRepository);
            if (tagSelected == null)
            {
                Console.WriteLine("No tag found, press any key to return to main menu.");
                Console.ReadLine();
                return;
            }

            assignPostToTag(postSelected, tagSelected);
        }

        private Post? selectAPost(Repository<Post> postRepository)
        {
            var posts = postRepository.Get();

            Console.WriteLine("============================================================");
            foreach (var post in posts)
            {
                Console.WriteLine($"Id: {post.Id} - User: {post.Title}");
            }
            Console.WriteLine("============================================================\n");
            Console.Write("Choose a post id: ");
            int.TryParse(Console.ReadLine(), out int postId);

            if (postId == 0)
            {
                return null;
            }

            var postSelected = posts.FirstOrDefault(pst => pst.Id == postId);

            return postSelected;

        }
        private Tag? selectATag(Repository<Tag> tagRepository)
        {
            var tags = tagRepository.Get();

            Console.WriteLine("\n============================================================");
            foreach (var tag in tags)
            {
                Console.WriteLine($"Id: {tag.Id} - User: {tag.Name}");
            }
            Console.WriteLine("============================================================\n");
            Console.Write("Choose a tag id: ");
            int.TryParse(Console.ReadLine(), out int tagId);

            if (tagId == 0)
            {
                return null;
            }

            var tagSelected = tags.FirstOrDefault(tg => tg.Id == tagId);

            return tagSelected;
        }
        private void assignPostToTag(Post post, Tag tag)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Post selected: {post.Title}");
            Console.WriteLine($"Tag selected: {tag.Name}");

            var postTagRepo = new PostTagRepository(_connection);

            var PostTag = new PostTag { PostId = post.Id, TagId = tag.Id };

            postTagRepo.Create(PostTag);
            Console.WriteLine("\n ======================");
            Console.WriteLine("Post assigned with a tag.");
            Console.WriteLine("Press any button to return to main screen.");
            Console.ReadLine();
            return;
        }
    }
}
