using HelloWorld.Domain.Contracts;
using System.Web.Mvc;

namespace HelloWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = MvcApplication
                .DependencyResolver
                .GetInstance<IConversationManager>()
                .RequestGreeting();

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
    }
}