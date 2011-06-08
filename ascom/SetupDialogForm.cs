using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.Arduino
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {

        public SetupDialogForm()
        {
            Config = new Config();

            InitializeComponent();
        }

        void SetupDialogForm_Shown(object sender, System.EventArgs e)
        {
            this.comPort.Items.AddRange(new ASCOM.Utilities.Serial().AvailableCOMPorts);
            this.comPort.SelectedText = this.Config.ComPort;

            this.checkboxUseControlBox.Checked = this.Config.UseFocuserControlBox;
            this.checkboxFocuserControlBoxMinimizeToTray.Checked = this.Config.FCBMinimizeToTray;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(this.comPort.SelectedItem != null)
                this.Config.ComPort = this.comPort.SelectedItem.ToString();
            this.Config.UseFocuserControlBox = this.checkboxUseControlBox.Checked;
            this.Config.FCBMinimizeToTray = this.checkboxFocuserControlBoxMinimizeToTray.Checked;

            Dispose();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BrowseToAscom(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}