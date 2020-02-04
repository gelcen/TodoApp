using Autofac;
using TodoApp.AppObjects;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    public class ViewModelWrapper<T> where T : IViewModel
    {
        public T ViewModel { get; }

        public ViewModelWrapper()
        {
            using (var scope = AppContainer.Container.BeginLifetimeScope())
            {
                ViewModel = scope.Resolve<T>();
            }
        }
    }
}
