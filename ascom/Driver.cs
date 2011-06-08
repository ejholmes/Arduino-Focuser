//tabs=4
// --------------------------------------------------------------------------------
// TODO fill in this information for your driver, then remove this line!
//
// ASCOM Focuser driver for Arduino
//
// Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
//				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
//				erat, sed diam voluptua. At vero eos et accusam et justo duo 
//				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
//				sanctus est Lorem ipsum dolor sit amet.
//
// Implements:	ASCOM Focuser interface version: 1.0
// Author:		(XXX) Your N. Here <your@email.here>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// dd-mmm-yyyy	XXX	1.0.0	Initial edit, from ASCOM Focuser Driver template
// --------------------------------------------------------------------------------
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Collections;
using System.Reflection;
using System.Threading;

using ASCOM;
/*using ASCOM.Helper;
using ASCOM.Helper2;*/
using ASCOM.Interface;
using ASCOM.Utilities;

namespace ASCOM.Arduino
{
    //
    // Your driver's ID is ASCOM.Arduino.Focuser
    //
    // The Guid attribute sets the CLSID for ASCOM.Arduino.Focuser
    // The ClassInterface/None addribute prevents an empty interface called
    // _Focuser from being created and used as the [default] interface
    //
    [Guid("71a8f18b-8534-40d8-8651-d65bb07a0b69")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Focuser : IFocuser
    {
        public static string s_csDriverID = "ASCOM.Arduino.Focuser";

        public static string s_csDriverDescription = "Arduino Focuser";

        private bool gtg = true;

        private FocusControl FocuserControl;

        private ArduinoSerial SerialConnection;

        private Util HC = new Util();

        private Config Config = new Config();

        public Focuser()
        {
            FocuserControl = new FocusControl(this, ref Config);
        }

        #region ASCOM Registration

        private static void RegUnregASCOM(bool bRegister)
        {
            Helper.Profile P = new Helper.Profile();
            P.DeviceTypeV = "Focuser";					//  Requires Helper 5.0.3 or later
            if (bRegister)
                P.Register(s_csDriverID, s_csDriverDescription);
            else
                P.Unregister(s_csDriverID);
            try										// In case Helper becomes native .NET
            {
                Marshal.ReleaseComObject(P);
            }
            catch (Exception) { }
            P = null;
        }

        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            RegUnregASCOM(true);
        }

        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            RegUnregASCOM(false);
        }
        #endregion

        #region IFocuser Members

        public bool Absolute
        {
            get { return true; }
        }

        public void Halt()
        {
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Halt);
        }

        public bool IsMoving
        {
            get { return this.Config.IsMoving; }
        }

        public bool Link
        {
            get { return this.Config.LinkState; }
            set 
            {
                switch (value)
                {
                    case true:
                        this.Config.LinkState = ConnectFocuser();
                        break;
                    case false:
                        this.Config.LinkState = !DisconnectFocuser();
                        break;
                }
            }
        }

        public bool ConnectFocuser()
        {
            SerialConnection = new ArduinoSerial();
            SerialConnection.CommandQueueReady += new ArduinoSerial.CommandQueueReadyEventHandler(SerialConnection_CommandQueueReady);

            HC.WaitForMilliseconds(2000);

            ReverseMotorDirection(this.Config.Reversed);
            SetPositionOnFocuser(this.Config.Position);
            
            if(this.Config.UseFocuserControlBox)
                FocuserControl.Show();

            return true;
        }

        private void SerialConnection_CommandQueueReady(object sender, EventArgs e)
        {
            while (SerialConnection.CommandQueue.Count > 0)
            {
                string[] com_args = ((string)SerialConnection.CommandQueue.Pop()).Split(' ');

                string command = com_args[0];

                switch (command)
                {
                    case "P":
                        this.Config.Position = Int32.Parse(com_args[1]);
                        this.gtg = true;
                        break;
                }
            }
        }

        public bool DisconnectFocuser()
        {
            SerialConnection.Close();
            if(this.Config.UseFocuserControlBox)
                FocuserControl.Dispose();
            return true;
        }

        public void ReverseMotorDirection(bool reversed)
        {
            this.Config.Reversed = reversed;
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Reverse, this.Config.Reversed);
        }

        public int MaxIncrement
        {
            get { return this.Config.MaxIncrement; }
        }

        public int MaxStep
        {
            get { return this.Config.MaxStep; }
        }

        public void Move(int val)
        {
            this.Config.IsMoving = true;
            this.MoveAndWait(val);
            this.Config.IsMoving = false;
        }

        private void MoveAndWait(int val)
        {
            this.gtg = false;
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Move, val);

            while (!this.gtg)
                HC.WaitForMilliseconds(100);
        }

        public void SetPositionOnFocuser(int val)
        {
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Position, val);
        }

        public void Reset()
        {
            SerialConnection.ResetConnection();
        }

        public int Position
        {
            get {  return this.Config.Position; }
        }

        public void SetupDialog()
        {
            SetupDialogForm F = new SetupDialogForm();
            F.ShowDialog();
        }

        public double StepSize
        {
            get { return this.Config.StepSize; }
        }

        public bool TempComp
        {
            get { return false; }
            set { throw new PropertyNotImplementedException("TempComp", true); }
        }

        public bool TempCompAvailable
        {
            get { return false; }
        }

        public double Temperature
        {
            get { return 0; }
        }

        #endregion
    }
}
