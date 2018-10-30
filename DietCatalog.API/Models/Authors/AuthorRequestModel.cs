namespace DietCatalog.API.Models.Authors
{
    using System.ComponentModel.DataAnnotations;

    using static Data.EntityModels.EntityConstants;

    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(AuthorMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string LastName { get; set; }
    }
}
