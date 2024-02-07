using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WPFShowViewDependency.Services;
using WPFShowViewDependency.ViewModels;
using WPFShowViewDependency.Views;

namespace WPFShowViewDependency
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _services = default;

        private IServiceProvider ConfigurationService()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainView>();

            // Services
            services.AddSingleton<IViewService, ViewService>();

            // ViewModels
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }

        public App()
        {
            _services = ConfigurationService();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewService = (IViewService)_services.GetService(typeof(IViewService))!;
            viewService.ShowMainView();
        }
    }
}
