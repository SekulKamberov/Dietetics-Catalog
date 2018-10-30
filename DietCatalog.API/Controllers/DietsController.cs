namespace DietCatalog.API.Controllers
{
    using DietCatalog.API.Models.Days;
    using DietCatalog.API.Models.Diets;
    using DietCatalog.Services.Contracts;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
 
    using Services;
    using System.Threading.Tasks;
    using static Constants;
    using DietCatalog.API.Models.Diet;

    public class DietsController : BaseApiController
    {
        private readonly IDietService dietService;
        private readonly IAuthorService authorService;

        public DietsController(
            IDietService dietService,
            IAuthorService authorService)
        {
            this.dietService = dietService;
            this.authorService = authorService;
        }

        [HttpGet(id)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.dietService.Details(id));

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
            => this.OkOrNotFound(await this.dietService.All(search));

        [HttpDelete(id)]
        public async Task<IActionResult> Delete(int id)
        {
            var bookExists = await this.dietService.Exists(id);
            if (!bookExists)
            {
                return NotFound("Diet does not exist.");
            }

            await this.dietService.Delete(id);

            return this.Ok();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]DietWithCategoriesRequestModel model)
        {
            var authorExists = await this.authorService.Exists(model.AuthorId);
            if (!authorExists)
            {
                return BadRequest("Author does not exist.");
            }

            var id = await this.dietService.Create(
                model.Title.Trim(),
                model.Description.Trim(),
                model.HowLong,
                model.Price,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId,
                model.Categories);

            return Ok(id);
        }

        [HttpPut(id)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody]DietRequestModel model)
        {
            var bookExists = await this.dietService.Exists(id);
            if (!bookExists)
            {
                return NotFound("Diet does not exist");
            }

            var authorExists = await this.authorService.Exists(model.AuthorId);
            if (!authorExists)
            {
                return BadRequest("Author does not exist");
            }

            await this.dietService.Update(
                id,
                model.Title.Trim(),
                model.Description.Trim(),
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId);

            return Ok();
        }
    }
}
