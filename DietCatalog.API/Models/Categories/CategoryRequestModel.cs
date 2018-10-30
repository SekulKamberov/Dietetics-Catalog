namespace DietCatalog.API.Models.Categories
{
    using System.ComponentModel.DataAnnotations;
    using static DietCatalog.Data.EntityModels.EntityConstants;

    public class CategoryRequestModel
    {
        [Required]
        [MaxLength(CategoryMaxLength)]
        public string Name { get; set; }
    }
}
