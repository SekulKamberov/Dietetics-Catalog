namespace DietCatalog.Services.Models.Diets
{
    using Common.Mapping;
    using DietCatalog.Data.EntityConstants;

    public class DietListingServiceModel : IMapFrom<Diet>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
