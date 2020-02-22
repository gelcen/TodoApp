using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodoApp.Services;
using TodoApp.Views;
using TodoApp.AppObjects;

namespace TodoApp
{
    public partial class App : Application
    {

        public App(AppSetup setup)
        {
            InitializeComponent();

            AppContainer.Container = setup.CreateContainer();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
