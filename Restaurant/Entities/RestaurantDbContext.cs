using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString = "Server=IT7693\\SQLEXPRESS;Database=RestaurantDb;Trusted_Connection=True;";

        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);
            
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Dish>()
                .Property(d => d.Price)
                .IsRequired();
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Dishes)
                .HasForeignKey(d => d.CategoryName);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.City)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.Street)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Price)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Position>()
                .Property(p => p.Salary)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<User>()
                .Property(u => u.Login)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
