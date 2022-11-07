using FriGado.App.Forms;
using FriGado.App.Login;
using FriGado.App.Models;
using FriGado.App.Splash;
using System;
using System.Data;
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
            new FrmLogin().ShowDialog();
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

            btnAtivo = btn;
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

        private async void btnRelatorio_Click(object sender, EventArgs e)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Animal");
            dataTable.Columns.Add("Quantidade");
            dataTable.Columns.Add("Preco");
            dataTable.Columns.Add("Total");

            var compraGadoItens = await CompraGadoItem.GetTodos();

            foreach (var item in compraGadoItens)
            {
                string[] cols = new string[4];
                cols[0] = item.Animal.Descricao;
                cols[1] = item.Quantidade.ToString();
                cols[2] = string.Format("{0:C}", item.Animal.Preco);
                cols[3] = string.Format("{0:C}", item.Quantidade * item.Animal.Preco);

                dataTable.Rows.Add(cols);
            }


            new FrmRelatorio(dataTable).ShowDialog();
        }
    }
}
