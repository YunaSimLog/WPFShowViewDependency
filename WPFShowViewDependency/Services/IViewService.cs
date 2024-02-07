using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFShowViewDependency.Models;

namespace WPFShowViewDependency.Services
{
    public interface IViewService
    {
        void ShowView<TView, TViewModel>(object? parameter = null)
            where TView : Window                            // TView 값은 Window 클래스만 가능하다.
            where TViewModel : INotifyPropertyChanged;      // TViewModel 값을 INotifyPropertyChanged 인터페이스만 가능하다.

        void ShowMainView();

        void ShowSubView(SubData subData);
    }
}
