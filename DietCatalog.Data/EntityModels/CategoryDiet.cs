namespace DietCatalog.Data.EntityConstants
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryDiet
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int DietId { get; set; }

        public Diet Diet { get; set; }
    }
}
