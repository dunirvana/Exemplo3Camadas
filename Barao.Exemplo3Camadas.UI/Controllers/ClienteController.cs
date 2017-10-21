using Barao.Exemplo3Camadas.BLL;
using Barao.Exemplo3Camadas.DTO;
using System.Web.Mvc;

namespace Barao.Exemplo3Camadas.UI.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLO bll = new ClienteBLO();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(bll.SelecionarTodos());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            return View(bll.SelecionarPorId(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,SobreNome,DataCadastro")] ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                if (bll.Inserir(cliente))
                    return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Erro ao inserir!");
                    return View(cliente);
                }
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(bll.SelecionarPorId(id));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,SobreNome,DataCadastro")] ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                if (bll.Atualizar(cliente))
                    return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Erro ao atualizar!");
                    return View(cliente);
                }
            }

            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(bll.SelecionarPorId(id));
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (bll.Remover(id))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "Erro ao remover!");
                return RedirectToAction("Delete", id);
            }            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bll.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
