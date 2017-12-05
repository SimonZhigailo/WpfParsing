using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfParsingFinal.ViewModel
//The INotifyPropertyChanged interface is the key for data binding. If the data changes in the view models need to be reflected
//in the XAML components through bindings, all the view models in a Silverlight MVVM application need to implement this interface.
{
    public abstract class ViewModelBase
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
