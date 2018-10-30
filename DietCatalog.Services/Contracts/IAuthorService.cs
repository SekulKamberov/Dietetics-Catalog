namespace DietCatalog.Services.Contracts
{
    using DietCatalog.Services.Models.Diets;
    using Models.Authors;
 
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<IEnumerable<DietWithCategoriesServiceModel>> All(int authorId);

        Task<int> Create(string firstName, string lastName);

        Task<AuthorDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);
    }
}
