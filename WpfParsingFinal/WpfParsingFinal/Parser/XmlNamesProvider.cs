using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfParsingFinal.Parser
{
    static class XmlNamesProvider
    {
        public static string DataElementName = "data";

        public static string ServerElementName = "server";

        public static string TerminalsElementName = "terminals";

        public static string BeginDateTimeAttributeName = "begindate";

        public static string EndDateTimeAttributeName = "enddate";

        public static string StateAttributeName = "state";

        public static string UpTimeAttributeName = "UpTime";

        public static string TerminalAttributeProtocolName = "protocol";

        public static string TerminalAttributeSerialIdName = "serialId";

        public static string TerminalAttributeSimNumberName = "simNumber";

        public static string TerminalAttributeConnectionTimeName = "connectionTime";

        public static string SensorElementTypeName = "type";

        public static string SensorElementValueName = "value";
    }
}