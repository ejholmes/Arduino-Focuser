using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace ASCOM.Arduino
{
    class ArduinoSerial : SerialPort 
    {
        ASCOM.Utilities.Util HC = new ASCOM.Utilities.Util(); // Helper class
        public Stack CommandQueue = new Stack(); // Our command received stack

        public delegate void CommandQueueReadyEventHandler(object sender, EventArgs e); // Our Process stack callback
        public event CommandQueueReadyEventHandler CommandQueueReady; 

        // Serial commands look like ": M 100 #"
        public struct SerialCommand
        {
            public struct Syntax
            {
                public static string Start      = ":";
                public static string End        = "#";
                public static string Spacer     = " ";
            }

            public static string Halt           = "H";
            public static string Move           = "M";
            public static string Position       = "P";
            public static string Reverse        = "R";
        }

        public ArduinoSerial(StopBits stopBits, int baud, bool autostart)
        {
            this.Parity = Parity.None;
            this.PortName = new Config().ComPort;
            this.StopBits = stopBits;
            this.BaudRate = baud;
            this.DataReceived += new SerialDataReceivedEventHandler(ArduinoSerial_DataReceived);

            if (autostart)
                this.Open();
        }

        public ArduinoSerial() : this(StopBits.One, 9600, true) { } 

        private void ArduinoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            CommandQueue.Push(this.ReadLine().Trim("\r".ToCharArray())); // Push latest command onto the stack
            CommandQueueReady(this, e);
        }

        public void SendCommand(string command, object arg1)
        {
            this.Write(this.BuildSerialCommand(command, arg1));
        }

        public void SendCommand(string command)
        {
            this.Write(this.BuildSerialCommand(command));
        }

        private string BuildSerialCommand(string command)
        {
            return SerialCommand.Syntax.Start + 
                SerialCommand.Syntax.Spacer + 
                command + 
                SerialCommand.Syntax.Spacer + 
                SerialCommand.Syntax.End;
        }

        private string BuildSerialCommand(string command, object arg1)
        {
            return SerialCommand.Syntax.Start + 
                SerialCommand.Syntax.Spacer + 
                command + 
                SerialCommand.Syntax.Spacer + 
                arg1.ToString() + 
                SerialCommand.Syntax.Spacer + 
                SerialCommand.Syntax.End;
        }

        public void ResetConnection()
        {
            this.Close();
            HC.WaitForMilliseconds(1000);
            this.Open();
            HC.WaitForMilliseconds(3000);
        }
    }
}
