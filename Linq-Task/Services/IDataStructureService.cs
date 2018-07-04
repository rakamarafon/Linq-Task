using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task.Services
{
    interface IDataStructureService
    {
        IEnumerable<(Posts, int)> GetCommentsCountByUserPosts(int user_id);

        IEnumerable<Comments> GetCommentsByUserIdWhenCommentBodyMoreThanDefault(int user_id, int byDefault = 50);

        IEnumerable<(int, string)> DoneTodosForUser(int id, List<Todos> todos);

        //Получить список пользователей по алфавиту(по возрастанию) с отсортированными todo items по длине name(по убыванию)

        IEnumerable<(string, Posts, int, Posts, Posts)> GetStructureUser(int user_id);
        IEnumerable<(Posts, Comments, int, int)> GetStructurePost(int post_id);
    }
}
