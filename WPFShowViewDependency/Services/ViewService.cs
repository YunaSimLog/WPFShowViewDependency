using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFShowViewDependency.Models;
using WPFShowViewDependency.ViewModels;
using WPFShowViewDependency.Views;

namespace WPFShowViewDependency.Services
{
    public class ViewService : IViewService
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowView<TView, TViewModel>(object? parameter = null) where TView : Window where TViewModel : INotifyPropertyChanged
        {
            var viewModel = (INotifyPropertyChanged)_serviceProvider.GetService(typeof(TViewModel))!;
            var view = (Window)_serviceProvider.GetService(typeof(TView))!;

            if (parameter != null && viewModel is IParameterReceiver parameterReceiver)
            {
                parameterReceiver.ReceiveParameter(parameter);
            }

            view.DataContext = viewModel;
            view.Show();
        }

        public void ShowMainView()
        {
            ShowView<MainView, MainViewModel>();
        }

        private bool ActivateView<TView>() where TView : Window
        {
            IEnumerable<Window> windows = Application.Current.Windows.OfType<TView>();
            if (windows.Any())
            {
                windows.ElementAt(0).Activate();
                return true;
            }
            return false;
        }

        public void ShowSubView(SubData subData)
        {
            if (!ActivateView<SubView>())
            {
                ShowView<SubView, SubViewModel>(subData);
            }
        }
    }
}
