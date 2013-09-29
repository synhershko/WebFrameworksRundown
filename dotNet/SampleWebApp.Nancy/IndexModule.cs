using System.Linq;
using Nancy;
using SampleWebApp.Common;
using SampleWebApp.Common.ViewModels;

namespace SampleWebApp.Nancy
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
                           {
                               var questions = FakeDataGenerator.CreateFakeQuestions().ToArray();

                               ViewBag.Header = "Recent questions";
                               ViewBag.User = new UserViewModel();

                               return View["index", questions];
                           };
        }
    }
}