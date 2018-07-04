using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task
{
   public class Comments
    {
    public int id { get; set; }
    public DateTime createdAt { get; set; }
    public string body { get; set; }
    public int userId { get; set; }
    public int postId { get; set; }
    public int likes { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Created: {1}, Body: {2}, UserID: {3}, PostID{4}, Likes: {5}", id, createdAt, body, userId, postId, likes);
        }
    }
}
