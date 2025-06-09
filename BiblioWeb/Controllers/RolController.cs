using BiblioWeb.Data.Categoria;
using BiblioWeb.Data.Rol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiblioWeb.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolDAO _rolDAO;

        public RolController(IRolDAO rolDAO)
        {
            _rolDAO = rolDAO;
        }

        // GET: RolController
        public async Task<IActionResult> Index()
        {
            var result = await _rolDAO.GetAllRoleAsync();

            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(new List<Rol>()); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: RolController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _rolDAO.GetRoleAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: RolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rol rol)
        {
            try
            {
                var result = await _rolDAO.AddRoleAsync(rol);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, result.Messagge);
                    return View(rol);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _rolDAO.GetRoleAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View();
            }
        }

        // POST: RolController/Edit/5
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

        // GET: RolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolController/Delete/5
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
