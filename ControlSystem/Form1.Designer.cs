namespace ControlSystem
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.txtProcessValue = new System.Windows.Forms.TextBox();
            this.txtSetpoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtControlValue = new System.Windows.Forms.TextBox();
            this.chartMeasurementData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKp = new System.Windows.Forms.TextBox();
            this.txtTi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.chartMeasurementData2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartMeasurementData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMeasurementData2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProcessValue
            // 
            this.txtProcessValue.Location = new System.Drawing.Point(441, 36);
            this.txtProcessValue.Name = "txtProcessValue";
            this.txtProcessValue.Size = new System.Drawing.Size(100, 20);
            this.txtProcessValue.TabIndex = 1;
            // 
            // txtSetpoint
            // 
            this.txtSetpoint.Location = new System.Drawing.Point(312, 36);
            this.txtSetpoint.Name = "txtSetpoint";
            this.txtSetpoint.Size = new System.Drawing.Size(100, 20);
            this.txtSetpoint.TabIndex = 2;
            this.txtSetpoint.TextChanged += new System.EventHandler(this.txtSetpoint_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Process Value [C]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Setpoint [C]";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Control Value U [V]";
            // 
            // txtControlValue
            // 
            this.txtControlValue.Location = new System.Drawing.Point(570, 36);
            this.txtControlValue.Name = "txtControlValue";
            this.txtControlValue.Size = new System.Drawing.Size(100, 20);
            this.txtControlValue.TabIndex = 6;
            // 
            // chartMeasurementData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMeasurementData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMeasurementData.Legends.Add(legend1);
            this.chartMeasurementData.Location = new System.Drawing.Point(12, 132);
            this.chartMeasurementData.Name = "chartMeasurementData";
            this.chartMeasurementData.Size = new System.Drawing.Size(1137, 288);
            this.chartMeasurementData.TabIndex = 8;
            this.chartMeasurementData.Text = "chart1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(731, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "PI Controller Settings:";
            // 
            // txtKp
            // 
            this.txtKp.Location = new System.Drawing.Point(731, 36);
            this.txtKp.Name = "txtKp";
            this.txtKp.Size = new System.Drawing.Size(110, 20);
            this.txtKp.TabIndex = 10;
            this.txtKp.TextChanged += new System.EventHandler(this.txtKp_TextChanged);
            // 
            // txtTi
            // 
            this.txtTi.Location = new System.Drawing.Point(731, 72);
            this.txtTi.Name = "txtTi";
            this.txtTi.Size = new System.Drawing.Size(110, 20);
            this.txtTi.TabIndex = 11;
            this.txtTi.TextChanged += new System.EventHandler(this.txtTi_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(705, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(697, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ti [s]:";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(32, 82);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Simulation Model",
            "Control Real Process",
            "Control Real Process with DigitalTwin"});
            this.cmbMode.Location = new System.Drawing.Point(32, 36);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(233, 21);
            this.cmbMode.TabIndex = 23;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Control Mode";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(131, 82);
            this.btnStop.Name = "btnStop";
            this.btnStop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 25;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chartMeasurementData2
            // 
            chartArea2.Name = "ChartArea1";
            this.chartMeasurementData2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMeasurementData2.Legends.Add(legend2);
            this.chartMeasurementData2.Location = new System.Drawing.Point(12, 432);
            this.chartMeasurementData2.Name = "chartMeasurementData2";
            this.chartMeasurementData2.Size = new System.Drawing.Size(1137, 288);
            this.chartMeasurementData2.TabIndex = 26;
            this.chartMeasurementData2.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1163, 755);
            this.Controls.Add(this.chartMeasurementData2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTi);
            this.Controls.Add(this.txtKp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chartMeasurementData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtControlValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSetpoint);
            this.Controls.Add(this.txtProcessValue);
            this.Name = "Form1";
            this.Text = "Control System";
            ((System.ComponentModel.ISupportInitialize)(this.chartMeasurementData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMeasurementData2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtProcessValue;
        private System.Windows.Forms.TextBox txtSetpoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtControlValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMeasurementData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKp;
        private System.Windows.Forms.TextBox txtTi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMeasurementData2;
    }
}

