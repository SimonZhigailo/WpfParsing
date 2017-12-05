using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfParsingFinal.Model;
using WpfParsingFinal.Parser;

namespace WpfParsingFinal.ViewModel
{
    public class ViewModel : ViewModelBase
    {

        private Data Data;

        public Data _data
        {
            get { return Data; }

            set
            {
                if (Data != value)
                {
                    Data = value;
                    NotifyPropertyChanged("_data");
                }
            }
        }

       

        public DelegateCommand OpenFileCommand { get; set; }

        public ViewModel()
        {
            OpenFileCommand = new DelegateCommand(obj => OpenFileExecute(), obj => true);
        }



       

        private async void OpenFileExecute()
        {
            var openFileDialog = new OpenFileDialog();

            var dialogResult = openFileDialog.ShowDialog();
            if (!dialogResult.HasValue || !dialogResult.Value)
                return;
            var path = openFileDialog.FileName;

            var xmlParser = new XmlParser();
            var data = await xmlParser.ParseFile(path);

            _data = data;

            //CrateData(data);//один из вариантов решения, заполнить представление напрямую задав объектам UI через код здесь
            //Data передаётся, на ней NotifyPropertyChanged и заполнить элементы вручную через CreateData()

            //StatesProvider provider = new StatesProvider();
            //provider.GenerateStates(" ", data);//допилить path (нужен он нет),вызвать метод и забайндить коллекцию на Data через метод GenerateStates
            //можно сделать обработчик событий и связать его с выбранным терминалом, загрузив сенсоры в другой лист

            //    CollectionStates.Add(_data);
            //    foreach(Terminal terminal in data.Terminals){
            //        Terminal.Add(terminal);
            //        foreach (Sensor sensor in terminal.Sensors)
            //        {
            //            TerminalDatas.Add(sensor);
            //        }
            //    }
            //}

            //        public void CustomerViewModel()
            //{
            //    LoadStatesCommand = new DelegateCommand(LoadStates, CanLoadParse);
            //}
            //public void LoadStates(object parameter)
            //{
            //    CollectionStates = StatesProvider.GenerateStates();
            //}
            //         private bool CanLoadParse(object parameter)
            //{
            //    return true;
            //}



        }

        private void CrateData(Model.Data data)
        {
            throw new NotImplementedException();
        }
    }

}