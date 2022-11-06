using FriGado.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriGado.App.Forms
{
    public partial class FrmCompraGado : Form
    {
        private List<Pecuarista> _pecuaristas;

        public FrmCompraGado()
        {
            InitializeComponent();
        }
        private async void FrmCompra_Load(object sender, EventArgs e)
        {
            comboPecuarista.Items.Add("Carregando ...");
            comboPecuarista.SelectedIndex = 0;

            _pecuaristas = await Pecuarista.GetTodos();
            comboPecuarista.Items.Clear();
            foreach (var item in _pecuaristas)
            {
                comboPecuarista.Items.Add($"ID:{item.Id} - Nome:{item.Nome}");
            }
            comboPecuarista.SelectedIndex = -1;
            comboPecuarista.Text = "";
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            try
            {
                List<CompraGado> lista = new List<CompraGado>();
                if (string.IsNullOrEmpty(txtId.Text))
                    lista = await CompraGado.GetTodos();
                else
                    lista.Add(await CompraGado.Get(Convert.ToInt32(txtId.Text)));

                var estrutura = new { Id = "", Pecuarista = "", Data = "" };

                dgv.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnPesquisar.Enabled = true;
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            btnAdicionar.Enabled = false;
            try
            {
                var compraGado = new CompraGado();
                compraGado.Id = -1;
                compraGado.Pecuarista = _pecuaristas[comboPecuarista.SelectedIndex];
                compraGado.DataEntrega = txtData.Value;

                if (await CompraGado.Adicionar(compraGado) == 1)
                {
                    txtId.Text = "";
                    comboPecuarista.SelectedIndex = -1;
                    comboPecuarista.Text = "";
                    txtData.Text = "";
                    var lista = await CompraGado.GetTodos();
                    dgv.DataSource = lista;
                }
                else
                    MessageBox.Show("Erro ao adicionar!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnAdicionar.Enabled = true;
        }

        private async void btnAlterar_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = false;
            try
            {
                var compraGado = new CompraGado();
                compraGado.Id = Convert.ToInt32(txtId.Text);
                compraGado.Pecuarista = _pecuaristas[comboPecuarista.SelectedIndex];
                compraGado.DataEntrega = txtData.Value;
                if (await CompraGado.Atualizar(compraGado) == 1)
                {
                    txtId.Text = "";
                    comboPecuarista.SelectedIndex = -1;
                    comboPecuarista.Text = "";
                    txtData.Text = "";
                    var lista = await CompraGado.GetTodos();
                    dgv.DataSource = lista;
                }
                else
                    MessageBox.Show("Erro ao alterar!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnAlterar.Enabled = true;
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            btnExcluir.Enabled = false;
            try
            {
                var compraGado = new CompraGado();
                compraGado.Id = Convert.ToInt32(txtId.Text);
                compraGado.Pecuarista = null;
                compraGado.DataEntrega = txtData.Value;
                if (await CompraGado.Remover(compraGado.Id) == 1)
                {
                    txtId.Text = "";
                    comboPecuarista.SelectedIndex = -1;
                    comboPecuarista.Text = "";
                    txtData.Text = "";
                    var lista = await CompraGado.GetTodos();
                    dgv.DataSource = lista;
                }
                else
                    MessageBox.Show("Erro ao remover!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnExcluir.Enabled = true;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linhaSelecionada = dgv.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgv.Rows[linhaSelecionada];
            txtId.Text = Convert.ToString(selectedRow.Cells["Id"].Value);
            //comboPecuarista.SelectedIndex = Convert.ToInt32(txtId.Text);
            txtData.Value = Convert.ToDateTime(selectedRow.Cells["DataEntrega"].Value);
        }


    }
}
