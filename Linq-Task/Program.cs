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
            Console.ReadKey();
        }       
    }
}
