using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Arduino_visualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] port_list = SerialPort.GetPortNames();
            for(int i = 0; i < port_list.Length; i++)
            {
                listBox1.Items.Add(port_list[i]);
            }
            label3.Text = "";
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            string chart_area1 = "Area1";
            chart1.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea(chart_area1));
            string legend1 = "Graph";
            chart1.Series.Add(legend1);
            chart1.Series[legend1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            double[] y_values = new double[5] { 1.0, 1.2, 2.2, 3.2, 1.5 };
            for(int i = 0; i < y_values.Length; i++)
            {
                chart1.Series[legend1].Points.AddY(y_values[i]);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listBox1.SelectedValue.ToString();
            if (listBox1.SelectedItem == null) label2.Text = "COMポートを選んでください。";
            else
            {
                string selected_port = listBox1.SelectedItem.ToString();
                serialPort1.PortName = selected_port;
                serialPort1.Open();
                label2.Text = selected_port + "に接続しています";
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string str = serialPort1.ReadLine();
            label3.Text = str;
        }
    }
}
