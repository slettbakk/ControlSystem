using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NationalInstruments;
using NationalInstruments.DAQmx;

using Opc.UaFx.Client;

namespace ControlSystem
{
    public partial class Form1 : Form
    {
        double x = 25;              //initial Process valu
        double u = 0;               //initial control value
        double r = 30;              //Initial setpoint
        double Ts = 0.1;            //timestep
        double Kp = 0.6, Ti = 8;    //Initial PI settings

        //intitialize digital twin:
        double x_twin = 25;
        double u_twin = 0;

        bool PISat = true;          //Enable saturation on PI controller
        double z = 0;               //Initial integral term of PID Controller
        double MaxLim = 5;          //PI controller upper limit
        double MinLim = 0;          //PI controller lower limit
        Filter LPFilter = new Filter(); //include filter from filter class

        //Initialize model:
        double TimeConstant = 22;
        double TimeDelay = 2;
        double Tenv = 24;
        double K = 5;
        //double K = 5.5;

        int N = 18;
        double[] controlArray = new double[18];
        int index = 0;

        int PlotSamples = 150;

        public Form1()
        {
            InitializeComponent();
            Initialize_Plots();         

            //Initialize timers:
            timer1.Interval = Convert.ToInt32(Ts * 1000);   //Simulation time interval
            timer2.Interval = 500;                          //Plotting and OPC client interval

            //Set LP filter settings:
            LPFilter.Ts = 0.1;
            LPFilter.Tf = 0.5;
        }
        //Timer #1 for control system:
        public void timer1_Tick(object sender, EventArgs e)
        {
            u = PIController(x);   //Run PI controller

            if (index == 0)         //RUN simulation model case
            {
                PISat = true;
                x = AirHeaterModel(x, u, N);
            }
            else if (index == 1)    //RUN real temperature case
            {
                PISat = true;
                x = DAQControl(u);
                x = LPFilter.LowPassFilter(x);
            }
            else if (index == 2)    //RUN real process with digital twin
            {
                u_twin = u;
                PISat = true;
                x = DAQControl(u);
                x = LPFilter.LowPassFilter(x);
                x_twin = AirHeaterModel(x_twin, u_twin, N);
                
                //u_twin = PIController(x_twin);


                //x_twin = LPFilter2.LowPassFilter(x_twin);
            }
        }

        //Timer #2 for plotting and OPC:
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Chart 1:
            txtProcessValue.Text = x.ToString("0.##");
            txtControlValue.Text = u.ToString("0.##");
            chartMeasurementData.Series["ProcessValue"].Points.AddY(x);
            chartMeasurementData.Series["Setpoint"].Points.AddY(r);
            //chartMeasurementData.Series["ProcessValue Twin"].Points.AddY(x_twin);

            //Chart 2:
            chartMeasurementData2.Series["ControlValue"].Points.AddY(u);
            //chartMeasurementData2.Series["ControlValue Twin"].Points.AddY(u_twin);

            //Dynamic plot:
            if (chartMeasurementData.Series["ProcessValue"].Points.Count > PlotSamples)
            {
                chartMeasurementData.Series["ProcessValue"].Points.RemoveAt(0);
                chartMeasurementData.Series["Setpoint"].Points.RemoveAt(0);
                chartMeasurementData2.Series["ControlValue"].Points.RemoveAt(0);
                //chartMeasurementData.Series["ProcessValue Twin"].Points.RemoveAt(0);

            }
            chartMeasurementData.ResetAutoValues();

            string opcUrl = "opc.tcp://desktop-970g76v:62640/IntegrationObjects/ServerSimulator";
            OPCWrite(opcUrl, "ns=2;s=Tag7", Math.Round(u,2));
            OPCWrite(opcUrl, "ns=2;s=Tag8", Math.Round(x,2));
        }
        //Initialize plot function:
        private void Initialize_Plots()
        {
            //Initialize textboxes
            txtSetpoint.Text = r.ToString();
            txtKp.Text = Kp.ToString();
            txtTi.Text = Ti.ToString();

            //Initialize chart
            chartMeasurementData.Series.Clear();
            chartMeasurementData2.Series.Clear();

            chartMeasurementData.Series.Add("ProcessValue");
            chartMeasurementData.Series["ProcessValue"].ChartType = SeriesChartType.Line;
            chartMeasurementData.Series["ProcessValue"].BorderWidth = 3;

            chartMeasurementData.Series.Add("Setpoint");
            chartMeasurementData.Series["Setpoint"].ChartType = SeriesChartType.Line;
            chartMeasurementData.Series["Setpoint"].BorderWidth = 3;

            chartMeasurementData.Series.Add("ProcessValue Twin");
            chartMeasurementData.Series["ProcessValue Twin"].ChartType = SeriesChartType.Line;
            chartMeasurementData.Series["ProcessValue Twin"].BorderWidth = 3;
            chartMeasurementData.Series["ProcessValue Twin"].BorderDashStyle = ChartDashStyle.Dot;

            chartMeasurementData2.Series.Add("ControlValue");
            chartMeasurementData2.Series["ControlValue"].ChartType = SeriesChartType.Line;
            chartMeasurementData2.Series["ControlValue"].BorderWidth = 3;

            chartMeasurementData2.Series.Add("ControlValue Twin");
            chartMeasurementData2.Series["ControlValue Twin"].ChartType = SeriesChartType.Line;
            chartMeasurementData2.Series["ControlValue Twin"].BorderWidth = 3;
            chartMeasurementData2.Series["ControlValue Twin"].BorderDashStyle = ChartDashStyle.Dot;

            ChartArea area1 = chartMeasurementData.ChartAreas[0];
            area1.AxisY.Minimum = 20;
            area1.AxisY.Maximum = 50;
            area1.AxisX.Title = "Time [s]";
            area1.AxisY.Title = "Temperature [C]";

            ChartArea area2 = chartMeasurementData2.ChartAreas[0];
            area2.AxisY.Minimum = 0;
            area2.AxisY.Maximum = 6;
            area2.AxisX.Title = "Time [s]";
            area2.AxisY.Title = "Volt [V]";
        }

        //Start application
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        //Dynamic model of air heater:
        double AirHeaterModel(double xk, double u, int N)
        {
            //Creating control variable array to simulate transport delay.

            for (int i = 1; i < N; i++)
            {
                controlArray[i - 1] = controlArray[i];
            }
            controlArray[N - 1] = u;

            double Tdelta = (1 / TimeConstant) * (-xk + (K * controlArray[0] + Tenv));

            double xk1 = xk + Tdelta * Ts;

            return xk1;
        }

        //Discrete PI controller:
        double PIController(double y)
        {   //input variable is process value. Takes setpoint from global variable.
            double e = r - y;
            u = Kp * e + (Kp / Ti) * z;
            z = z + Ts * e;
            if (PISat)
            {
                if (u > MaxLim) u = MaxLim;
                else if (u < MinLim) u = MinLim;

                //if (z > MaxLim * 15) z = MaxLim * 15;
                //else if (z < MinLim*15) z = MinLim * 15;
            }
            return u;
        }

        //DAQ Control for real control process:
        double DAQControl(double u)
        {
            //-------------------------Init and write analog output---------------------

            Task analogOutTask = new Task();

            AOChannel myAOChannel;

            myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(
                "dev1/ao0",
                "myAOChannel",
                0,
                5,
                AOVoltageUnits.Volts
                );

            AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(analogOutTask.Stream);

            double analogDataOut;

            analogDataOut = u;
            //analogDataOut = Convert.ToDouble(txtAnalogOut.Text);
            if (analogDataOut > 5) analogDataOut = 5;
            else if (analogDataOut < 0) analogDataOut = 0;
            writer.WriteSingleSample(true, analogDataOut);

            //------------------------Init and read analog input------------------------
            Task analogInTask = new Task();

            AIChannel myAIChannel;

            myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(
                "dev1/ai0",
                "myAIChannel",
                AITerminalConfiguration.Rse,
                0,
                5,
                AIVoltageUnits.Volts
                );

            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);

            double analogDataIn = reader.ReadSingleSample();
            analogDataIn = VoltToTemp(analogDataIn);
            return analogDataIn;
        }

        //Scaler from 1...5V to Temperature:
        double VoltToTemp(double Volt)
        {
            return -12.5 + 12.5 * Volt;
        }

        //Writing ControlObject data to OPC:
        private void OPCWrite(string opcUrl, string tagName, double value)
        {
            var client = new OpcClient(opcUrl);
            client.Connect();
            client.WriteNode(tagName, value);
            client.Disconnect();
        }

        //Text control so setpoint and PI settings is only updated when changed:
        private void txtSetpoint_TextChanged(object sender, EventArgs e)
        {
            r = Convert.ToDouble(txtSetpoint.Text);
        }

        private void txtKp_TextChanged(object sender, EventArgs e)
        {
            Kp = Convert.ToDouble(txtKp.Text);
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = cmbMode.SelectedIndex;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }


        private void txtTi_TextChanged(object sender, EventArgs e)
        {
            Ti = Convert.ToDouble(txtTi.Text);
        }


    }
}
