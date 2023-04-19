using Microsoft.AspNetCore.Mvc;
using PaginaPedidos.Database;
using PaginaPedidos.Models;

namespace PaginaPedidos.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> objCategoriaList = _db.Categorias;
            return View(objCategoriaList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria obj)
        {
            _db.Categorias.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

		//get
		public IActionResult Edit(int? id)
		{
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categorias.Find(id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }

			return View(categoryFromDb);
		}
		//post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Categoria obj)
		{
			_db.Categorias.Update(obj);
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

			var categoryFromDb = _db.Categorias.Find(id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}
		//post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Categorias.Find(id);
			if (obj == null) 
			{
				return NotFound();
			}

			_db.Categorias.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
