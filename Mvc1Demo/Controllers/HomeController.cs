using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc1Demo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Mvc1Demo.ViewModels;

namespace Mvc1Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;

        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Categories()
        {
            var viewModel = new CategoriesViewModel();
            viewModel.Categories = _context.Categories.Select(dbCat=>new CategoriesViewModel.CategoryViewModel
            {
                Id = dbCat.CategoryId,
                Namn = dbCat.CategoryName
            }).ToList();

            return View(viewModel);
        }


        public IActionResult ProductsInCategory(int Id)
        {
            var viewModel = new ProductsInCategoryViewModel();

            viewModel.CategoryName = _context.Categories.First(r => r.CategoryId == Id).CategoryName;
            viewModel.Products = _context.Products.Where(prod => prod.CategoryId == Id)
                .Select(dbProd=>new ProductsInCategoryViewModel.ProductViewModel
                {
                    Id = dbProd.ProductId,
                    Namn = dbProd.ProductName,
                    Pris = dbProd.UnitPrice.Value
                }).ToList();

            return View(viewModel);
        }

        public IActionResult Contact()
        {
            var model = new ContactViewModel();
            return View(model);
        }

        public IActionResult Thanks()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Thanks");
            }
            return View(model);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
