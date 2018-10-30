namespace DietCatalog.Services.Contracts
{
    using DietCatalog.Services.Models.Diets;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDietService
    {
        Task<IEnumerable<DietListingServiceModel>> All(string searchTerm);

        Task<int> Create(
            string title,
            string description,
            string howLong,
            decimal price,
            int? ageRestriction,
            DateTime? releaseDate,
            int authorId,
            string categories);

        Task Delete(int id);

        Task<DietDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);

        Task Update(
            int id,
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime? releaseDate,
            int authorId);
    }
}
