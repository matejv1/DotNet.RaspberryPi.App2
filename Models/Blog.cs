using System.Collections.Generic;

namespace DotNet.RaspberryPi.App2.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}