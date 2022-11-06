using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriGado.App.Splash
{
    public partial class FrmSplash : Form
    {
        private bool isItToClose = false;

        public FrmSplash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void FrmSplash_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isItToClose;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isItToClose = true;
            this.Close();
        }
    }
}
