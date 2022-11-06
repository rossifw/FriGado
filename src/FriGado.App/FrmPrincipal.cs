using FriGado.App.Forms;
using FriGado.App.Login;
using FriGado.App.Splash;
using System;
using System.Windows.Forms;

namespace FriGado.App
{
    public partial class FrmPrincipal : Form
    {
        private Form frmAtivo;
        private Button btnAtivo;

        public FrmPrincipal()
        {
            Init();
            InitializeComponent();
        }

        private void Init()
        {
            new FrmSplash().ShowDialog();
            //new FrmLogin().ShowDialog();
        }

        private void CarregarForm(Form frm, Button btn)
        {
            FecharForm(frmAtivo, btnAtivo);
            frmAtivo = frm;
            frm.TopLevel = false;
            pnFrm.Controls.Add(frm);
            frm.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();

            btnAtivo=btn;
            btn.Enabled = false;
        }

        private void FecharForm(Form frm, Button btn)
        {
            if (frm != null)
            {
                frm.Close();
                frm.Dispose();
                frmAtivo = null;

                btn.Enabled = true;
                btnAtivo = null;
            }
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnPecuarista_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmPecuarista(), btnPecuarista);
        }

        private void btnAnimal_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmAnimal(), btnAnimal);
        }        

        private void btnCompraGado_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmCompraGado(), btnCompraGado);
        }

        private void btnCompraGadoItem_Click(object sender, EventArgs e)
        {
            CarregarForm(new FrmCompraGadoItem(), btnCompraGadoItem);
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            new FrmRelatorio().ShowDialog();
        }
    }
}
