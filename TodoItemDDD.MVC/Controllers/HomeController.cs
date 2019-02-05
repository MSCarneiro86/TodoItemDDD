using System.Linq;
using System.Web.Mvc;
using TodoItemDDD.Application.Interface;

namespace TodoItemDDD.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEnderecoAppService _enderecoApp;

        private readonly ICategoriaAppService _categoriaApp;

        private readonly IClienteAppService _clienteApp;

        public HomeController(IEnderecoAppService enderecoApp, ICategoriaAppService categoriaApp, IClienteAppService clienteApp)
        {
            _enderecoApp = enderecoApp;
            _categoriaApp = categoriaApp;
            _clienteApp = clienteApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        public ActionResult Menu()
        {
            var menu = _categoriaApp.ListaCategoriasPai();

            return PartialView("_Menu",menu);
        }

        [HttpGet]
        public JsonResult ObterCidades()
        {
           
            var enderecos = _clienteApp.ListarEnderecos();

            return Json(enderecos, JsonRequestBehavior.AllowGet);
        }
    }
}