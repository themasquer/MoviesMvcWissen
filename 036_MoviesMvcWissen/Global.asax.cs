using _036_MoviesMvcWissen.Infrastructure;
using FluentValidation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _036_MoviesMvcWissen
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider() { AddImplicitRequiredValidator = false });

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
