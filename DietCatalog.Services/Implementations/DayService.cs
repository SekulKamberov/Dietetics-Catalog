namespace DietCatalog.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper.QueryableExtensions;

    using Data;
    using Common.Extensions;
    using DietCatalog.Services.Contracts;
    using DietCatalog.Services.Models.Diets;
    using DietCatalog.Data.EntityConstants;
    using DietCatalog.Services.Models.Days;

    public class DayService : IDayService
    {
        private const int DietsCount = 10;

        private readonly DietCatalogDBContext db;

        public DayService(DietCatalogDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<DayListingServiceModel>> All(string searchTerm)
            => await this.db.Days.Where(b => b.Diet.Title.ToLower()
            .Contains(searchTerm.ToLower())).OrderBy(b => b.Diet).Take(DietsCount)
            .ProjectTo<DayListingServiceModel>().ToListAsync();



        public async Task<int> Create(string weekDay, string breakfast, string firstSnack,
            string lunch, string secondSnack, string dinner, string lastSnack, string dailyTotal, string recommended, int dietId)
        {
            var day = new Day
            {
                WeekDay = weekDay,
                Breakfast = breakfast,
                FirstSnack = firstSnack,
                Lunch = lunch,
                SecondSnack = secondSnack,
                Dinner = dinner,
                LastSnack = lastSnack,
                DailyTotal = dailyTotal,
                Recommended = recommended,
                DietId = dietId
        };

            await this.db.AddAsync(day);
            await this.db.SaveChangesAsync();

            return day.Id;
        }

        public async Task Delete(int id)
        {
            var day = await this.db.Days.FindAsync(id);
            if (day == null)
            {
                return;
            }

            this.db.Remove(day);
            await this.db.SaveChangesAsync();
        }

        public async Task<DayDetailsServiceModel> Details(int id)
            => await this.db
            .Days
            .Where(b => b.Id == id)
            .ProjectTo<DayDetailsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> Exists(int id)
            => await this.db.Days.AnyAsync(b => b.Id == id);

        public async Task Update(
            int Id, string weekDay, string breakfast, string firstSnack,
            string lunch, string secondSnack, string dinner, string lastSnack, string dailyTotal, string recommended, int dietId)
        {
            var day = await this.db.Days.FindAsync(Id);
            if (day == null)
            {
                return;
            }

            if (day.WeekDay != weekDay || day.Breakfast != breakfast || day.FirstSnack != firstSnack || 
                day.Lunch != lunch || day.SecondSnack != secondSnack || day.Dinner != dinner || day.LastSnack != lastSnack ||
                day.DailyTotal != dailyTotal || day.Recommended != recommended || day.Id == dietId)
            {
                day.WeekDay = weekDay;
                day.Breakfast = breakfast;
                day.FirstSnack = firstSnack;
                day.Lunch = lunch;
                day.SecondSnack = secondSnack;
                day.Dinner = dinner;
                day.LastSnack = lastSnack;
                day.DailyTotal = dailyTotal;
                day.Recommended = recommended;

                await this.db.SaveChangesAsync();
            }
        }
    }
}
