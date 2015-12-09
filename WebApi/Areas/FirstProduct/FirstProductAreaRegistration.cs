using System.Web.Mvc;

namespace WebApi.Areas.FirstProduct
{
    public class FirstProductAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FirstProduct";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FirstProduct_default",
                "FirstProduct/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new[] { "WebApi.Areas.FirstProduct" }
            );
        }
    }
}
