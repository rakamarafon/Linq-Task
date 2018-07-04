using Linq_Task.DAL;
using Linq_Task.Services;
using System;
using System.Collections.Generic;

namespace Linq_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Address>   addresses;
            List<Comments>  comments;
            List<Posts>     posts;
            List<Todos>     todos;
            List<Users>     users;

            IDataSource dataSource = new HttpDataSource();

            addresses = dataSource.GetAddressesList();
            comments  = dataSource.GetCommentsList();
            posts     = dataSource.GetPostsList();
            todos     = dataSource.GetTodosList();
            users     = dataSource.GetUsersList();

            IDataStructureService structureService = new DataStructureService(addresses, comments, posts, todos, users);

            int USER_ID = 9;
            int POST_ID = 1;

            Console.WriteLine("Get count user's comments for user(set user id)");
            var usrCmnts = structureService.GetCommentsCountByUserPosts(USER_ID);
            foreach (var item in usrCmnts)
            {
                Console.WriteLine(item.Item1.ToString());
                Console.WriteLine("Comments count: {0}", item.Item2);
            }

            Console.WriteLine();

            Console.WriteLine("Get count comments for user posts where comment's body more than 50 characters(set user id)");
            var chr50 = structureService.GetCommentsByUserIdWhenCommentBodyMoreThanDefault(USER_ID);
            foreach (var item in chr50)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Get list todos which was done for user(set user id)");
            var done = structureService.DoneTodosForUser(USER_ID, todos);
            foreach (var item in done)
            {
                Console.WriteLine("ID: {0}", item.Item1);
                Console.WriteLine("Name: {0}", item.Item2);
            }

            Console.WriteLine();

            Console.WriteLine("Get User structure");
            var usr = structureService.GetStructureUser(USER_ID);
            foreach (var item in usr)
            {
                Console.WriteLine("User Name: {0}", item.Item1);
                Console.WriteLine("Last User Post: {0}", item.Item2.ToString());
                Console.WriteLine("Comment's count on last post: {0}", item.Item3);
                Console.WriteLine("Most popular and length post for user: {0}", item.Item4);
                Console.WriteLine("Most popular user's post: {0}", item.Item5);
            }

            Console.WriteLine();

            //Console.WriteLine("Get Post structure");
            //var pst = structureService.GetStructurePost(POST_ID);
            //foreach (var item in pst)
            //{
            //    Console.WriteLine("Post: {0}", item.Item1);
            //    Console.WriteLine("Most biggest comment: {0}", item.Item2);
            //    Console.WriteLine("Most Liked comment: {0}", item.Item3);
            //    Console.WriteLine("Comment's count when 0 likes or length more than 80: {0}", item.Item4);
            //}
            Console.ReadKey();
        }       
    }
}
