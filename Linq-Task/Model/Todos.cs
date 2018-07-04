using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Task
{
    public class Todos
    {
    public int id { get; set; }
    public DateTime createdAt { get; set; }
    public string name { get; set; }
    public bool isComplete { get; set; }
    public int userId { get; set; }
    }
}
