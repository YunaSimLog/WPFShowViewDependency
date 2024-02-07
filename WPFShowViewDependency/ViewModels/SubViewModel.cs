using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WPFShowViewDependency.Models;

namespace WPFShowViewDependency.ViewModels
{
    internal class SubViewModel : ObservableObject, IParameterReceiver
    {
        public SubData SubData { get; set; } = default!;

        public void ReceiveParameter(object parameter)
        {
            if (parameter is SubData subData)
            {
                SubData=subData;
            }
        }
    }
}
