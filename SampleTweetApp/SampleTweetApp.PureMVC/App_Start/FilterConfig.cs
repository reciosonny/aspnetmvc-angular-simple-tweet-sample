using System.Web;
using System.Web.Mvc;

namespace SampleTweetApp.PureMVC {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
