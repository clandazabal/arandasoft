using System;
using System.Configuration;
using System.Net.Http;
using System.Web.Http;
using ArandaSoft.Test.API;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ArandaSoft.Test.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger("docs/{apiVersion}/OpenAPI", c =>
                    {
                        c.RootUrl(req => req.RequestUri.GetLeftPart(UriPartial.Authority) + req.GetRequestContext().VirtualPathRoot.TrimEnd('/'));
                        c.SingleApiVersion("v1", "ArandaSoft TestAPI")
                            .Description("API documentation for Test API - ArandaSoft")
                            .Contact(cc => cc
                                .Name(ConfigurationManager.AppSettings["SwaggerContactName"])
                                .Email(ConfigurationManager.AppSettings["SwaggerContactEmail"]));
                    })
                .EnableSwaggerUi(c => {
                    });
        }
    }
}
