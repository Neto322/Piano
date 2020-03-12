using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace PiaNO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WaveOut waveOut;
        private MixingSampleProvider mixer;
        public MainWindow()
        {
            InitializeComponent();

            waveOut = new WaveOut();

            mixer = new MixingSampleProvider( WaveFormat.CreateIeeeFloatWaveFormat(44100,1));

            mixer.ReadFully = true;

            waveOut.Init(mixer);

            waveOut.Play();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            var nota_do =
                new SignalGenerator(44100,1)
                {
                    Gain = 5,
                    Frequency = 261.6,
                    Type = SignalGeneratorType.Sin,

                }.Take(TimeSpan.FromMilliseconds(250));

            mixer.AddMixerInput(nota_do);
        }
    }
}
