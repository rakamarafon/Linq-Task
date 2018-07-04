using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task
{
   public class Comments
    {
    public string id { get; set; }
    public DateTime createdAt { get; set; }
    public string body { get; set; }
    public int userId { get; set; }
    public int postId { get; set; }
    public int likes { get; set; }
    }
}
