using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int algorithmCount = 0;
        private int algorithmNumber;
        private string motorStatus = "";
        private string waterLevel = "";
        private string previousMotorStatus = "";
        private string previousWaterLevel = "";

        private Panel[] panel_1;
        private Panel[] panel_2;

        private System.Windows.Forms.Timer postTimer;

        public Form1()
        {
            InitializeComponent();
        }


        private void comboBox1_Click(object sender, EventArgs e)
        {
            int num;
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
            comboBox1.Items.AddRange(ports);
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
                try
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                    buttonOpenPort.Text = "Close";
                    comboBox1.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Port " + comboBox1.Text + " is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
            {
                serialPort1.Close();
                buttonOpenPort.Text = "Open";
                comboBox1.Enabled = true;
            }
        }

        private void startTimer()
        {
            timer1.Start();
        }

        private int currentPanelIndex = 0;

        private async Task SendDataToServerAsync(string waterLevel, string motorStatus)
        {
            var data = new
            {
                WaterLevel = waterLevel,
                MotorStatus = motorStatus
            };

            var httpClient = new HttpClient();
            var url = "http://localhost:3000/data"; 

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode(); 
            }
            catch (Exception ex)
            {
            }
        }


        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte commandFromArduino = (byte)serialPort1.ReadByte();
            this.Invoke(new MethodInvoker(delegate
            {
                if (commandFromArduino == 0xB1)
                {
                    UpdateMotorStatus("OFF");
                    startTimer();
                }
                else if (commandFromArduino == 0xA1)
                {
                    UpdateMotorStatus("ON");
                    startTimer();
                } else {
                    // Обробка рядка, що містить значення Level
                    int receivedInt = commandFromArduino;
                    UpdateWaterLevel(receivedInt.ToString());
                    startTimer();
                }

                // Перевіряємо, чи відбулися зміни в даних
                if (motorStatus != previousMotorStatus || waterLevel != previousWaterLevel)
                {
                    SendDataToServerAsync(waterLevel, motorStatus);
                    previousMotorStatus = motorStatus;
                    previousWaterLevel = waterLevel;
                }
            }));
        }

        private void UpdateMotorStatus(string status)
        {
            if (this.textBoxMotorStatus.InvokeRequired)
            {
                this.textBoxMotorStatus.Invoke(new Action<string>(UpdateMotorStatus), status);
            }
            else
            {
                this.textBoxMotorStatus.Text = status;
                motorStatus = status;
            }
        }

        private void UpdateWaterLevel(string level)
        {
            if (this.textBoxWaterLevel.InvokeRequired)
            {
                this.textBoxWaterLevel.Invoke(new Action<string>(UpdateWaterLevel), level);
            }
            else
            {
                this.textBoxWaterLevel.Text = level + "%";
                waterLevel = level;
            }
        }

        private void buttonSetLevels_Click(object sender, EventArgs e)
        {
            int motorOnLevel;
            int motorOffLevel;

            if (int.TryParse(textBoxMotorOnLevel.Text, out motorOnLevel) && int.TryParse(textBoxMotorOffLevel.Text, out motorOffLevel))
            {
                serialPort1.Write(motorOnLevel.ToString() + "O");
                serialPort1.Write(motorOffLevel.ToString() + "F");
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for the levels.");
            }
        }

    }
}
