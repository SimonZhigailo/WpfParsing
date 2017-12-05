using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WpfParsingFinal.Model;

namespace WpfParsingFinal.Parser
{
    class XmlParser
    {
        //загрузка обработанных данных через метод асинхронно используя специальный класс Task
        public async Task<Data> ParseFile(string filePath)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            return await Task<Data>.Factory.StartNew(() => GetData(xmlDocument));
        }

        private static Data GetData(XmlDocument xmlDocument)
        {
            var dataElements = xmlDocument.GetElementsByTagName(XmlNamesProvider.DataElementName);

            if (dataElements.Count != 1)
                throw new Exception("Bad xml format");

            var dataElement = dataElements[0];
            var dataElementAttributes = dataElement.Attributes;

            var dataChildNodes = dataElement.ChildNodes;

            var serverElement = dataElements[0].FirstChild;
            var serverElementsAttributes = serverElement.Attributes;

            var terminals = xmlDocument.GetElementsByTagName(XmlNamesProvider.TerminalsElementName);

            if (terminals.Count != 1)
                throw new Exception("Bad xml format");

            var terminalsElement = terminals[0];
            XmlNodeList terminalList = terminalsElement.ChildNodes;

            Data data = new Data();


            if (dataElementAttributes != null)
                foreach (XmlAttribute attribute in dataElementAttributes)
                {
                    if (attribute.Name == XmlNamesProvider.BeginDateTimeAttributeName)
                    {
                        var begindate = DateTime.ParseExact(attribute.Value, "dd.MM.yyyy - HH:mm:ss", CultureInfo.InvariantCulture);
                        data.BeginDate = begindate;
                    }
                    if (attribute.Name == XmlNamesProvider.EndDateTimeAttributeName)
                    {
                        var enddate = DateTime.ParseExact(attribute.Value, "dd.MM.yyyy - HH:mm:ss", CultureInfo.InvariantCulture);
                        data.EndDate = enddate;
                    }
                }
            if (serverElementsAttributes != null)
            {
                foreach (XmlAttribute attribute in serverElementsAttributes)
                {
                    if (attribute.Name == XmlNamesProvider.StateAttributeName)
                    {
                        string s = attribute.Value.ToString();
                        bool b;
                        if (s.Equals("On") || s.Equals("on") || s.Equals("ON"))
                        {
                            b = true;
                        }
                        else b = false;
                        data.ServerState = b;
                    }
                    if (attribute.Name == XmlNamesProvider.UpTimeAttributeName)
                    {
                        var spantime = TimeSpan.ParseExact(attribute.Value, "dddd\\:hh\\:mm", CultureInfo.InvariantCulture);
                        data.ServerTimeSpan = spantime;
                    }
                }
            }


            ObservableCollection<Terminal> _terminals = new ObservableCollection<Terminal>();
            foreach (XmlNode node in terminalList)
            {
                                Terminal terminal = new Terminal();                
                var TerminalElementAttributes = node.Attributes;
                if (TerminalElementAttributes != null)
                {
                    foreach (XmlAttribute terminalAttribute in TerminalElementAttributes)
                    {
                        if (terminalAttribute.Name == XmlNamesProvider.TerminalAttributeProtocolName)
                        {
                            string s = terminalAttribute.Value.ToString();
                            terminal.Protocol = s;
                        }
                        if (terminalAttribute.Name == XmlNamesProvider.TerminalAttributeSerialIdName)
                        {
                            string s = terminalAttribute.Value.ToString();
                            terminal.SerialId = s;
                        }
                        if (terminalAttribute.Name == XmlNamesProvider.TerminalAttributeSimNumberName)
                        {
                            string s = terminalAttribute.Value.ToString();
                            terminal.SimNumber = s;
                        }
                        if (terminalAttribute.Name == XmlNamesProvider.TerminalAttributeConnectionTimeName)
                        {
                            string s = terminalAttribute.Value.ToString();
                            terminal.ConnectionTime = s;
                        }
                    }

                    
                    if (TerminalElementAttributes[XmlNamesProvider.TerminalAttributeSimNumberName] == null)
                    {
                        terminal.SimNumber = "-";
                    }


                    if (TerminalElementAttributes[XmlNamesProvider.TerminalAttributeConnectionTimeName] == null)
                    {
                        terminal.ConnectionTime = "-";
                    }

                }


                //сенсоры
                ObservableCollection<Sensor> sensors = new ObservableCollection<Sensor>();
                var SensorList = node.ChildNodes;
                if (SensorList != null)
                {
                    foreach (XmlNode _node in SensorList)
                    {
                         Sensor sensor = new Sensor();
                            foreach (XmlAttribute item in _node.Attributes)
                            {
                                if (item.Name == XmlNamesProvider.SensorElementTypeName)
                                {
                                    sensor.Type = item.Value;
                                }
                                if (item.Name == XmlNamesProvider.SensorElementValueName)
                                {
                                    sensor.Value = item.Value;
                                }
                            }

                            sensors.Add(sensor);
                        }
                    }
                
                terminal.Sensors = sensors;
                _terminals.Add(terminal);
            }
            data.Terminals = _terminals;
            return data;
        }


    }
}