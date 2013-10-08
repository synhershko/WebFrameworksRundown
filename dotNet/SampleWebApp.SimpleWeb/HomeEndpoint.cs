using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Web;
using Simple.Web.Behaviors;

namespace SampleWebApp.SimpleWeb
{
    [UriTemplate("/")]
    public class HomeEndpoint : IGet //, IOutput<RawHtml>
    {
        public Status Get()
        {
            Title = "foo";
            //Output = "Hello!!";
            return 200;
        }

        public String Title { get; set; }
        //public RawHtml Output { get; private set; }
    }
}