namespace DietCatalog.Data.EntityConstants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using static DietCatalog.Data.EntityModels.EntityConstants;

    public class Diet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MinLength)]
        [MaxLength(MaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string HowLong { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string Difficult { get; set; } = "Normal";

        public int? AgeRestriction { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Day> Days { get; set; } = new List<Day>();

        public ICollection<CategoryDiet> Categories { get; set; } = new List<CategoryDiet>();
    }
}
