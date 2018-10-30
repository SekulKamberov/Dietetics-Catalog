namespace DietCatalog.API.Controllers
{
    using DietCatalog.API.Models.Authors;
    using DietCatalog.Services.Contracts;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
 
    using Services;
    using System.Threading.Tasks;

    using static Constants;

    public class AuthorsController : BaseApiController
    {
        private readonly IAuthorService authorService;
        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet(id)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.authorService.Details(id));

        [HttpGet(id + "/diets")]
        public async Task<IActionResult> GetDiets(int id)
            => this.OkOrNotFound(await this.authorService.All(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
        {
            var id = await this.authorService.Create(
                model.FirstName.Trim(),
                model.LastName.Trim());

            return Ok(id);
        }
    }
}
