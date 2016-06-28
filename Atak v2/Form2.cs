using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Atak_v2
{
    public partial class Form2 : Form
    {
        string ProgramAdi = "Atak V2";
        public Form2()
        {
            InitializeComponent();
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if (key.GetValue(ProgramAdi).ToString() == "\"" + Application.ExecutablePath + "\"")
                {
                    AcilistaCalistir.Checked = true;
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Settings1.Default.Y1 = textBox1.Text;
            Settings1.Default.Y2 = textBox2.Text;
            Settings1.Default.Save();
            MessageBox.Show("Değişti");
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (AcilistaCalistir.Checked)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(ProgramAdi, "\"" + Application.ExecutablePath + "\"");
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue(ProgramAdi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
    }
}
