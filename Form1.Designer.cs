namespace TaitMaster
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            serialPortList = new ComboBox();
            label1 = new Label();
            connectButton = new Button();
            label2 = new Label();
            serialPortSpeedBox = new TextBox();
            logPane = new TextBox();
            rssiBar = new ProgressBar();
            label3 = new Label();
            label4 = new Label();
            rssiValueLabel = new Label();
            peakRssiValue = new Label();
            label5 = new Label();
            label7 = new Label();
            floorLabel = new Label();
            label6 = new Label();
            snrLabel = new Label();
            stateBox = new TextBox();
            SuspendLayout();
            // 
            // serialPortList
            // 
            serialPortList.DropDownStyle = ComboBoxStyle.DropDownList;
            serialPortList.FormattingEnabled = true;
            serialPortList.Location = new Point(78, 12);
            serialPortList.Name = "serialPortList";
            serialPortList.Size = new Size(95, 23);
            serialPortList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Serial port";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(289, 11);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 2;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 15);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Speed";
            // 
            // serialPortSpeedBox
            // 
            serialPortSpeedBox.Location = new Point(224, 12);
            serialPortSpeedBox.Name = "serialPortSpeedBox";
            serialPortSpeedBox.Size = new Size(59, 23);
            serialPortSpeedBox.TabIndex = 4;
            serialPortSpeedBox.Text = "28800";
            // 
            // logPane
            // 
            logPane.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logPane.BackColor = Color.White;
            logPane.Location = new Point(12, 116);
            logPane.Multiline = true;
            logPane.Name = "logPane";
            logPane.ReadOnly = true;
            logPane.Size = new Size(776, 117);
            logPane.TabIndex = 5;
            // 
            // rssiBar
            // 
            rssiBar.Location = new Point(47, 53);
            rssiBar.Maximum = 140;
            rssiBar.Name = "rssiBar";
            rssiBar.Size = new Size(148, 23);
            rssiBar.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 57);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 7;
            label3.Text = "RSSI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(247, 57);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 8;
            label4.Text = "dBm";
            // 
            // rssiValueLabel
            // 
            rssiValueLabel.AutoSize = true;
            rssiValueLabel.Location = new Point(203, 57);
            rssiValueLabel.Name = "rssiValueLabel";
            rssiValueLabel.Size = new Size(32, 15);
            rssiValueLabel.TabIndex = 9;
            rssiValueLabel.Text = "dBm";
            // 
            // peakRssiValue
            // 
            peakRssiValue.AutoSize = true;
            peakRssiValue.Location = new Point(332, 57);
            peakRssiValue.Name = "peakRssiValue";
            peakRssiValue.Size = new Size(32, 15);
            peakRssiValue.TabIndex = 11;
            peakRssiValue.Text = "dBm";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(294, 57);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 12;
            label5.Text = "peak:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(420, 57);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 14;
            label7.Text = "floor:";
            // 
            // floorLabel
            // 
            floorLabel.AutoSize = true;
            floorLabel.Location = new Point(458, 57);
            floorLabel.Name = "floorLabel";
            floorLabel.Size = new Size(32, 15);
            floorLabel.TabIndex = 13;
            floorLabel.Text = "dBm";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(543, 57);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 16;
            label6.Text = "SNR:";
            // 
            // snrLabel
            // 
            snrLabel.AutoSize = true;
            snrLabel.Location = new Point(581, 57);
            snrLabel.Name = "snrLabel";
            snrLabel.Size = new Size(32, 15);
            snrLabel.TabIndex = 15;
            snrLabel.Text = "dBm";
            // 
            // stateBox
            // 
            stateBox.Location = new Point(426, 12);
            stateBox.Name = "stateBox";
            stateBox.ReadOnly = true;
            stateBox.Size = new Size(29, 23);
            stateBox.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 245);
            Controls.Add(stateBox);
            Controls.Add(label6);
            Controls.Add(snrLabel);
            Controls.Add(label7);
            Controls.Add(floorLabel);
            Controls.Add(label5);
            Controls.Add(peakRssiValue);
            Controls.Add(rssiValueLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(rssiBar);
            Controls.Add(logPane);
            Controls.Add(serialPortSpeedBox);
            Controls.Add(label2);
            Controls.Add(connectButton);
            Controls.Add(label1);
            Controls.Add(serialPortList);
            Name = "Form1";
            Text = "TaitMaster";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox serialPortList;
        private Label label1;
        private Button connectButton;
        private Label label2;
        private TextBox serialPortSpeedBox;
        private TextBox logPane;
        private ProgressBar rssiBar;
        private Label label3;
        private Label label4;
        private Label rssiValueLabel;
        private Label peakRssiValue;
        private Label label5;
        private Label label7;
        private Label floorLabel;
        private Label label6;
        private Label snrLabel;
        private TextBox stateBox;
    }
}
