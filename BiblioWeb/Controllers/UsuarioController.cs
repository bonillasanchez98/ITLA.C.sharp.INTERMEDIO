using BiblioWeb.Data.Categoria;
using BiblioWeb.Data.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace BiblioWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioDAO _usuarioDAO;

        public UsuarioController(IUsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            var result = await _usuarioDAO.GetAllUsersAsync();

            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(new List<Categoria>()); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _usuarioDAO.GetUserAsync(id);
            if (result.IsSuccess)
                return View(result.Data);
            else
            {
                ModelState.AddModelError(string.Empty, result.Messagge);
                return View(); //Si ocurre algun error al llamar las categorias se retorna una lista vacia
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            try
            {
                var result = await _usuarioDAO.AddUserAsync(usuario);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, result.Messagge);
                    return View(usuario);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
                var result = await _usuarioDAO.GetUserAsync(id);
                if (result.IsSuccess)
                    return View(result.Data);
                else
                {
                    ModelState.AddModelError(string.Empty, result.Messagge);
                    return View();
                }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
