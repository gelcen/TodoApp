using Autofac;
using TodoApp.Model.TodoItems;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.AppObjects
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var cb = new ContainerBuilder();
            RegisterDependencies(cb);
            return cb.Build();
        }

        protected virtual 
            void RegisterDependencies(ContainerBuilder cb)
        {
            cb.RegisterType<TodosMockRepository>()
                .As<IDataRepository<TodoItem>>().SingleInstance();
            cb.RegisterType<ItemsViewModel>().AsSelf();
        }
    }
}
