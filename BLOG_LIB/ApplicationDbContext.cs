using BLOG_LIB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOG_LIB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

 
    }
}
