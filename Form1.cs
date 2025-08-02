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
            radio.StateChanged += Radio_StateChanged;
            radio.VswrChanged += Radio_VswrChanged;

            peakTimer = new();
            peakTimer.Tick += PeakTimer_Tick;
            peakTimer.Interval = 1000;
            peakTimer.Start();
            PeakTimer_Tick(null, EventArgs.Empty);
        }

        private void Radio_VswrChanged(object? sender, VswrEventArgs e)
        {
            Invoke(() =>
            {
                swrBar.Value = (int)(Math.Min(e.Vswr, 10) * 100.0);
                swrValueLabel.Text = e.Vswr.ToString("0.00") + " : 1";
            });
        }

        bool receivingNoise = true;
        bool receivingSignal = false;

        private void Radio_StateChanged(object? sender, StateChangedEventArgs e)
        {
            receivingNoise = e.To == RadioState.ReceivingNoise;
            receivingSignal = e.To == RadioState.ReceivingSignal;

            Invoke(() =>
            {
                if (e.To == RadioState.ReceivingNoise)
                {
                    stateBox.BackColor = Color.Gray;
                    swrBar.Value = 1;
                }
                else if (e.To == RadioState.ReceivingSignal)
                {
                    stateBox.BackColor = Color.Green;
                    swrBar.Value = 1;
                }
                else if (e.To == RadioState.Transmitting)
                {
                    stateBox.BackColor = Color.Red;
                }
                else
                {
                    stateBox.BackColor = Color.Blue;
                }
            });
        }

        private double peakRssi = -130;

        private void PeakTimer_Tick(object? sender, EventArgs e)
        {
            var value = peakRssi;
            Invoke(() =>
            {
                peakRssiValue.Text = value.ToString() + " dBm";
                logPane.Text += count + Environment.NewLine;
                count = 0;
            });

            peakRssi = double.MinValue;
        }

        int count;
        List<double> noiseRssis = new();
        double floor;

        const int noiseFloorAveragingSamples = 1000;

        private void Radio_RawRssiUpdated(object? sender, RssiEventArgs e)
        {
            if (receivingNoise)
            {
                noiseRssis.Add(e.Rssi);
                if (noiseRssis.Count > noiseFloorAveragingSamples)
                {
                    noiseRssis.RemoveAt(0);
                }
                floor = noiseRssis.Average();
            }

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
                    rssiValueLabel.Text = e.Rssi.ToString() + " dBm";
                    rssiBar.Value = (int)e.Rssi + 140;
                    floorLabel.Text = floor.ToString("0.0") + " dBm";

                    if (receivingSignal)
                    {
                        snrLabel.Text = (e.Rssi - floor).ToString("0.0") + " dB";
                    }
                    else
                    {
                        snrLabel.Text = "";
                    }
                });
            }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }
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
