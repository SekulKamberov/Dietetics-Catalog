namespace DietCatalog.API.Controllers
{
    using DietCatalog.API.Models.Categories;
    using DietCatalog.Services.Contracts;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
  
    using Services;
    using System.Threading.Tasks;
    using static Constants;

    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => this.OkOrNotFound(await this.categoryService.All());

        [HttpGet(id)]
        public async Task<IActionResult> Get(int id)
           => this.OkOrNotFound(await this.categoryService.Details(id));

        [HttpDelete(id)]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryExists = await this.categoryService.Exists(id);
            if (!categoryExists)
            {
                return NotFound("Category does not exist.");
            }

            await this.categoryService.Delete(id);

            return Ok();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]CategoryRequestModel model)
        {
            model.Name = model.Name.Trim();

            var categoryNameExists = await this.categoryService.Exists(model.Name);
            if (categoryNameExists)
            {
                this.ModelState.AddModelError(nameof(CategoryRequestModel.Name), "Category name already exists.");
                return BadRequest(this.ModelState);
            }

            var id = await this.categoryService.Create(model.Name);

            return this.Ok(id);
        }

        [HttpPut(id)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody]CategoryRequestModel model)
        {
            var categoryExists = await this.categoryService.Exists(id);
            if (!categoryExists)
            {
                return NotFound("Category does not exist");
            }

            model.Name = model.Name.Trim();

            var categoryNameExists = await this.categoryService.Exists(id, model.Name);
            if (categoryNameExists)
            {
                this.ModelState.AddModelError(nameof(CategoryRequestModel.Name), "Category name already exists");
                return BadRequest(this.ModelState);
            }

            await this.categoryService.Update(id, model.Name);

            return Ok();
        }
    }
}
