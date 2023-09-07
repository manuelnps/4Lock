using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_4Lock.UserControls
{
    public class ComPortManager
    {
        private static SerialPort serialPort;

        public static SerialPort GetSerialPort()
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort("COM5", 9600);
                serialPort.Open();
            }
            return serialPort;
        }

        public static void CloseSerialPort()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }

}
