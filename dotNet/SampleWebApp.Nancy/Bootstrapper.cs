using Nancy;
using Nancy.Diagnostics;

namespace SampleWebApp.Nancy
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ApplicationStartup(global::Nancy.TinyIoc.TinyIoCContainer container, global::Nancy.Bootstrapper.IPipelines pipelines)
        {
            // Can now use this.Context.Trace.TraceLog.WriteLog(s => s.AppendLine(“Root path was called”)); from route handlers
            StaticConfiguration.EnableRequestTracing = true;
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = "12345" }; }
        }
    }
}