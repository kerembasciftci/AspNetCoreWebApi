using Autofac;
using System.Reflection;
using Udemy.Core.Repositories;
using Udemy.Core.Services;
using Udemy.Core.UnitOfWorks;
using Udemy.Repository;
using Udemy.Repository.Repositories;
using Udemy.Repository.UnitOfWorks;
using Udemy.Service.Mapping;
using Udemy.Service.Services;
using Module = Autofac.Module;

namespace Udemy.Web.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //InstancePerLifetimeScope = Scope
            //InstancePerDependency = transient










        }
    }
}
