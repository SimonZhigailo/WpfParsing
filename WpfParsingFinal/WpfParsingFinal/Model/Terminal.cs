using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfParsingFinal.ViewModel;

namespace WpfParsingFinal.Model
{
    public class Terminal : ViewModelBase
    {
        public string Protocol { get; set; }
        public string SerialId { get; set; }
        public string SimNumber { get; set; }
        public string ConnectionTime { get; set; }
        public ObservableCollection<Sensor> Sensors { get; set; }
    }
}
