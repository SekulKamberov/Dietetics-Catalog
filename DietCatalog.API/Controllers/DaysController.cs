namespace DietCatalog.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using DietCatalog.API.Infrastructure.Extensions;
    using DietCatalog.API.Infrastructure.Filters;
    using DietCatalog.Services.Contracts;
    using DietCatalog.API.Models.Days;
    using DietCatalog.API.Models.Diet;
    using static Constants;


    public class DaysController : BaseApiController
    {
        private readonly IDayService dayService;

        public DaysController(IDayService dayService)
        {
            this.dayService = dayService;
        }

        [HttpGet(id)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.dayService.Details(id));

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
            => this.OkOrNotFound(await this.dayService.All(search));

        [HttpDelete(id)]
        public async Task<IActionResult> Delete(int id)
        {
            var bookExists = await this.dayService.Exists(id);
            if (!bookExists)
            {
                return NotFound("Day does not exist");
            }

            await this.dayService.Delete(id);

            return this.Ok();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]DayRequestModel model)
        {
            var dayExists = await this.dayService.Exists(model.Id);
            if (!dayExists)
            {
                var id = await this.dayService.Create(
                     model.WeekDay, model.Breakfast, model.FirstSnack, model.Lunch, model.SecondSnack, 
                     model.Dinner, model.LastSnack, model.DailyTotal, model.Recommended, model.DietId);

                return Ok(id);   
            }
            return BadRequest("The day exist");
        }

        [HttpPut(id)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody]DayRequestModel model)
        {
            var dayExists = await this.dayService.Exists(id);
            if (!dayExists)
            {
                return NotFound("The day does not exist");
            }

            var authorExists = await this.dayService.Exists(model.Id);
            if (!authorExists)
            {
                return BadRequest("The day does not exist in the diet");
            }

            await this.dayService.Update(
                model.Id, model.WeekDay, model.Breakfast, model.FirstSnack, model.Lunch, model.SecondSnack,
                model.Dinner, model.LastSnack, model.DailyTotal, model.Recommended, model.DietId);

            return Ok();
        }
    }
}
