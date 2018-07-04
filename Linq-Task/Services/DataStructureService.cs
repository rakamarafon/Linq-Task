using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Task.Services
{
    public class DataStructureService : IDataStructureService
    {        
        public DataStructureService(List<Address> addresses, List<Comments> comments, List<Posts> posts, List<Todos> todos, List< Users> users)
        {
            var commentsToPosts = posts.GroupJoin(
                                                   comments,
                                                   p => p.id,
                                                   c => c.postId,
                                                   (pst, com) => new
                                                   {
                                                        Id = pst.id,
                                                        CreadetAt = pst.createdAt,
                                                        Title = pst.title,
                                                        Body = pst.body,
                                                        UserId = pst.userId,
                                                        Likes = pst.likes,
                                                        PComments = com.Select(c => new
                                                        {
                                                            Id = c.id,
                                                            CreadetAt = c.createdAt,
                                                            Body = c.body,
                                                            UserId = c.userId,
                                                            PostId = c.postId,
                                                            Likes = c.likes
                                                        })
                                                   }
                                                   );

            var postToUsers = users.GroupJoin(
                                        commentsToPosts,
                                        //posts,
                                        u => u.id,
                                        p => p.UserId,
                                        (user, pst) => new
                                        {
                                            Id = user.id,
                                            CreatedAt = user.createdAt,
                                            Name = user.name,
                                            Avatar = user.avatar,
                                            Email = user.email,
                                            UPosts = pst.Select(p => new
                                            {
                                                id = p.Id,
                                                CreatedAt = p.CreadetAt,
                                                title = p.Title,
                                                body = p.Body,
                                                userId = p.UserId,
                                                likes = p.Likes,                                                
                                                PComments = com.Select(c => new
                                                 {
                                                     Id = c.id,
                                                     CreadetAt = c.createdAt,
                                                     Body = c.body,
                                                     UserId = c.userId,
                                                     PostId = c.postId,
                                                     Likes = c.likes
                                                 })
                                            })
                                        });
           
            var todosToUsers = postToUsers.
        }
        public IEnumerable<(Posts, int)> GetCommentsCountByUserPosts(int user_id, List<Posts> posts, List<Comments> comments)
        {
            var post = posts.FindAll(x => x.userId == user_id);
            var count = (from com in comments
                         join pst in post on com.postId equals pst.id
                         select com).Count();
            return null;
        }
        public IEnumerable<(int, string)> DoneTodosForUser(int id, List<Todos> todos)
        {
            return  from x in todos
                    where x.userId == id && x.isComplete == true
                    select (UserId : x.userId, UserName : x.name);
        }

        public List<Comments> GetCommentsByUserIdWhenCommentBodyMoreThanDefault(int byDefault = 50)
        {
            throw new NotImplementedException();
        }        

        public (string, string, string, int) GetMostPopularPost(int id)
        {
            throw new NotImplementedException();
        }

        public (string, string, int, int, string, string) GetStructureUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
