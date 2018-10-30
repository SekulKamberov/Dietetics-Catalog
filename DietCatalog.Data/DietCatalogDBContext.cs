namespace DietCatalog.Data
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using DietCatalog.Data.EntityConstants;

    public class DietCatalogDBContext : DbContext
    {
        public DietCatalogDBContext(DbContextOptions<DietCatalogDBContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }   

        public DbSet<Diet> Diets { get; set; }  

        public DbSet<Day> Days { get; set; }   

        public DbSet<Category> Categories { get; set; }   

        public DbSet<CategoryDiet> CategoryDiets { get; set; }   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<CategoryDiet>()  
                .HasKey(cb => new { cb.CategoryId, cb.DietId }); 

            builder
                .Entity<CategoryDiet>() 
                .HasOne(cb => cb.Category) 
                .WithMany(c => c.Diets) 
                .HasForeignKey(cb => cb.CategoryId); 

            builder
                .Entity<CategoryDiet>() 
                .HasOne(cb => cb.Diet) 
                .WithMany(b => b.Categories) 
                .HasForeignKey(cb => cb.DietId); 

            builder
                .Entity<Diet>() 
                .HasOne(b => b.Author) 
                .WithMany(a => a.Diets) 
                .HasForeignKey(b => b.AuthorId); 

            builder
                .Entity<Day>()
                .HasOne(s => s.Diet)
                .WithMany(a => a.Days)
                .HasForeignKey(b => b.DietId);
        }
    }
}
