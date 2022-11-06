using FriGado.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriGado.App.Forms
{
    public partial class FrmCompraGadoItem : Form
    {
        public FrmCompraGadoItem()
        {
            InitializeComponent();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            try
            {
                List<CompraGadoItem> lista = new List<CompraGadoItem>();
                if (string.IsNullOrEmpty(txtId.Text))
                    lista = await CompraGadoItem.GetTodos();
                else
                    lista.Add(await CompraGadoItem.Get(Convert.ToInt32(txtId.Text)));

                dgv.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnPesquisar.Enabled = true;
        }
    }
}
