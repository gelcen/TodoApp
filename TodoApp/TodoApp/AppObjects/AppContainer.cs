using Autofac;

namespace TodoApp.AppObjects
{
    public static class AppContainer
    {
        public const string DbName = "TodoApp.db";
        public static IContainer Container { get; set; }
    }
}
