namespace DietCatalog.Data.EntityConstants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using static DietCatalog.Data.EntityModels.EntityConstants;

    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string LastName { get; set; }

        public ICollection<Diet> Diets { get; set; } = new List<Diet>();
    }
}
