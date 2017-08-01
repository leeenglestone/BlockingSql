using System.Web.Mvc;
using BlockingSql.MvcWebApplication.Models;

namespace BlockingSql.MvcWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new BlockingSqlModel(SqlHelper.GetBlockingSqlStatements());
            return View(model);
        }
    }
}