using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Generators;
using SampleWebApp.Common.Models;

namespace SampleWebApp.Common
{
    public static class FakeDataGenerator
    {
        private static readonly IList<string> FakeTags = new List<string>
                                                             {
                                                                 "ravendb",
                                                                 "asp.net-mvc",
                                                                 "c#",
                                                                 "linq",
                                                                 "moq",
                                                                 ".net",
                                                                 ".net3.5",
                                                                 "elmah",
                                                                 "yui-compressor",
                                                                 "minify",
                                                                 "mono",
                                                                 "asp.net-mvc3",
                                                                 "ruby-on-rails",
                                                                 "elmah",
                                                                 "rubygems"
                                                             };

        public static IEnumerable<Question> CreateFakeQuestions(int? numberOfFakeQuestions = null)
        {
            if (numberOfFakeQuestions == null)
                numberOfFakeQuestions = GetRandom.Int(20, 100);

            var fakeQuestions = new List<Question>();
            for (int i = 0; i < numberOfFakeQuestions; i++)
            {
                fakeQuestions.Add(CreateAFakeQuestion());
            }

            return fakeQuestions;
        }

        public static Question CreateAFakeQuestion()
        {
            var fakeQuestion = Builder<Question>
                .CreateNew()
                .With(x => x.Id = GetRandom.Int(50, 11515123))
                .With(x => x.Subject = GetRandom.Phrase(GetRandom.Int(10, 50)))
                .With(x => x.Content = GetRandom.Phrase(GetRandom.Int(30, 500)))
                .With(x => x.ViewsCount = GetRandom.Int(0, 100000))
                .And(x => x.CreatedBy = "users/" + GetRandom.Int(1, 20000))
                .And(x => x.CreatedOn = GetRandom.DateTime(DateTime.UtcNow.AddMonths(-1), DateTime.UtcNow.AddMinutes(-5)))
                .And(x => x.Tags = FakeTags.ToRandomList(GetRandom.Int(1, 5)))
                .And(x => x.Answers = GetRandom.Int(0, 25))
                .And(x => x.Comments = GetRandom.Int(0, 10))
                .And(x => x.UpVoteCount = GetRandom.Int(0, 100))
                .And(x => x.DownVoteCount = GetRandom.Int(0, 100))
                .And(x => x.FavoriteCount = GetRandom.Int(0, 100))
                .Build();

            return fakeQuestion;
        }

        private static IList<T> ToRandomList<T>(this IList<T> source, int numberOfItems)
        {
            if (numberOfItems <= 0)
            {
                throw new ArgumentOutOfRangeException("numberOfItems");
            }

            IList<T> results = new List<T>();

            var rng = new RNGCryptoServiceProvider();
            var rndBytes = new byte[4];
            rng.GetBytes(rndBytes);
            int randomNumber = BitConverter.ToInt32(rndBytes, 0);


            // Based upon: http://stackoverflow.com/questions/48087/select-a-random-n-elements-from-listt-in-c
            var rand = new Random(randomNumber);
            double needed = numberOfItems;
            int available = source.Count;

            while (results.Count < numberOfItems)
            {
                if (rand.NextDouble() < needed / available)
                {
                    results.Add(source[available - 1]);
                    needed--;
                }
                available--;
            }

            return results;
        }
    }
}
