namespace ArandaSoft.Test.API
{
    using System.Web.Http;
    using ArandaSoft.Test.Service.Implementation.AppService;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            MappingProfile mapping = new MappingProfile();
            mapping.Start();
        }
    }
}
