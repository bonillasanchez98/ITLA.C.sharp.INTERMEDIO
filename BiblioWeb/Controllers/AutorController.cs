using BiblioWeb.Data.Autor;
using BiblioWeb.Data.Rol;
using Microsoft.AspNetCore.Mvc;

namespace BiblioWeb.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorDAO _autorDAO;

        public AutorController(IAutorDAO autorDAO)
        {
            _autorDAO = autorDAO;
        }


        // GET: AutorController
        public async Task<IActionResult> Index()
        {
            var result = await _autorDAO.GetAllAuthorsAsync();

            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(new List<Autor>()); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: AutorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _autorDAO.GetAuthorAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autor autor)
        {
            try
            {
                var result = await _autorDAO.AddAuthorAsync(autor);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, result.Messagge);
                    return View(autor);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _autorDAO.GetAuthorAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View();
            }
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AutorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutorController/Delete/5
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
