using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//ekle
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Atak_v2
{
    public partial class Form1 : Form
    {
        
        //tus engelle
        [StructLayout(LayoutKind.Sequential)]
        private struct KeyboardDLLStruct
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;
        //tus bitti
        
        public Form1()
        {
           // tus engelle
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
            //tus bitti
            InitializeComponent();
         }

        //tus engelle
        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KeyboardDLLStruct objKeyInfo = (KeyboardDLLStruct)Marshal.PtrToStructure(lp, typeof(KeyboardDLLStruct));

                if (objKeyInfo.key == Keys.Tab || objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.F4 || objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.Escape)
                {
                    return (IntPtr)1;
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer2.Enabled = true;
            timer2.Interval = 1000;
            label1.Text = Settings1.Default.Y1;
            label2.Text = Settings1.Default.Y2;
            label3.Text = Settings1.Default.Y3;
            label4.Text = Settings1.Default.Y4;
            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Icon = notifyIcon1.Icon;
            trayIcon.Text = "Atak V2";
            trayIcon.Visible = true;
            trayIcon.ContextMenu = contextMenu1;
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            Form2 f22 = new Form2();
            f22.Show();
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] surucu = Directory.GetLogicalDrives();

            for (int i = 0; i < surucu.Length; i++)
            {
                string yol = surucu[i].ToString();
                bool varmi;
                varmi = File.Exists(yol + "h.txt");
                if (varmi == true)
                {this.Hide();}
                else if (varmi == false)
                {;}}}

         private void timer2_Tick(object sender, EventArgs e)
             {
                string[] surucu = Directory.GetLogicalDrives();
                for (int i = 0; i < surucu.Length; i++)
                {
                    string yol = surucu[i].ToString();
                    bool varmi;
                    varmi = File.Exists(yol + "h.txt");
                    if (varmi == false)
                    {this.Show();}
                    else if (varmi == true)
                    { ; }}}}}