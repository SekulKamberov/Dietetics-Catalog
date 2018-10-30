namespace DietCatalog.Services.Models.Diets
{
    using System.Linq;

    using AutoMapper;
    using Common.Mapping;

    using DietCatalog.Data.EntityConstants;


    public class DietDetailsServiceModel : DietWithCategoriesServiceModel, IMapFrom<Diet>, IHaveCustomMapping
    {
        public string Author { get; set; }

        public override void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Diet, DietDetailsServiceModel>()
                .ForMember(b => b.Categories, cfg => cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)))
                .ForMember(b => b.Author, cfg => cfg.MapFrom(b => $"{b.Author.FirstName} {b.Author.LastName}"));
        }
    }
}
