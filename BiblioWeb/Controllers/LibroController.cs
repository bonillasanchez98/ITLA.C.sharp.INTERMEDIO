using BiblioWeb.Data.Libro;
using Microsoft.AspNetCore.Mvc;

namespace BiblioWeb.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroDAO _libroDAO;

        public LibroController(ILibroDAO libroDAO)
        {
            _libroDAO = libroDAO;
        }

        // GET: LibroController
        public async Task<IActionResult> Index()
        {
            var restul = await _libroDAO.GetAllBooksAsync();
            if (restul.IsSuccess)
            {
                return View(restul.Data);
            }
            else
            {
                ModelState.AddModelError(string.Empty, restul.Messagge);
                return View(new List<Libro>());
            }
        }

        // GET: LibroController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _libroDAO.GetBookAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: LibroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro libro)
        {
            try
            {
                var result = await _libroDAO.AddBookAsync(libro);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, result.Messagge);
                    return View(libro);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: LibroController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _libroDAO.GetBookAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // POST: LibroController/Edit/5
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

        // GET: LibroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibroController/Delete/5
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
