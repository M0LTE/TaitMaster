using System.IO.Ports;
using tait_ccdi;

namespace TaitMaster
{
    public partial class Form1 : Form
    {
        private bool connected;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPortList.DataSource = SerialPort.GetPortNames().OrderBy(a => int.Parse(a.Replace("COM", ""))).ToArray();
            logger = new WinformsLogger(logPane);
            peakRssiValue.Text = rssiValueLabel.Text =  "";
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                SetConnectControlsToDisconnected();
                DisconnectRadio();
            }
            else
            {
                SetConnectControlsToConnected();
                StartTalkingToRadio();
            }
        }

        private void DisconnectRadio()
        {
            radio.Disconnect();
        }

        TaitRadio radio;

        WinformsLogger logger;
        System.Windows.Forms.Timer peakTimer;

        private void StartTalkingToRadio()
        {
            radio = TaitRadio.Create(serialPortList.SelectedItem.ToString(), int.Parse(serialPortSpeedBox.Text), logger);
            radio.RawRssiUpdated += Radio_RawRssiUpdated;

            peakTimer = new();
            peakTimer.Tick += PeakTimer_Tick;
            peakTimer.Interval = 1000;
            peakTimer.Start();
            PeakTimer_Tick(null, EventArgs.Empty);
        }

        private double peakRssi = double.MinValue;

        private void PeakTimer_Tick(object? sender, EventArgs e)
        {
            var value = peakRssi;
            Invoke(() =>
            {
                peakRssiValue.Text = value.ToString();
                logPane.Text += count + Environment.NewLine;
                count = 0;
            });

            peakRssi = double.MinValue;
        }

        int count;

        private void Radio_RawRssiUpdated(object? sender, RssiEventArgs e)
        {
            count++;
            if (e.Rssi > peakRssi)
            {
                peakRssi = e.Rssi;
            }

            if (Disposing) { return; }

            try
            {
                Invoke(() =>
                {

                    rssiValueLabel.Text = e.Rssi.ToString();
                    rssiBar.Value = (int)e.Rssi + 140;
                });
            }
            catch (ObjectDisposedException) { }
        }

        private void SetConnectControlsToConnected()
        {
            connectButton.Text = "Disconnect";
            serialPortList.Enabled = serialPortSpeedBox.Enabled = false;
            connected = true;
        }

        private void SetConnectControlsToDisconnected()
        {
            connectButton.Text = "Connect";
            serialPortList.Enabled = serialPortSpeedBox.Enabled = true;
            connected = false;
        }
    }
}
