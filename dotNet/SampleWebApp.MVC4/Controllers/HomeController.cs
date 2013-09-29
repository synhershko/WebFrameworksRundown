using System.Web.Mvc;
using SampleWebApp.Common;
using SampleWebApp.Common.ViewModels;

namespace SampleWebApp.MVC4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.User = new UserViewModel(User);
            ViewBag.Header = "Recent questions";

            var questions = FakeDataGenerator.CreateFakeQuestions();

            return View(questions);
        }
    }
}
