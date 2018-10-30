namespace DietCatalog.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Extensions;
    using Data;
    using DietCatalog.Data.EntityConstants;
    using DietCatalog.Services.Contracts;
    using DietCatalog.Services.Models.Diets;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DietService : IDietService
    {
        private const int DietsCount = 10;

        private readonly DietCatalogDBContext db;

        public DietService(DietCatalogDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<DietListingServiceModel>> All(string searchTerm)
            => await this.db.Diets.Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()))
            .OrderBy(b => b.Title).Take(DietsCount).ProjectTo<DietListingServiceModel>().ToListAsync();

        public async Task<int> Create(
            string title, string description, string howLong, decimal price, int? ageRestriction, 
            DateTime? releaseDate, int authorId, string categories)
        {
           
            var diet = new Diet
            {
                AuthorId = authorId,
                Title = title,
                Description = description,
                HowLong = howLong,
                Price = price,
                ReleaseDate = releaseDate,
                AgeRestriction = ageRestriction
            };

            if (!string.IsNullOrWhiteSpace(categories))
            {
                // Get categories
                var categoryNames = categories
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToHashSet();

                var existingCategories = await this.db
                    .Categories
                    .Where(c => categoryNames
                                .Select(cn => cn.ToLower())
                                .Contains(c.Name.ToLower()))
                    .ToListAsync();

                var allCategories = new List<Category>(existingCategories);

                foreach (var categoryName in categoryNames)
                {
                    if (!existingCategories.Any(c => c.Name.ToLower() == categoryName.ToLower()))
                    {
                        var category = new Category { Name = categoryName };
                        this.db.Categories.Add(category);
                        allCategories.Add(category);
                    }
                }

                await this.db.SaveChangesAsync();

                foreach (var category in allCategories)
                {
                    diet.Categories.Add(new CategoryDiet { CategoryId = category.Id });
                }
            }

            await this.db.AddAsync(diet);
            await this.db.SaveChangesAsync();

            return diet.Id;
        }

        public async Task Delete(int id)
        {
            var diet = await this.db.Diets.FindAsync(id);
            if (diet == null)
            {
                return;
            }

            this.db.Remove(diet);
            await this.db.SaveChangesAsync();
        }

        public async Task<DietDetailsServiceModel> Details(int id)
            => await this.db.Diets.Where(b => b.Id == id).ProjectTo<DietDetailsServiceModel>().FirstOrDefaultAsync();

        public async Task<bool> Exists(int id) => await this.db.Diets.AnyAsync(b => b.Id == id);

        public async Task Update(
            int id, string title, string description, decimal price, int copies, 
            int? edition, int? ageRestriction, DateTime? releaseDate, int authorId)
        {
            var diet = await this.db.Diets.FindAsync(id);
            if (diet == null)
            {
                return;
            }

            if (diet.AuthorId != authorId ||
                diet.Title != title ||
                diet.Description != description ||
                diet.Price != price ||
                diet.ReleaseDate != releaseDate ||
                diet.AgeRestriction != ageRestriction)
            {
                diet.AuthorId = authorId;
                diet.Title = title;
                diet.Description = description;
                diet.Price = price;
                diet.ReleaseDate = releaseDate;
                diet.AgeRestriction = ageRestriction;

                await this.db.SaveChangesAsync();
            }
        }
    }
}
