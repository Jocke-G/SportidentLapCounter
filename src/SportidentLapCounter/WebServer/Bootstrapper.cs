using Nancy;
using Nancy.Conventions;

namespace SportidentLapCounter.WebServer
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Clear();
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("bootstrap", "/web/bootstrap"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("jquery", "/web/jquery"));
        }

    }
}
