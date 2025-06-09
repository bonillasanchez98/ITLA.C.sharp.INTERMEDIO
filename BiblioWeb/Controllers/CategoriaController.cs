using Biblio.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiblioWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaDAO _categoriaDAO;

        public CategoriaController(ICategoriaDAO categoriaDAO)
        {
            this._categoriaDAO = categoriaDAO;
        }

        // GET: CategoriaController
        public async Task<IActionResult> Index()
        {
            var result = await _categoriaDAO.GetAllCategoriesAsync();

            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(new List<Categoria>()); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _categoriaDAO.GetCategoryAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            try
            {
                var result = await _categoriaDAO.AddCategoryAsync(categoria);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, result.Messagge);
                    return View(categoria);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
                var result = await _categoriaDAO.GetCategoryAsync(id);
                if (result.IsSuccess)
                    return View(result.Data);
                else
                {
                    ModelState.AddModelError(string.Empty, result.Messagge);
                    return View();
                }
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categoria categoria)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
