using _036_MoviesMvcWissen.Models.LogDemo;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace _036_MoviesMvcWissen.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            //_kernel.Bind<ILogger>().To<DatabaseLogger>().InSingletonScope();
            //_kernel.Bind<ILogger>().To<DatabaseLogger>().InTransientScope();
            //_kernel.Bind<ILogger>().To<DatabaseLogger>().InThreadScope();
            _kernel.Bind<ILogger>().To<FileLogger>().InThreadScope();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}