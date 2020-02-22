using Autofac;
using TodoApp.AppObjects;
using TodoApp.Model.TodoItems;
using TodoApp.Repository;
using TodoApp.Services;

namespace TodoApp.Droid
{
    public class Setup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);

            var dbPath = new DbPath();

            //Should delete this in future
            cb.RegisterInstance(dbPath).As<IDbPath>(); 

            cb.RegisterType<SqliteRepository>()
              .As<IDataRepository<TodoItem>>()
              .WithParameter(new TypedParameter(
                  typeof(string), dbPath.GetDbPath(AppContainer.DbName)))
              .SingleInstance();
        }
    }
}