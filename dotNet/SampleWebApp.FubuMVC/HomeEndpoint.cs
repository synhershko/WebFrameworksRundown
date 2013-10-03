using System.Collections.Generic;
using SampleWebApp.Common;
using SampleWebApp.Common.Models;

namespace SampleWebApp.FubuMVC
{
    public class HomeEndpoint
    {
        public HomeViewModel Index()
        {
            return new HomeViewModel {Questions = FakeDataGenerator.CreateFakeQuestions()};
        }
    }

    public class HomeViewModel
    {
        public IEnumerable<Question> Questions { get; set; }
    }
}