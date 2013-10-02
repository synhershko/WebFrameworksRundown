using System.Dynamic;
using System.Web.Mvc;
using SampleWebApp.Common;
using SampleWebApp.Common.ViewModels;

namespace SampleWebApp.MVC4.Controllers
{
    public class QuestionsController : Controller
    {
        [HttpGet]
        public ActionResult Ask()
        {
            dynamic viewModel = new ExpandoObject();
            viewModel.User = new UserViewModel(User) { Id = User.Identity.Name, Name = User.Identity.Name };
            viewModel.Question = new QuestionInputModel();
            return View(viewModel);
        }

        [HttpPost] // Authorize
        public ActionResult Ask(QuestionInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var q = inputModel.ToQuestion();
                q.CreatedBy = "users/1"; // Just a stupid default because we haven't implemented log-in

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            dynamic viewModel = new ExpandoObject();
            viewModel.User = new UserViewModel(User) { Id = User.Identity.Name, Name = User.Identity.Name };
            viewModel.Question = inputModel;
            return View(viewModel);
        }

        public ActionResult View(int id)
        {
            return View(FakeDataGenerator.CreateAFakeQuestion());
        }
    }
}
