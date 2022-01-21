using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace RegShell
{
    class ShellRegistry
    {
        public void ShellOverwrite()
        {
            Directory.CreateDirectory(@"C:\Temp");
           if(MessageBox.Show("Do you want to Overwrite WINLOGON Shell Registry?", "WinLogON Shell", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)== DialogResult.Yes)
            {
                try
                {
                    RegistryKey hkey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    RegistryKey hkey333 = hkey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                    hkey333.DeleteValue("Shell");
                    hkey333.SetValue("Shell", "cmd.exe", RegistryValueKind.String);
                    if (File.Exists(@"C:\Windows\System32\cmd.exe"))
                    {
                        File.Copy(@"C:\Windows\System32\cmd.exe", @"C:\Windows\cmd.exe");
                    }
                    Environment.Exit(-1723);
                }
                catch(Exception ex)
                {
                    File.WriteAllText(@"C:\Temp\Error.txt", "Error: " + Environment.NewLine + ex.Message);
                    Process.Start("notepad", @"C:\Temp\Error.txt");
                    Environment.Exit(-5412);
                }
            }
        }
    }
}
