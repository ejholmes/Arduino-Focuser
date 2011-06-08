using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using ASCOM.Utilities;

namespace ASCOM.Arduino
{
    [ComVisible(false)]
    public class Config
    {
        public static string XmlPresetsLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ASCOM.Arduino.Focuser.s_csDriverID + @"\Presets.xml");

        private bool _LinkState                 = false;    // Driver link state, true = connected
        private bool _IsMoving                  = false;    // True if focuser is moving
        private bool _Reversed                  = false;    // True if focuser movement is reversed
        private bool _BacklashCompensation      = false;    // True if backlash compensation is enabled for presets
        private bool _BacklashCompensationDir   = false;    // True = Outward moves, False = Inward moves, Reversed if this.Reversed
        private bool _UseFocuserControlBox      = true;
        private bool _FCBMinimizeToTray         = false;

        private int _BacklashCompensationSteps  = 100;      // Number of steps to travel for backlash compensation
        private int _MaxIncrement               = 13000;    // Maximum number of steps the focuser can travel
        private int _MaxStep                    = 13000;    
        private int _StepSize                   = 2;        // Distance in microns the focuser moves in one step
        private int _Position                   = 0;        // Current focuser position

        private string _ComPort                 = null;     // Com port

        private Profile _Profile = new Profile();

        public Config()
        {
            this._Profile.DeviceType = "Focuser";

            try 
            {
                this._ComPort = this.GetString("ComPort");
            }
            catch { }

            try 
            {
                this._StepSize = this.GetInt("StepSize"); 
            }
            catch { }

            try 
            {
                this._MaxStep = this.GetInt("MaxStep"); 
            }
            catch { }

            try 
            {
                this._MaxIncrement = this.GetInt("MaxIncrement");
            }
            catch { }

            try 
            {
                this._Position = this.GetInt("Position");
            }
            catch { }

            try 
            {
                this._Reversed = this.GetBool("Reversed");
            }
            catch { }

            try
            {
                this._BacklashCompensation = this.GetBool("BacklashCompensation");
            }
            catch { }

            try
            {
                this._BacklashCompensationDir = this.GetBool("BacklashCompensationDir");
            }
            catch { }

            try
            {
                this._BacklashCompensationSteps = this.GetInt("BacklashCompensationSteps");
            }
            catch { }

            try
            {
                this._UseFocuserControlBox = this.GetBool("UseFocuserControlBox");
            }
            catch { }

            try
            {
                this._FCBMinimizeToTray = this.GetBool("FCBMinimizeToTray");
            }
            catch { }
        }




        private void WriteValue(string key, string value)
        {
            this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, key, value);
        }

        private void WriteValue(string key, int value)
        {
            this.WriteValue(key, value.ToString());
        }

        private void WriteValue(string key, bool value)
        {
            this.WriteValue(key, ((value == true) ? 1 : 0).ToString());
        }

        private string GetString(string key)
        {
            return this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, key);
        }

        private int GetInt(string key)
        {
            return Int32.Parse(this.GetString(key));
        }

        private bool GetBool(string key)
        {
            return (this.GetInt(key) == 0) ? false : true;
        }




        public Profile Profile
        {
            get { return this._Profile; }
            set { this._Profile = value; }
        }

        public bool LinkState
        {
            get { return this._LinkState; }
            set { this._LinkState = value; }
        }

        public bool IsMoving
        {
            get { return this._IsMoving; }
            set { this._IsMoving = value; }
        }

        public bool Reversed
        {
            get { return this._Reversed; }
            set 
            {
                this.WriteValue("Reversed", value);
                this._Reversed = value; 
            }
        }

        public int MaxIncrement
        {
            get { return this._MaxIncrement; }
            set 
            {
                this.WriteValue("MaxIncrement", value);
                this._MaxIncrement = value; 
            }
        }

        public int MaxStep
        {
            get { return this._MaxStep; }
            set 
            {
                this.WriteValue("MaxStep", value);
                this._MaxStep = value; 
            }
        }

        public int StepSize
        {
            get { return this._StepSize; }
            set 
            {
                this.WriteValue("StepSize", value);
                this._StepSize = value; 
            }
        }

        public int Position
        {
            get { return this._Position; }
            set 
            {
                this.WriteValue("Position", value);
                this._Position = value; 
            }
        }

        public string ComPort
        {
            get { return this._ComPort; }
            set 
            {
                this.WriteValue("ComPort", value);
                this._ComPort = value; 
            }
        }

        public bool BacklashCompensation
        {
            get { return this._BacklashCompensation; }
            set
            {
                this.WriteValue("BacklashCompensation", value);
                this._BacklashCompensation = value;
            }
        }

        public int BacklashCompensationSteps
        {
            get { return this._BacklashCompensationSteps; }
            set
            {
                this.WriteValue("BacklashCompensationSteps", value);
                this._BacklashCompensationSteps = value;
            }
        }

        public bool BacklashCompensationDir
        {
            get { return this._BacklashCompensationDir; }
            set
            {
                this.WriteValue("BacklashCompensationDir", value);
                this._BacklashCompensationDir = value;
            }
        }

        public bool UseFocuserControlBox
        {
            get { return this._UseFocuserControlBox; }
            set
            {
                this.WriteValue("UseFocuserControlBox", value);
                this._UseFocuserControlBox = value;
            }
        }

        public bool FCBMinimizeToTray
        {
            get { return this._FCBMinimizeToTray; }
            set
            {
                this.WriteValue("FCBMinimizeToTray", value);
                this._FCBMinimizeToTray = value;
            }
        }

    }
}
