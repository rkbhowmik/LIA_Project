using LIA.Data.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data
{
    public class CourseContext : IdentityDbContext<User>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<Module> Modules { get; set; }

        //public DbSet<User> Users { get; set; }
        public DbSet<UserCourse> UserCourses{ get; set; }


    }
}
