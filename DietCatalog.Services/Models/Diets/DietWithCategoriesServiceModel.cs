namespace DietCatalog.Services.Models.Diets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Common.Mapping;

    using DietCatalog.Data.EntityConstants;

    public class DietWithCategoriesServiceModel : IMapFrom<Diet>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public virtual void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Diet, DietWithCategoriesServiceModel>()
                .ForMember(b => b.Categories, cfg => cfg
                    .MapFrom(b => b.Categories.Select(c => c.Category.Name)));
        }
    }
}
