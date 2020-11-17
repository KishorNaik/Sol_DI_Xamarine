using Microsoft.Extensions.DependencyInjection;
using Sol_Demo.Services;
using Sol_Demo.ViewModels;
using Sol_Demo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sol_Demo
{
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureService();

            InitializeComponent();

            MainPage = new MainPage();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private static IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();

            // Service
            services.AddTransient<IUserService, UserService>();

            // ViewModel
            services.AddTransient<UserViewModel>();

            return services.BuildServiceProvider();
        }
    }
}