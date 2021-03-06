﻿namespace DietCatalog.API.Models.Days
{
    using System.ComponentModel.DataAnnotations;

    using DietCatalog.API.Models.Days;
    using static DietCatalog.Data.EntityModels.EntityConstants;

    public class DayServiceModel  
    {
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
    }
}
