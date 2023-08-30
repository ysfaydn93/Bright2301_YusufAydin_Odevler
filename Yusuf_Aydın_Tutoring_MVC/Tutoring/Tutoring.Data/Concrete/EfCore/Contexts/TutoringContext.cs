using Tutoring.Data.Concrete.EfCore.Configs;
using Tutoring.Data.Concrete.EfCore.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Concrete.EfCore.Contexts
{
    public class TutoringContext :IdentityDbContext<User, Role, string>
    {
        public TutoringContext(DbContextOptions options) : base(options) { }    

        public DbSet<Category> Categories { get; set; }
        public DbSet<Lesson> Lessons { get; set; }  
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<LessonCategory> LessonCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfig).Assembly);
           
            base.OnModelCreating(modelBuilder); 
        }
    }
}
