using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFShowViewDependency.ViewModels
{
    partial interface IParameterReceiver
    {
        void ReceiveParameter(object parameter);
    }
}
