using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Mvc1Demo.ViewModels
{
    public class CategoriesViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }

        public class CategoryViewModel
        {
            public int Id { get; set; }
            public string Namn { get; set; }
        }
    }
    
}