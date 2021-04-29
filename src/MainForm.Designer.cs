namespace Simple_Hyperterminal
{
    partial class MainForm
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
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocalIP = new System.Windows.Forms.ComboBox();
            this.chkConnect = new System.Windows.Forms.CheckBox();
            this.autoFill = new System.Windows.Forms.Button();
            this.genLog = new System.Windows.Forms.Button();
            this.getProcSet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.Location = new System.Drawing.Point(832, 29);
            this.txtRemoteIP.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.ReadOnly = true;
            this.txtRemoteIP.Size = new System.Drawing.Size(321, 38);
            this.txtRemoteIP.TabIndex = 2;
            this.txtRemoteIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local IP:";
            // 
            // cmbLocalIP
            // 
            this.cmbLocalIP.Enabled = false;
            this.cmbLocalIP.FormattingEnabled = true;
            this.cmbLocalIP.Location = new System.Drawing.Point(203, 29);
            this.cmbLocalIP.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbLocalIP.Name = "cmbLocalIP";
            this.cmbLocalIP.Size = new System.Drawing.Size(321, 39);
            this.cmbLocalIP.TabIndex = 0;
            // 
            // chkConnect
            // 
            this.chkConnect.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkConnect.Location = new System.Drawing.Point(32, 155);
            this.chkConnect.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkConnect.Name = "chkConnect";
            this.chkConnect.Size = new System.Drawing.Size(500, 57);
            this.chkConnect.TabIndex = 4;
            this.chkConnect.Text = "Connect";
            this.chkConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkConnect.UseVisualStyleBackColor = true;
            this.chkConnect.CheckedChanged += new System.EventHandler(this.chkConnect_CheckedChanged);
            // 
            // autoFill
            // 
            this.autoFill.Location = new System.Drawing.Point(600, 155);
            this.autoFill.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.autoFill.Name = "autoFill";
            this.autoFill.Size = new System.Drawing.Size(150, 57);
            this.autoFill.TabIndex = 4;
            this.autoFill.Text = "Auto Fill";
            this.autoFill.UseVisualStyleBackColor = true;
            this.autoFill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.autoFill_MouseClick);
            // 
            // genLog
            // 
            this.genLog.Location = new System.Drawing.Point(800, 155);
            this.genLog.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.genLog.Name = "logs";
            this.genLog.Size = new System.Drawing.Size(150, 57);
            this.genLog.TabIndex = 4;
            this.genLog.Text = "Logs";
            this.genLog.UseVisualStyleBackColor = true;
            this.genLog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.genLog_MouseClick);
            // 
            // getProcSet
            // 
            this.getProcSet.Location = new System.Drawing.Point(1000, 155);
            this.getProcSet.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.getProcSet.Name = "prcset";
            this.getProcSet.Size = new System.Drawing.Size(150, 57);
            this.getProcSet.TabIndex = 4;
            this.getProcSet.Text = "Proc set";
            this.getProcSet.UseVisualStyleBackColor = true;
            this.getProcSet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getProcSet_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(632, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Remote IP:";
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(832, 93);
            this.txtRemotePort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.ReadOnly = true;
            this.txtRemotePort.Size = new System.Drawing.Size(321, 38);
            this.txtRemotePort.TabIndex = 3;
            this.txtRemotePort.Text = "23";
            this.txtRemotePort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Remote Port:";
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(32, 227);//32
            this.txtData.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtData.Multiline = false;
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(1121, 50);//1121
            this.txtData.TabIndex = 5;
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // txtData2
            // 
            this.txtData2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData2.Location = new System.Drawing.Point(32, 277);
            this.txtData2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtData2.Multiline = true;
            this.txtData2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData2.WordWrap = false;
            this.txtData2.Name = "txtData2";
            this.txtData2.ReadOnly = true;
            this.txtData2.Size = new System.Drawing.Size(1121, 450);
            this.txtData2.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(32, 750);
            this.btnClear.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(1120, 55);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(203, 93);
            this.txtLocalPort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.ReadOnly = true;
            this.txtLocalPort.Size = new System.Drawing.Size(327, 38);
            this.txtLocalPort.TabIndex = 1;
            this.txtLocalPort.Text = "23";
            this.txtLocalPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Local Port:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 1183);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtData2);
            this.Controls.Add(this.chkConnect);
            this.Controls.Add(this.autoFill);
            this.Controls.Add(this.genLog);
            this.Controls.Add(this.getProcSet);
            this.Controls.Add(this.cmbLocalIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtRemotePort);
            this.Controls.Add(this.txtRemoteIP);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(1183, 1028);
            this.Name = "MainForm";
            this.Text = "Camera Log Sniffer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocalIP;
        private System.Windows.Forms.CheckBox chkConnect;
        private System.Windows.Forms.Button autoFill;
        private System.Windows.Forms.Button genLog;
        private System.Windows.Forms.Button getProcSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.Label label4;
    }
}

