namespace DietCatalog.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using DietCatalog.Data.EntityConstants;
    using DietCatalog.Services.Contracts;
    using DietCatalog.Services.Models.Authors;
    using DietCatalog.Services.Models.Diets;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorService : IAuthorService
    {
        private readonly DietCatalogDBContext db;

        public AuthorService(DietCatalogDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<DietWithCategoriesServiceModel>> All(int authorId)
            => await this.db
            .Diets
            .Where(b => b.AuthorId == authorId)
            .ProjectTo<DietWithCategoriesServiceModel>()
            .ToListAsync();

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            await this.db.Authors.AddAsync(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
            => await this.db
            .Authors
            .Where(a => a.Id == id)
            .ProjectTo<AuthorDetailsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task<AuthorDetailsServiceModel> DetailsWithDiets(int id)
            => await this.db
            .Authors
            .Where(a => a.Id == id)
            .ProjectTo<AuthorDetailsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> Exists(int id)
            => await this.db.Authors.AnyAsync(a => a.Id == id);
    }
}
