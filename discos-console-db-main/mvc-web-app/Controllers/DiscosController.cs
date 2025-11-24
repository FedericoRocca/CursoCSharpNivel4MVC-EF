using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dominio;
using negocio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Humanizer;

namespace mvc_web_app.Controllers
{
    public class DiscosController : Controller
    {
        // GET: DiscosController
        public ActionResult Index()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            var discos = negocio.listar();
            return View(discos);
        }

        // GET: DiscosController/Details/5
        public ActionResult Details(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            return View( discoNegocio.listar().Find(d => d.Id == id) );
        }

        // GET: DiscosController/Create
        public ActionResult Create()
        {
            EstiloNegocio eNegocio = new EstiloNegocio();
            ViewBag.Estilos = new SelectList(eNegocio.listar(), "Id", "Descripcion");
            TipoEdicionNegocio tNegocio = new TipoEdicionNegocio();
            ViewBag.Tipos = new SelectList(eNegocio.listar(), "Id", "Descripcion");
            return View();
        }

        // POST: DiscosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco _disco)
        {
            try
            {
                DiscoNegocio dNegocio = new DiscoNegocio();
                dNegocio.agregar(_disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscosController/Edit/5
        public ActionResult Edit(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            EstiloNegocio estilos = new EstiloNegocio();
            TipoEdicionNegocio edicion = new TipoEdicionNegocio();
            var disco = discoNegocio.listar().Find(d => d.Id == id);
            ViewBag.Estilos = new SelectList(estilos.listar(), "Id", "Descripcion", disco.Estilo.Id);
            ViewBag.Ediciones = new SelectList(edicion.listar(), "Id", "Descripcion", disco.TipoEdicion.Id);
            return View(disco);
        }

        // POST: DiscosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.modificar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscosController/Delete/5
        public ActionResult Delete(int id)
        {
            DiscoNegocio dnegocio = new DiscoNegocio();
            Disco _disco = dnegocio.listar().Find(_disco => _disco.Id == id);
            return View(_disco);
        }

        // POST: DiscosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Disco _disco)
        {
            try
            {
                DiscoNegocio dNegocio = new DiscoNegocio();
                dNegocio.eliminar(_disco.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
