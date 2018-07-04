using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task.DAL
{
    interface IHttpDataSource
    {
        List<Users> GetUsersList();
        List<Posts> GetPostsList();
        List<Comments> GetCommentsList();
        List<Todos> GetTodosList();
        List<Address> GetAddressesList();
    }
}
