using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriGado.App.Login
{
    public partial class FrmLogin : Form
    {
        private bool isItToClose = true;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isItToClose)
                Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isItToClose = !isItToClose;
            this.Close();
        }
    }
}
