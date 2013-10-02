using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using SampleWebApp.Common;
using SampleWebApp.Common.Models;
using SampleWebApp.Common.ViewModels;

namespace SampleWebApp.Nancy
{
    public class QuestionsModule : NancyModule
    {
        public QuestionsModule() : base("/questions")
        {
            // For routes, see https://github.com/NancyFx/Nancy/wiki/Defining-routes

            Get["/view/{id}"] = p =>
                                    {
                                        return View["View", FakeDataGenerator.CreateAFakeQuestion()];
                                    };

            Get["/ask"] = p =>
                              {
                                  return View["Ask", new QuestionInputModel()];
                              };

            Post["/ask"] = p =>
                               {
                                   var question = this.Bind<QuestionInputModel>();
                                   
                                   // TODO validate question
                                   
                                   return "Success";
                               };
        }
    }
}