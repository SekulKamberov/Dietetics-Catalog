namespace DietCatalog.API.Models.Diets
{
    using DietCatalog.API.Models.Diet;

    public class DietWithCategoriesRequestModel : DietRequestModel
    {
        public string Categories { get; set; }
        public string HowLong { get; set; }
    }
}
