using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfParsingFinal.ViewModel;

namespace WpfParsingFinal.Model
{
    public class Data : ViewModelBase
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ServerState { get; set; }
        public TimeSpan ServerTimeSpan { get; set; }
        public ObservableCollection<Terminal> Terminals { get; set; }
        private Terminal _selectedTerminal;
        public Terminal SelectedTerminal
        {
            get { return _selectedTerminal; }
            set
            {
                if (value == _selectedTerminal)
                    return;
                _selectedTerminal = value;

                NotifyPropertyChanged("SelectedTerminal");
            }
        }
        public SolidColorBrush ServerColor
        {
            get
            {
                if (ServerState) return new SolidColorBrush(Colors.Blue);
                else return new SolidColorBrush(Colors.Red);
            }
        }
    }
}