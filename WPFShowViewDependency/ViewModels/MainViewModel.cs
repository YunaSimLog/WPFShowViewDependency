using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFShowViewDependency.Services;

namespace WPFShowViewDependency.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly IViewService _viewService;

        public MainViewModel(IViewService viewService)
        {
            _viewService = viewService;
        }
        private void ShowSubView(object? _)
        {
            _viewService.ShowSubView(new Models.SubData()
            {
                StringData = "가나다",
                IntData = 123
            });
        }

        public ICommand ShowSubViewCommand => new RelayCommand<object>(ShowSubView);

       
    }
}
