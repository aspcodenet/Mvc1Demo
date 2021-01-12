using System.Collections.Generic;

namespace Mvc1Demo.ViewModels
{
    public class ProductsInCategoryViewModel
    {
        public string CategoryName { get; set; }
        public List<ProductViewModel> Products { get; set; }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public decimal Pris { get; set; }
        }
    }
}