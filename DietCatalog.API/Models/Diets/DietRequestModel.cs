namespace DietCatalog.API.Models.Diet
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DietCatalog.Data.EntityModels.EntityConstants;

    public class DietRequestModel
    {
        [Required]
        [MinLength(MinLength)]
        [MaxLength(MaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; } = 1;

        public int? AgeRestriction { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public int AuthorId { get; set; }
    }
}
