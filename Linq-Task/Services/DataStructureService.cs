using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Task.Services
{
    public class DataStructureService : IDataStructureService
    {
        private class MainCollection
        {
            public int Uid { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Name { get; set; }
            public string Avatar { get; set; }
            public string Email { get; set; }
            public IEnumerable<Posts> UPost { get; set; }
            public IEnumerable<Comments> PComments { get; set; }
        }

        private List<MainCollection> collection = new List<MainCollection>();

        public DataStructureService(List<Address> addresses, List<Comments> comments, List<Posts> posts, List<Todos> todos, List<Users> users)
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
                                        u => u.id,
                                        p => p.UserId,
                                        (user, pst) => new
                                        {
                                            Id = user.id,
                                            CreatedAt = user.createdAt,
                                            Name = user.name,
                                            Avatar = user.avatar,
                                            Email = user.email,
                                            UPosts = pst.Select(p => new Posts()
                                            {
                                                id = p.Id,
                                                createdAt = p.CreadetAt,
                                                title = p.Title,
                                                body = p.Body,
                                                userId = p.UserId,
                                                likes = p.Likes
                                            })
                                        });

            var UsersWithPostsCommentsTodos = postToUsers.GroupJoin(
                                                comments,
                                                p => p.Id,
                                                c => c.userId,
                                                (pst, com) => new
                                                {
                                                    Uid = pst.Id,
                                                    pst.CreatedAt,
                                                    pst.Name,
                                                    pst.Avatar,
                                                    pst.Email,
                                                    pst.UPosts,
                                                    PComments = com.Select(c => new Comments()
                                                    {
                                                        id = c.id,
                                                        createdAt = c.createdAt,
                                                        body = c.body,
                                                        userId = c.userId,
                                                        postId = c.postId,
                                                        likes = c.likes
                                                    })
                                                });

            foreach (var item in UsersWithPostsCommentsTodos)
            {
                MainCollection temp = new MainCollection() { Uid = item.Uid, CreatedAt = item.CreatedAt, Name = item.Name, Avatar = item.Avatar, Email = item.Email, PComments = item.PComments, UPost = item.UPosts };
                collection.Add(temp);
            }

        }
        public IEnumerable<(Posts, int)> GetCommentsCountByUserPosts(int user_id)
        {
            var temp = from c in collection
                        from post in c.UPost
                        where c.Uid == user_id
                        select (post, c.PComments.Where(x => x.postId == post.id).Count());
            return temp;
        }
        public IEnumerable<Comments> GetCommentsByUserIdWhenCommentBodyMoreThanDefault(int user_id, int byDefault = 50)
        {
            var temp = collection.SelectMany(x => x.PComments.Where(y => y.userId == user_id && y.body.Count() >= byDefault));
            return temp;
        }
        public IEnumerable<(int, string)> DoneTodosForUser(int id, List<Todos> todos)
        {
            return from x in todos
                   where x.userId == id && x.isComplete == true
                   select (UserId: x.userId, UserName: x.name);
        }
       
        public IEnumerable<(string, Posts, int, Posts, Posts)> GetStructureUser(int user_id)
        {

            var temp = from c in collection
                       let LatestPost = c.UPost.OrderByDescending(x => x.createdAt).FirstOrDefault()
                       let PostWithBodyLength = c.UPost.Where(x => x.body.Length < 80)
                       where c.Uid == user_id
                       select (c.Name, LatestPost, c.PComments.Count(x => x.postId == LatestPost.id), PostWithBodyLength.OrderByDescending(x => x.likes).Max(), c.UPost.OrderByDescending(x => x.likes).Max());
            return temp;
        }

        public IEnumerable<(Posts, Comments, int, int)> GetStructurePost(int post_id)
        {
            var temp = from c in collection
                       let Post = c.UPost.Single(x => x.id == post_id)
                       let MostLengthComment = c.PComments.Single(x => x.id == Post.id)
                       let MostLiked = c.PComments.Max(x => x.likes)
                       let Cnt = c.PComments.Count(x => x.id == Post.id || x.body.Length < 80)                       
                       select (Post, MostLengthComment, MostLiked, Cnt);
            return temp;
        }
    }
}
