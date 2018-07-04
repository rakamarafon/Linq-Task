using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task.Services
{
    interface IDataStructureService
    {
        IEnumerable<(Posts, int)> GetCommentsCountByUserPosts(int user_id, List<Posts> posts, List<Comments> comments);

        List<Comments> GetCommentsByUserIdWhenCommentBodyMoreThanDefault(int byDefault = 50);

        IEnumerable<(int, string)> DoneTodosForUser(int id, List<Todos> todos);

        //Получить список пользователей по алфавиту(по возрастанию) с отсортированными todo items по длине name(по убыванию)


        (string, string, int, int, string, string) GetStructureUser(int id);
        //Получить следующую структуру(передать Id пользователя в параметры)

        //User

        //Последний пост пользователя(по дате)

        //Количество комментов под последним постом

        //Количество невыполненных тасков для пользователя

        //Самый популярный пост пользователя(там где больше всего комментов с длиной текста больше 80 символов)

        (string, string, string, int) GetMostPopularPost(int id);
    //Самый популярный пост пользователя(там где больше всего лайков)

             //Получить следующую структуру(передать Id поста в параметры)

             //Пост
             
             //Самый длинный коммент поста
             
             //Самый залайканный коммент поста
             
             //Количество комментов под постом где или 0 лайков или длина текста< 80
    }
}
