using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task
{
    public class Posts
    {
    public int id { get; set; }
    public DateTime createdAt { get; set; }
    public string title { get; set; }
    public string body { get; set; }
    public int userId { get; set; }
    public int likes { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Created: {1}, Title: {2}, Body: {3}, UserID: {4}, Likes: {5}", id, createdAt, title, body, userId, likes);
        }
    }
}
