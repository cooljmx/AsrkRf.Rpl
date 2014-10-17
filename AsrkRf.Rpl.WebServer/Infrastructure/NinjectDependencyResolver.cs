using System.Web.Http.Dependencies;
using Ninject;

namespace AsrkRf.Rpl.WebServer.Infrastructure
{
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver 
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel aKernel) : base(aKernel)
        {
            kernel = aKernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}