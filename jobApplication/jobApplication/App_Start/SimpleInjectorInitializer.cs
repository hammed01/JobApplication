[assembly: WebActivator.PostApplicationStartMethod(typeof(jobApplication.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace jobApplication.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using jobApplication;
    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using jobApplication.DataAccess;
    using jobApplication.Helpers;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
//#error Register your services here (remove this line).

            // For instance:
             container.Register <IApplicantDataServices, ApplicantDataServices>(Lifestyle.Scoped);
            container.Register<IAdminDataServices, AdminDataServices>(Lifestyle.Scoped);
            container.Register <IDataReaderHelper, DataReaderHelper>(Lifestyle.Scoped);
        }
    }
}