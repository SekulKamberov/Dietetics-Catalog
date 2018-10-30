namespace DietCatalog.Services.Models.Days
{
    using System.Linq;

    using AutoMapper;
    using Common.Mapping;

    using DietCatalog.Data.EntityConstants;

    public class DayDetailsServiceModel  
    {
        public string WeekDay { get; set; }

        public string Breakfast { get; set; }

        public string FirstSnack { get; set; }

        public string Lunch { get; set; }

        public string SecondSnack { get; set; }

        public string Dinner { get; set; }

        public string LastSnack { get; set; }

        public string DailyTotal { get; set; }

        public string Recommended { get; set; }
    }
}
