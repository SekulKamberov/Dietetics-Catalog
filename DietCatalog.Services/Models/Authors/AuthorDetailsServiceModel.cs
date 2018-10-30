namespace DietCatalog.Services.Models.Authors
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Common.Mapping;
    using DietCatalog.Data.EntityConstants;


    public class AuthorDetailsServiceModel : IMapFrom<Author>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Diets { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Author, AuthorDetailsServiceModel>()
                .ForMember(a => a.Diets, cfg => cfg
                    .MapFrom(a => a.Diets.Select(b => b.Title)));
        }
    }
}
