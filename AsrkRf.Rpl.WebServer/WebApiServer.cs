using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using AsrkRf.Rpl.Session;
using AsrkRf.Rpl.WebServer.Infrastructure;
using AsrkRf.Rpl.WebServer.Infrastructure.Concrete;
using Ninject;
using Ninject.Web.Common;

namespace AsrkRf.Rpl.WebServer
{
    public class WebApiServer : IDisposable
    {
        private readonly Bootstrapper bootstrapper = new Bootstrapper();
        private readonly IKernel ninjectKernel;
        private readonly HttpSelfHostServer server;
        private readonly int port;

        public bool IsStarted { get; private set; }

        public WebApiServer(int port)
        {
            ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            RegisterServices(ninjectKernel);

            this.port = port;
            var config = new HttpSelfHostConfiguration(string.Format(@"http://0:{0}/", port))
            {
                MaxReceivedMessageSize = 10*1024*1024,
                MaxBufferSize = 10 * 1024 * 1024,
                DependencyResolver = new NinjectDependencyResolver(ninjectKernel)
            };

            ConfigServer(config);
            server = new HttpSelfHostServer(config);
        }

        private static void ConfigServer(HttpSelfHostConfiguration aConfig)
        {
            aConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public void Start()
        {
            if (!IsStarted)
            {
                bootstrapper.Initialize(CreateKernel);
                server.OpenAsync().Wait();
                IsStarted = true;
                Console.WriteLine(string.Format("Service listener started at port {0}", port));
            }
        }

        public void Stop()
        {
            if (IsStarted)
            {
                server.CloseAsync().Wait();
                bootstrapper.ShutDown();
                IsStarted = false;
                Console.WriteLine("Service listener stopped");
            }
        }

        private IKernel CreateKernel()
        {
            return ninjectKernel;
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISessionHelper>()
                .To<SessionHelper>()
                .WithConstructorArgument("sessionFactoryHelper", new SessionFactoryHelper());
            //kernel.Bind<IDependency>().To<Dependency>();
            //kernel.Bind<ISingletonDependency>().ToConstant(new SingletonDependency());
        }    

        public void Dispose()
        {
            ninjectKernel.Dispose();
            Stop();
            server.Dispose();
        }
    }
}
