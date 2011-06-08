using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ASCOM.Utilities;

namespace ASCOM.Arduino
{
    public partial class FocusControl : Form
    {
        private ManualResetEvent reset = new ManualResetEvent(false);
        private string currentPositionText = "Current Position: ";
        Presets P = new Presets();

        public FocusControl(Focuser f, ref Config c)
        {
            this.Focuser = f;
            this.Config = c;
            InitializeComponent();
        }

        void FocusControl_Shown(object sender, System.EventArgs e)
        {
            this.updownBCSteps.Maximum =
                this.updownIncrementalMove.Maximum =
                this.updownAbsolutePosition.Maximum =
                this.Focuser.MaxStep;

            this.PopulatePresets();

            ThreadPool.QueueUserWorkItem(PollPosition);

            this.checkboxBC.Checked = this.Config.BacklashCompensation;
            this.updownBCSteps.Value = this.Config.BacklashCompensationSteps;
            this.checkboxBCDirection.Checked = this.Config.BacklashCompensationDir;
            this.checkboxReverse.Checked = this.Config.Reversed;

            this.updownIncrementalMove.Value = 1000;
        }

        void FocusControl_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && this.Config.FCBMinimizeToTray)
            {
                this.notifyIcon.Visible = true;
                this.notifyIcon.Text = "Arduino Focuser Control Box";
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void PollPosition(object o)
        {
            while (true)
            {
                this.buttonMoveTo.Enabled = true;
                this.buttonIMIn.Enabled = true;
                this.buttonIMOut.Enabled = true;
                this.buttonPark.Enabled = true;

                this.currentPosition.Text = this.currentPositionText + this.Focuser.Position.ToString();
                while (this.Focuser.IsMoving)
                {
                    this.buttonMoveTo.Enabled = false;
                    this.buttonIMIn.Enabled = false;
                    this.buttonIMOut.Enabled = false;
                    this.buttonPark.Enabled = false;


                    this.currentPosition.Text = this.currentPositionText + "Moving";
                }
            }
        }

        private void PopulatePresets()
        {
            try
            {
                P = Presets.LoadFromXml();

                this.comboSelectPreset.DataSource = null;
                this.comboSelectPreset.DataSource = P;
                this.comboSelectPreset.DisplayMember = "Name";
                this.comboSelectPreset.ValueMember = "Position";
            }
            catch
            {
            }
        }

        private void buttonSavePreset_Click(object sender, EventArgs e)
        {
            try
            {
                int position = this.Focuser.Position;
                string title = this.comboSelectPreset.Text;

                P.AddPreset(new Preset(title, position));

                PopulatePresets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonLoadPreset_Click(object sender, EventArgs e)
        {
            this.doBacklashCompensationMove(Int32.Parse(this.comboSelectPreset.SelectedValue.ToString()));
        }

        private void doBacklashCompensationMove(int position)
        {
            try
            {
                if (this.Config.BacklashCompensation &&
                    !this.Config.BacklashCompensationDir &&
                    (position - this.Focuser.Position < 0) &&
                    (position - this.Config.BacklashCompensationSteps >= 0)) // If BC enabled and inward compensation and inward move and we're not going negative
                {
                    this.Focuser.Move(position - this.Config.BacklashCompensationSteps);
                    this.Focuser.Move(position);
                }
                else if (this.Config.BacklashCompensation &&
                    this.Config.BacklashCompensationDir &&
                    (position - this.Focuser.Position > 0) &&
                    (position + this.Config.BacklashCompensationSteps <= this.Focuser.MaxStep)) // If BC enabled and outward compensation and outward move
                {
                    this.Focuser.Move(position + this.Config.BacklashCompensationSteps);
                    this.Focuser.Move(position);
                }
                else
                {
                    this.Focuser.Move(position);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboSelectPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonSetPosition_Click(object sender, EventArgs e)
        {
            if (this.textboxCustomPosition.Text != "")
            {
                int newPosition = Int32.Parse(this.textboxCustomPosition.Text);

                if (newPosition < this.Focuser.MaxStep)
                    this.Focuser.SetPositionOnFocuser(newPosition);
            }
        }

        private void checkboxReverse_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.checkboxReverse.Checked)
            {
                case true:
                    this.Focuser.ReverseMotorDirection(true);
                    break;
                case false:
                    this.Focuser.ReverseMotorDirection(false);
                    break;
            }
        }

        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            if (this.updownAbsolutePosition.Value >= 0)
                this.doBacklashCompensationMove((int)this.updownAbsolutePosition.Value);
        }

        private void Park(object sender, EventArgs e)
        {
            try
            {
                this.Focuser.Move(0);
            }
            catch
            {
                MessageBox.Show("You have not defined a Park position in presets");
            }
        }

        private void Halt(object sender, EventArgs e)
        {
            this.Focuser.Halt();
        }

        void buttonSlewOut_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Focuser.Move(this.Focuser.MaxStep);
        }

        void buttonSlewOut_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Focuser.Halt();
        }

        void buttonSlewIn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Focuser.Move(0);
        }

        void buttonSlewIn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Focuser.Halt();
        }

        private void buttonManualReset_Click(object sender, EventArgs e)
        {
            this.Focuser.Reset();
        }

        private void updownBCSteps_ValueChanged(object sender, EventArgs e)
        {
            this.Config.BacklashCompensationSteps = (int)this.updownBCSteps.Value;
        }

        private void checkboxBacklashCompensation_CheckedChanged(object sender, EventArgs e)
        {
            this.Config.BacklashCompensation = this.checkboxBC.Checked;
        }

        private void checkboxBCDirection_CheckedChanged(object sender, EventArgs e)
        {
            this.Config.BacklashCompensationDir = this.checkboxBCDirection.Checked;
        }

        private void buttonIMIn_Click(object sender, EventArgs e)
        {
            this.Focuser.Move(this.Focuser.Position - (int)this.updownIncrementalMove.Value);
        }

        private void buttonIMOut_Click(object sender, EventArgs e)
        {
            this.Focuser.Move(this.Focuser.Position + (int)this.updownIncrementalMove.Value);
        }

        private void buttonDeletePreset_Click_1(object sender, EventArgs e)
        {
            Preset p = (Preset)this.comboSelectPreset.SelectedItem;
            P.Remove(p);

            PopulatePresets();
        }

        private void notifyIcon_Click(object sender, System.EventArgs e)
        {
            this.notifyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
    }
}
