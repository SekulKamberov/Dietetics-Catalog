namespace DietCatalog.Data.EntityConstants
{
    using System.ComponentModel.DataAnnotations;
    using static DietCatalog.Data.EntityModels.EntityConstants;

    public class Day
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string WeekDay { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string Breakfast { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string FirstSnack { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string Lunch { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string SecondSnack { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string Dinner { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string LastSnack { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string DailyTotal { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string Recommended { get; set; }

        public int DietId { get; set; }

        public Diet Diet { get; set; }
    }
}
