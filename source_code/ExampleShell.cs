using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegShell;

namespace ExampleShellOverwrite
{
    public partial class ExampleShell : Form
    {
        public ExampleShell()
        {
            InitializeComponent();
            ShellRegistry shell = new ShellRegistry();
            shell.ShellOverwrite();
        }
    }
}
