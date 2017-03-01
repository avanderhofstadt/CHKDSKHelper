using System;
using System.IO;
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
using System.Diagnostics;

namespace CHKDSKHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        string argument = "";
        string argument1 = "";
        string argument2 = "";
        string drive;
        string drivec;

        public MainWindow()
        {
            InitializeComponent();
            GetDrive();
        }


        public void GetDrive() {
            foreach (var Drives in Environment.GetLogicalDrives())
            {
                DriveInfo DriveInf = new DriveInfo(Drives);
                if (DriveInf.IsReady == true)
                {
                    comboBoxDrives.Items.Add(DriveInf.Name);
                }
            }
        }



private void button_Click(object sender, RoutedEventArgs e)
        {
            
            if (comboBoxDrives.SelectedItem == null)
            {
                MessageBox.Show("Please select an hard drive");
            }
            else
            {
                drive = comboBoxDrives.SelectedItem.ToString();
                drivec = drive.Remove(drive.Length - 1);


                string strCmdText = drivec + argument + argument1 + argument2;
                var process = Process.Start("chkdsk.exe", strCmdText);
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Checkdisk failed or canceled");
                }
            }
        }

        
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            argument = " /f";
            
        }
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            argument1 = " /r";
        }
        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            argument2 = " /v";
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            argument = "";
        }
        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            argument1 = "";
        }
        private void checkBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            argument2 = "";
        }
    }
}
