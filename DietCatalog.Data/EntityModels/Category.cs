namespace DietCatalog.Data.EntityConstants
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DietCatalog.Data.EntityModels.EntityConstants;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryMaxLength)]
        public string Name { get; set; }

        public ICollection<CategoryDiet> Diets { get; set; } = new List<CategoryDiet>();
    }
}
