using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlogContext())
            {
                // Add and display to blogs
                Console.Write("Enter a name for a new blog:");
                var name = Console.ReadLine();                

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();                
                /*
                var query1 = from b in db.Blogs
                            orderby b.Name
                            select b;
                */
                foreach (var item in db.Blogs)
                {
                    Console.WriteLine(item.Name);
                }

                // Add and display to users
                Console.Write("Enter a username:");
                
                try
                {
                    var username = Console.ReadLine();
                    var un = new User { Username = username };
                    db.Users.Add(un);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    Console.Write("That name is taken, please enter a different name");
                    throw;
                }

                /*
                var query2 = from c in db.Users
                             orderby c.Username
                             select c;

                */
                foreach (var item in db.Users)
                {
                    Console.WriteLine(item.Username);
                }

                // pause
                Console.Read();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }

    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }

    /*
    public class PostContext: DbContext
    {
        public DbSet<Blog> Posts { get; set; }
    }
    */
}
