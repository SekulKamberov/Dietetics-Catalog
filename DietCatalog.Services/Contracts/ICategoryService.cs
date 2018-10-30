namespace DietCatalog.Services.Contracts
{
    using DietCatalog.Services.Models.Categories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryServiceModel>> All();

        Task<int> Create(string name);

        Task<CategoryServiceModel> Details(int id);

        Task Delete(int id);

        Task<bool> Exists(int id);

        Task<bool> Exists(int id, string name);

        Task<bool> Exists(string name);

        Task Update(int id, string name);
    }
}
