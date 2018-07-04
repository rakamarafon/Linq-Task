using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task.DAL
{
    interface IDataSource
    {
        List<Users> GetUsersList();
        List<Posts> GetPostsList();
        List<Comments> GetCommentsList();
        List<Todos> GetTodosList();
        List<Address> GetAddressesList();
    }
}
