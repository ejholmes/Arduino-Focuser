namespace ASCOM.Arduino
{
    partial class FocusControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusControl));
            this.comboSelectPreset = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupboxBacklashCompensation = new System.Windows.Forms.GroupBox();
            this.updownBCSteps = new System.Windows.Forms.NumericUpDown();
            this.labelBCSteps = new System.Windows.Forms.Label();
            this.checkboxBCDirection = new System.Windows.Forms.CheckBox();
            this.checkboxBC = new System.Windows.Forms.CheckBox();
            this.buttonDeletePreset = new System.Windows.Forms.Button();
            this.buttonSavePreset = new System.Windows.Forms.Button();
            this.buttonLoadPreset = new System.Windows.Forms.Button();
            this.groupboxOptions = new System.Windows.Forms.GroupBox();
            this.buttonSetPosition = new System.Windows.Forms.Button();
            this.textboxCustomPosition = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkboxReverse = new System.Windows.Forms.CheckBox();
            this.groupboxAbsoluteMovement = new System.Windows.Forms.GroupBox();
            this.updownAbsolutePosition = new System.Windows.Forms.NumericUpDown();
            this.buttonPark = new System.Windows.Forms.Button();
            this.buttonHalt = new System.Windows.Forms.Button();
            this.buttonMoveTo = new System.Windows.Forms.Button();
            this.buttonSlewOut = new System.Windows.Forms.Button();
            this.buttonSlewIn = new System.Windows.Forms.Button();
            this.buttonManualReset = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.currentPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupboxIncremental = new System.Windows.Forms.GroupBox();
            this.buttonIMOut = new System.Windows.Forms.Button();
            this.buttonIMIn = new System.Windows.Forms.Button();
            this.updownIncrementalMove = new System.Windows.Forms.NumericUpDown();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupboxBacklashCompensation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownBCSteps)).BeginInit();
            this.groupboxOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupboxAbsoluteMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownAbsolutePosition)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.groupboxIncremental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownIncrementalMove)).BeginInit();
            this.SuspendLayout();
            // 
            // comboSelectPreset
            // 
            this.comboSelectPreset.FormattingEnabled = true;
            this.comboSelectPreset.Location = new System.Drawing.Point(6, 17);
            this.comboSelectPreset.Name = "comboSelectPreset";
            this.comboSelectPreset.Size = new System.Drawing.Size(126, 21);
            this.comboSelectPreset.TabIndex = 0;
            this.comboSelectPreset.SelectedIndexChanged += new System.EventHandler(this.comboSelectPreset_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDeletePreset);
            this.groupBox1.Controls.Add(this.buttonSavePreset);
            this.groupBox1.Controls.Add(this.buttonLoadPreset);
            this.groupBox1.Controls.Add(this.comboSelectPreset);
            this.groupBox1.Location = new System.Drawing.Point(9, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presets";
            // 
            // groupboxBacklashCompensation
            // 
            this.groupboxBacklashCompensation.Controls.Add(this.updownBCSteps);
            this.groupboxBacklashCompensation.Controls.Add(this.labelBCSteps);
            this.groupboxBacklashCompensation.Controls.Add(this.checkboxBCDirection);
            this.groupboxBacklashCompensation.Controls.Add(this.checkboxBC);
            this.groupboxBacklashCompensation.Location = new System.Drawing.Point(9, 260);
            this.groupboxBacklashCompensation.Name = "groupboxBacklashCompensation";
            this.groupboxBacklashCompensation.Size = new System.Drawing.Size(227, 72);
            this.groupboxBacklashCompensation.TabIndex = 4;
            this.groupboxBacklashCompensation.TabStop = false;
            this.groupboxBacklashCompensation.Text = "Backlash Compensation";
            // 
            // updownBCSteps
            // 
            this.updownBCSteps.Location = new System.Drawing.Point(53, 41);
            this.updownBCSteps.Name = "updownBCSteps";
            this.updownBCSteps.Size = new System.Drawing.Size(74, 20);
            this.updownBCSteps.TabIndex = 4;
            this.updownBCSteps.ValueChanged += new System.EventHandler(this.updownBCSteps_ValueChanged);
            // 
            // labelBCSteps
            // 
            this.labelBCSteps.AutoSize = true;
            this.labelBCSteps.Location = new System.Drawing.Point(12, 44);
            this.labelBCSteps.Name = "labelBCSteps";
            this.labelBCSteps.Size = new System.Drawing.Size(34, 13);
            this.labelBCSteps.TabIndex = 3;
            this.labelBCSteps.Text = "Steps";
            // 
            // checkboxBCDirection
            // 
            this.checkboxBCDirection.AutoSize = true;
            this.checkboxBCDirection.Location = new System.Drawing.Point(87, 19);
            this.checkboxBCDirection.Name = "checkboxBCDirection";
            this.checkboxBCDirection.Size = new System.Drawing.Size(118, 17);
            this.checkboxBCDirection.TabIndex = 1;
            this.checkboxBCDirection.Text = "On Outward Moves";
            this.checkboxBCDirection.UseVisualStyleBackColor = true;
            this.checkboxBCDirection.CheckedChanged += new System.EventHandler(this.checkboxBCDirection_CheckedChanged);
            // 
            // checkboxBC
            // 
            this.checkboxBC.AutoSize = true;
            this.checkboxBC.Location = new System.Drawing.Point(15, 19);
            this.checkboxBC.Name = "checkboxBC";
            this.checkboxBC.Size = new System.Drawing.Size(65, 17);
            this.checkboxBC.TabIndex = 0;
            this.checkboxBC.Text = "Enabled";
            this.checkboxBC.UseVisualStyleBackColor = true;
            this.checkboxBC.CheckedChanged += new System.EventHandler(this.checkboxBacklashCompensation_CheckedChanged);
            // 
            // buttonDeletePreset
            // 
            this.buttonDeletePreset.Image = global::ASCOM.Arduino.Properties.Resources.delete;
            this.buttonDeletePreset.Location = new System.Drawing.Point(196, 15);
            this.buttonDeletePreset.Name = "buttonDeletePreset";
            this.buttonDeletePreset.Size = new System.Drawing.Size(23, 23);
            this.buttonDeletePreset.TabIndex = 3;
            this.buttonDeletePreset.UseVisualStyleBackColor = true;
            this.buttonDeletePreset.Click += new System.EventHandler(this.buttonDeletePreset_Click_1);
            // 
            // buttonSavePreset
            // 
            this.buttonSavePreset.Image = global::ASCOM.Arduino.Properties.Resources.save;
            this.buttonSavePreset.Location = new System.Drawing.Point(167, 15);
            this.buttonSavePreset.Name = "buttonSavePreset";
            this.buttonSavePreset.Size = new System.Drawing.Size(23, 23);
            this.buttonSavePreset.TabIndex = 3;
            this.buttonSavePreset.UseVisualStyleBackColor = true;
            this.buttonSavePreset.Click += new System.EventHandler(this.buttonSavePreset_Click);
            // 
            // buttonLoadPreset
            // 
            this.buttonLoadPreset.Image = global::ASCOM.Arduino.Properties.Resources.open;
            this.buttonLoadPreset.Location = new System.Drawing.Point(138, 15);
            this.buttonLoadPreset.Name = "buttonLoadPreset";
            this.buttonLoadPreset.Size = new System.Drawing.Size(23, 23);
            this.buttonLoadPreset.TabIndex = 1;
            this.buttonLoadPreset.UseVisualStyleBackColor = true;
            this.buttonLoadPreset.Click += new System.EventHandler(this.buttonLoadPreset_Click);
            // 
            // groupboxOptions
            // 
            this.groupboxOptions.Controls.Add(this.buttonSetPosition);
            this.groupboxOptions.Controls.Add(this.textboxCustomPosition);
            this.groupboxOptions.Location = new System.Drawing.Point(9, 338);
            this.groupboxOptions.Name = "groupboxOptions";
            this.groupboxOptions.Size = new System.Drawing.Size(227, 48);
            this.groupboxOptions.TabIndex = 4;
            this.groupboxOptions.TabStop = false;
            this.groupboxOptions.Text = "Manually Define Position";
            // 
            // buttonSetPosition
            // 
            this.buttonSetPosition.Location = new System.Drawing.Point(75, 18);
            this.buttonSetPosition.Name = "buttonSetPosition";
            this.buttonSetPosition.Size = new System.Drawing.Size(146, 23);
            this.buttonSetPosition.TabIndex = 1;
            this.buttonSetPosition.Text = "Set Custom Position";
            this.buttonSetPosition.UseVisualStyleBackColor = true;
            this.buttonSetPosition.Click += new System.EventHandler(this.buttonSetPosition_Click);
            // 
            // textboxCustomPosition
            // 
            this.textboxCustomPosition.Location = new System.Drawing.Point(9, 20);
            this.textboxCustomPosition.Name = "textboxCustomPosition";
            this.textboxCustomPosition.Size = new System.Drawing.Size(60, 20);
            this.textboxCustomPosition.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkboxReverse);
            this.groupBox2.Location = new System.Drawing.Point(9, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 54);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reverse Motor Direction";
            // 
            // checkboxReverse
            // 
            this.checkboxReverse.AutoSize = true;
            this.checkboxReverse.Location = new System.Drawing.Point(85, 25);
            this.checkboxReverse.Name = "checkboxReverse";
            this.checkboxReverse.Size = new System.Drawing.Size(66, 17);
            this.checkboxReverse.TabIndex = 0;
            this.checkboxReverse.Text = "Reverse";
            this.checkboxReverse.UseVisualStyleBackColor = true;
            this.checkboxReverse.CheckedChanged += new System.EventHandler(this.checkboxReverse_CheckedChanged);
            // 
            // groupboxAbsoluteMovement
            // 
            this.groupboxAbsoluteMovement.Controls.Add(this.updownAbsolutePosition);
            this.groupboxAbsoluteMovement.Controls.Add(this.buttonPark);
            this.groupboxAbsoluteMovement.Controls.Add(this.buttonHalt);
            this.groupboxAbsoluteMovement.Controls.Add(this.buttonMoveTo);
            this.groupboxAbsoluteMovement.Location = new System.Drawing.Point(9, 12);
            this.groupboxAbsoluteMovement.Name = "groupboxAbsoluteMovement";
            this.groupboxAbsoluteMovement.Size = new System.Drawing.Size(227, 77);
            this.groupboxAbsoluteMovement.TabIndex = 6;
            this.groupboxAbsoluteMovement.TabStop = false;
            this.groupboxAbsoluteMovement.Text = "Absolute Movement";
            // 
            // updownAbsolutePosition
            // 
            this.updownAbsolutePosition.Location = new System.Drawing.Point(9, 20);
            this.updownAbsolutePosition.Name = "updownAbsolutePosition";
            this.updownAbsolutePosition.Size = new System.Drawing.Size(74, 20);
            this.updownAbsolutePosition.TabIndex = 4;
            // 
            // buttonPark
            // 
            this.buttonPark.Location = new System.Drawing.Point(89, 45);
            this.buttonPark.Name = "buttonPark";
            this.buttonPark.Size = new System.Drawing.Size(60, 23);
            this.buttonPark.TabIndex = 2;
            this.buttonPark.Text = "Park";
            this.buttonPark.UseVisualStyleBackColor = true;
            this.buttonPark.Click += new System.EventHandler(this.Park);
            // 
            // buttonHalt
            // 
            this.buttonHalt.Location = new System.Drawing.Point(155, 18);
            this.buttonHalt.Name = "buttonHalt";
            this.buttonHalt.Size = new System.Drawing.Size(60, 23);
            this.buttonHalt.TabIndex = 2;
            this.buttonHalt.Text = "Halt";
            this.buttonHalt.UseVisualStyleBackColor = true;
            this.buttonHalt.Click += new System.EventHandler(this.Halt);
            // 
            // buttonMoveTo
            // 
            this.buttonMoveTo.Location = new System.Drawing.Point(89, 18);
            this.buttonMoveTo.Name = "buttonMoveTo";
            this.buttonMoveTo.Size = new System.Drawing.Size(60, 23);
            this.buttonMoveTo.TabIndex = 1;
            this.buttonMoveTo.Text = "Move To";
            this.buttonMoveTo.UseVisualStyleBackColor = true;
            this.buttonMoveTo.Click += new System.EventHandler(this.buttonMoveTo_Click);
            // 
            // buttonSlewOut
            // 
            this.buttonSlewOut.Location = new System.Drawing.Point(144, 77);
            this.buttonSlewOut.Name = "buttonSlewOut";
            this.buttonSlewOut.Size = new System.Drawing.Size(75, 23);
            this.buttonSlewOut.TabIndex = 3;
            this.buttonSlewOut.Text = "Slew Out";
            this.buttonSlewOut.UseVisualStyleBackColor = true;
            this.buttonSlewOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSlewOut_MouseDown);
            this.buttonSlewOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonSlewOut_MouseUp);
            // 
            // buttonSlewIn
            // 
            this.buttonSlewIn.Location = new System.Drawing.Point(144, 48);
            this.buttonSlewIn.Name = "buttonSlewIn";
            this.buttonSlewIn.Size = new System.Drawing.Size(75, 23);
            this.buttonSlewIn.TabIndex = 3;
            this.buttonSlewIn.Text = "Slew In";
            this.buttonSlewIn.UseVisualStyleBackColor = true;
            this.buttonSlewIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSlewIn_MouseDown);
            this.buttonSlewIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonSlewIn_MouseUp);
            // 
            // buttonManualReset
            // 
            this.buttonManualReset.Location = new System.Drawing.Point(9, 453);
            this.buttonManualReset.Name = "buttonManualReset";
            this.buttonManualReset.Size = new System.Drawing.Size(90, 23);
            this.buttonManualReset.TabIndex = 7;
            this.buttonManualReset.Text = "Manual Reset";
            this.buttonManualReset.UseVisualStyleBackColor = true;
            this.buttonManualReset.Click += new System.EventHandler(this.buttonManualReset_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentPosition});
            this.statusStrip.Location = new System.Drawing.Point(0, 483);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(245, 22);
            this.statusStrip.TabIndex = 8;
            // 
            // currentPosition
            // 
            this.currentPosition.Name = "currentPosition";
            this.currentPosition.Size = new System.Drawing.Size(0, 17);
            // 
            // groupboxIncremental
            // 
            this.groupboxIncremental.Controls.Add(this.buttonIMOut);
            this.groupboxIncremental.Controls.Add(this.buttonIMIn);
            this.groupboxIncremental.Controls.Add(this.updownIncrementalMove);
            this.groupboxIncremental.Controls.Add(this.buttonSlewOut);
            this.groupboxIncremental.Controls.Add(this.buttonSlewIn);
            this.groupboxIncremental.Location = new System.Drawing.Point(9, 95);
            this.groupboxIncremental.Name = "groupboxIncremental";
            this.groupboxIncremental.Size = new System.Drawing.Size(227, 108);
            this.groupboxIncremental.TabIndex = 9;
            this.groupboxIncremental.TabStop = false;
            this.groupboxIncremental.Text = "Incremental Movement";
            // 
            // buttonIMOut
            // 
            this.buttonIMOut.Location = new System.Drawing.Point(9, 77);
            this.buttonIMOut.Name = "buttonIMOut";
            this.buttonIMOut.Size = new System.Drawing.Size(74, 23);
            this.buttonIMOut.TabIndex = 5;
            this.buttonIMOut.Text = "Move Out";
            this.buttonIMOut.UseVisualStyleBackColor = true;
            this.buttonIMOut.Click += new System.EventHandler(this.buttonIMOut_Click);
            // 
            // buttonIMIn
            // 
            this.buttonIMIn.Location = new System.Drawing.Point(9, 48);
            this.buttonIMIn.Name = "buttonIMIn";
            this.buttonIMIn.Size = new System.Drawing.Size(74, 23);
            this.buttonIMIn.TabIndex = 5;
            this.buttonIMIn.Text = "Move In";
            this.buttonIMIn.UseVisualStyleBackColor = true;
            this.buttonIMIn.Click += new System.EventHandler(this.buttonIMIn_Click);
            // 
            // updownIncrementalMove
            // 
            this.updownIncrementalMove.Location = new System.Drawing.Point(9, 22);
            this.updownIncrementalMove.Name = "updownIncrementalMove";
            this.updownIncrementalMove.Size = new System.Drawing.Size(74, 20);
            this.updownIncrementalMove.TabIndex = 4;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // FocusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 505);
            this.Controls.Add(this.groupboxBacklashCompensation);
            this.Controls.Add(this.groupboxIncremental);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonManualReset);
            this.Controls.Add(this.groupboxAbsoluteMovement);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupboxOptions);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FocusControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Focuser Toolbox";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FocusControl_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FocusControl_FormClosing);
            this.Resize += new System.EventHandler(this.FocusControl_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupboxBacklashCompensation.ResumeLayout(false);
            this.groupboxBacklashCompensation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownBCSteps)).EndInit();
            this.groupboxOptions.ResumeLayout(false);
            this.groupboxOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupboxAbsoluteMovement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updownAbsolutePosition)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupboxIncremental.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updownIncrementalMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void FocusControl_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion

        private ASCOM.Arduino.Focuser Focuser;
        private Config Config;
        private System.Windows.Forms.ComboBox comboSelectPreset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonLoadPreset;
        private System.Windows.Forms.Button buttonSavePreset;
        private System.Windows.Forms.GroupBox groupboxOptions;
        private System.Windows.Forms.Button buttonSetPosition;
        private System.Windows.Forms.TextBox textboxCustomPosition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkboxReverse;
        private System.Windows.Forms.GroupBox groupboxAbsoluteMovement;
        private System.Windows.Forms.Button buttonHalt;
        private System.Windows.Forms.Button buttonMoveTo;
        private System.Windows.Forms.Button buttonSlewOut;
        private System.Windows.Forms.Button buttonSlewIn;
        private System.Windows.Forms.NumericUpDown updownAbsolutePosition;
        private System.Windows.Forms.Button buttonManualReset;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox groupboxIncremental;
        private System.Windows.Forms.Button buttonPark;
        private System.Windows.Forms.GroupBox groupboxBacklashCompensation;
        private System.Windows.Forms.CheckBox checkboxBC;
        private System.Windows.Forms.NumericUpDown updownBCSteps;
        private System.Windows.Forms.Label labelBCSteps;
        private System.Windows.Forms.CheckBox checkboxBCDirection;
        private System.Windows.Forms.NumericUpDown updownIncrementalMove;
        private System.Windows.Forms.Button buttonIMIn;
        private System.Windows.Forms.Button buttonIMOut;
        private System.Windows.Forms.Button buttonDeletePreset;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripStatusLabel currentPosition;
    }
}