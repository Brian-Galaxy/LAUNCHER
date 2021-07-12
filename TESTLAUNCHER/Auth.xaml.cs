using AutoUpdaterDotNET;
using System;
using System.Threading;
using System.Windows;

namespace TESTLAUNCHER
{
    public partial class Select : Window
    {

        private System.Media.SoundPlayer SoundPlayer;
        public Select()
        {
            InitializeComponent();
            AutoUpdater.Start("https://pastebin.com/raw/WRR00DxV");
            checkBox.IsEnabled = Properties.Settings.Default.remCheck;


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void image_Copy_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SoundPlayer = new System.Media.SoundPlayer();
            string back = Environment.CurrentDirectory + "\\Sounds\\back.wav";
            SoundPlayer.SoundLocation = back;
            SoundPlayer.Load();
            SoundPlayer.Play();
        }

        private void checkBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Properties.Settings.Default.remCheck = checkBox.IsChecked.Value;
            Properties.Settings.Default.Save();
        }
    }
}
