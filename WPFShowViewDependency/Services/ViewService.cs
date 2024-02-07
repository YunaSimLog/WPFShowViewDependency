﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            var viewModel = (INotifyPropertyChanged) _serviceProvider.GetService(typeof(TViewModel))!;
            var view = (Window) _serviceProvider.GetService(typeof(TView))!;

            view.DataContext=viewModel;
            view.Show();
        }

        public void ShowMainView()
        {
            ShowView<MainView, MainViewModel>();
        }
    }
}
