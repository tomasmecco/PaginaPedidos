using Microsoft.AspNetCore.Mvc;
using PaginaPedidos.Database;
using PaginaPedidos.Models;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace PaginaPedidos.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public ProductoController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.Products;
            return View(objProductList);
        }
        //get
        public IActionResult Create()
        {
			var categorias = _db.Categorias.ToList();

			var model = new ProductDTO()
            {
                Categorias = categorias
            };
            return View(model);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductDTO obj)
        {
            var product = _mapper.Map<Product>(obj);
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Products.Find(id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<ProductDTO>(productFromDb);
            model.Categorias = _db.Categorias.ToList();

            return View(model);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductDTO obj)
        {
            var product = _mapper.Map<Product>(obj);
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        //get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Products.Find(id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
