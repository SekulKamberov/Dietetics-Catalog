namespace DietCatalog.Services.Models.Categories
{
    using Common.Mapping;
    using DietCatalog.Data.EntityConstants;

    public class CategoryServiceModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
