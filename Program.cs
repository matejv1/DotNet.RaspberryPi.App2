using System;
using DotNet.RaspberryPi.App2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotNet.RaspberryPi.App2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new BloggingContext())
            {
                // add new blog to database table
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs.Include(x => x.Posts))
                {
                    // add post to current blog
                    var sBlog = db.Blogs.Include(x => x.Posts).Where(x => x.BlogId == blog.BlogId).FirstOrDefault();
                    sBlog.Posts.Add(new Post() { Title = "Post - Title" });
                    db.SaveChanges();

                    // display all the blog post for current blog
                    Console.WriteLine(" - {0}", blog.Url);
                    foreach (var post in blog.Posts)
                    {
                        Console.WriteLine(" - - Post:" + post.Title);
                    }
                }
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
