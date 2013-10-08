using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simple.Web;

namespace SampleWebApp.SimpleWeb
{
	using UseAction = Action<Func<IDictionary<string, object>, Func<Task>, Task>>;

    public class OwinAppSetup
    {
        public static void Setup(UseAction use)
        {
            use(Application.Run);
        }
    }
}