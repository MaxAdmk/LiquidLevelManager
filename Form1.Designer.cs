namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.panelM = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waterLevelLabel = new System.Windows.Forms.Label();
            this.motorStatusLabel = new System.Windows.Forms.Label();
            this.setMotorOnLabel = new System.Windows.Forms.Label();
            this.setMotorOffLabel = new System.Windows.Forms.Label();
            this.textBoxMotorStatus = new System.Windows.Forms.TextBox();
            this.textBoxWaterLevel = new System.Windows.Forms.TextBox();
            this.textBoxMotorOnLevel = new System.Windows.Forms.TextBox();
            this.textBoxMotorOffLevel = new System.Windows.Forms.TextBox();
            this.buttonSetLevels = new System.Windows.Forms.Button();
            this.panelM.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelM
            // 
            this.panelM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelM.Controls.Add(this.label1);
            this.panelM.Controls.Add(this.comboBox1);
            this.panelM.Controls.Add(this.buttonOpenPort);
            this.panelM.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelM.Location = new System.Drawing.Point(0, 0);
            this.panelM.Name = "panelM";
            this.panelM.Size = new System.Drawing.Size(367, 39);
            this.panelM.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "COM порт";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.Location = new System.Drawing.Point(104, 6);
            this.comboBox1.MaxDropDownItems = 10;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 26);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenPort.Location = new System.Drawing.Point(198, 7);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(88, 25);
            this.buttonOpenPort.TabIndex = 5;
            this.buttonOpenPort.Tag = "1";
            this.buttonOpenPort.Text = "Відкрити";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // waterLevelLabel
            // 
            this.waterLevelLabel.AutoSize = true;
            this.waterLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waterLevelLabel.Location = new System.Drawing.Point(17, 79);
            this.waterLevelLabel.Name = "waterLevelLabel";
            this.waterLevelLabel.Size = new System.Drawing.Size(90, 18);
            this.waterLevelLabel.TabIndex = 34;
            this.waterLevelLabel.Text = "Water Level:";
            // 
            // motorStatusLabel
            // 
            this.motorStatusLabel.AutoSize = true;
            this.motorStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.motorStatusLabel.Location = new System.Drawing.Point(195, 79);
            this.motorStatusLabel.Name = "motorStatusLabel";
            this.motorStatusLabel.Size = new System.Drawing.Size(96, 18);
            this.motorStatusLabel.TabIndex = 35;
            this.motorStatusLabel.Text = "Motor status:";
            // 
            // setMotorOnLabel
            // 
            this.setMotorOnLabel.AutoSize = true;
            this.setMotorOnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setMotorOnLabel.Location = new System.Drawing.Point(12, 183);
            this.setMotorOnLabel.Name = "setMotorOnLabel";
            this.setMotorOnLabel.Size = new System.Drawing.Size(120, 18);
            this.setMotorOnLabel.TabIndex = 35;
            this.setMotorOnLabel.Text = "Set Motor On Lvl";
            // 
            // setMotorOffLabel
            // 
            this.setMotorOffLabel.AutoSize = true;
            this.setMotorOffLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setMotorOffLabel.Location = new System.Drawing.Point(135, 183);
            this.setMotorOffLabel.Name = "setMotorOffLabel";
            this.setMotorOffLabel.Size = new System.Drawing.Size(120, 18);
            this.setMotorOffLabel.TabIndex = 35;
            this.setMotorOffLabel.Text = "Set Motor Off Lvl";
            // 
            // textBoxMotorStatus
            // 
            this.textBoxMotorStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMotorStatus.Location = new System.Drawing.Point(291, 75);
            this.textBoxMotorStatus.Name = "textBoxMotorStatus";
            this.textBoxMotorStatus.ReadOnly = true;
            this.textBoxMotorStatus.Size = new System.Drawing.Size(43, 24);
            this.textBoxMotorStatus.TabIndex = 36;
            // 
            // textBoxWaterLevel
            // 
            this.textBoxWaterLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWaterLevel.Location = new System.Drawing.Point(113, 75);
            this.textBoxWaterLevel.Name = "textBoxWaterLevel";
            this.textBoxWaterLevel.ReadOnly = true;
            this.textBoxWaterLevel.Size = new System.Drawing.Size(46, 24);
            this.textBoxWaterLevel.TabIndex = 37;
            // 
            // textBoxMotorOnLevel
            // 
            this.textBoxMotorOnLevel.Location = new System.Drawing.Point(20, 204);
            this.textBoxMotorOnLevel.Name = "textBoxMotorOnLevel";
            this.textBoxMotorOnLevel.Size = new System.Drawing.Size(100, 20);
            this.textBoxMotorOnLevel.TabIndex = 0;
            // 
            // textBoxMotorOffLevel
            // 
            this.textBoxMotorOffLevel.Location = new System.Drawing.Point(138, 204);
            this.textBoxMotorOffLevel.Name = "textBoxMotorOffLevel";
            this.textBoxMotorOffLevel.Size = new System.Drawing.Size(100, 20);
            this.textBoxMotorOffLevel.TabIndex = 1;
            // 
            // buttonSetLevels
            // 
            this.buttonSetLevels.Location = new System.Drawing.Point(268, 204);
            this.buttonSetLevels.Name = "buttonSetLevels";
            this.buttonSetLevels.Size = new System.Drawing.Size(75, 23);
            this.buttonSetLevels.TabIndex = 2;
            this.buttonSetLevels.Text = "Set Levels";
            this.buttonSetLevels.Click += new System.EventHandler(this.buttonSetLevels_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 282);
            this.Controls.Add(this.setMotorOnLabel);
            this.Controls.Add(this.setMotorOffLabel);
            this.Controls.Add(this.textBoxMotorOnLevel);
            this.Controls.Add(this.textBoxMotorOffLevel);
            this.Controls.Add(this.buttonSetLevels);
            this.Controls.Add(this.motorStatusLabel);
            this.Controls.Add(this.textBoxMotorStatus);
            this.Controls.Add(this.textBoxWaterLevel);
            this.Controls.Add(this.waterLevelLabel);
            this.Controls.Add(this.panelM);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelM.ResumeLayout(false);
            this.panelM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label waterLevelLabel;
        private System.Windows.Forms.Label motorStatusLabel;
        private System.Windows.Forms.Label setMotorOnLabel;
        private System.Windows.Forms.Label setMotorOffLabel;
        private System.Windows.Forms.TextBox textBoxWaterLevel;
        private System.Windows.Forms.TextBox textBoxMotorStatus;
        private System.Windows.Forms.TextBox textBoxMotorOnLevel;
        private System.Windows.Forms.TextBox textBoxMotorOffLevel;
        private System.Windows.Forms.Button buttonSetLevels;
    }
}

