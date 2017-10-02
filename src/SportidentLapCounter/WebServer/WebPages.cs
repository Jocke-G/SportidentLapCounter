using Nancy;
using Nancy.Json;
using SportidentLapCounter.Services;

namespace SportidentLapCounter.WebServer
{
    public class WebPages : NancyModule
    {
        private PersistenceService _persistenceService;
        private readonly JavaScriptSerializer _javaScriptSerializer;

        public WebPages()
        {
            _javaScriptSerializer = new JavaScriptSerializer
            {
                RetainCasing = true
            };
            _persistenceService = new PersistenceService();

            Get["/"] = x =>
            {
                //return "Wee hoo! - no more little green monster...";
                return View["web/index.html"];   //<-- sending back a view page
            };

            Get["/results/"] = x =>
            {
                //return "Wee hoo! - no more little green monster...";
                return View["web/results/index.html"];   //<-- sending back a view page
            };

            Get["/json/results.json"] = x =>
            {

                var results = _persistenceService.Load();
                return _javaScriptSerializer.Serialize(results.Teams);
            };
        }
    }
}
