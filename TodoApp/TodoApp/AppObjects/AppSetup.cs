using Autofac;

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

        }
    }
}
