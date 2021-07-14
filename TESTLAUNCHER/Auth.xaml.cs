using AutoUpdaterDotNET;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Input;

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
            String loginUser = loginBox.Text;
            String passUser = passwordBox.Password;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @_login AND `pass`= @_pass", db.getConnection());

            command.Parameters.Add("@_login", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@_pass", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            /*if (inCheck.Checked == true)
            {
                Properties.Settings.Default.username = loginUser;
                Properties.Settings.Default.password = passUser;
            }*/
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Auth Complete");
            }
            else
            {
                MessageBox.Show("Failure");
            }
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

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
