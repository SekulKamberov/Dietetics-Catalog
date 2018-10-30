namespace DietCatalog.Services.Contracts
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DietCatalog.Services.Models.Days;

    public interface IDayService
    {
        Task<IEnumerable<DayListingServiceModel>> All(string searchTerm);

        Task<int> Create(
            string weekDay, string breakfast, string firstSnack, string lunch, 
            string secondSnack, string dinner, string lastSnack, string dailyTotal, string recommended, int dietId);

        Task Delete(int id);

        Task<DayDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);

        Task Update(
            int id, string weekDay, string breakfast, string firstSnack,
            string lunch, string secondSnack, string dinner, string lastSnack, 
            string dailyTotal, string recommended, int dietId);
    }
}
