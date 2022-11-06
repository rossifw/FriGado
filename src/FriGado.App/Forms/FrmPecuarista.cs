using FriGado.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriGado.App.Forms
{
    public partial class FrmPecuarista : Form
    {
        public FrmPecuarista()
        {
            InitializeComponent();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            try
            {
                List<Pecuarista> lista = new List<Pecuarista>();
                if (string.IsNullOrEmpty(txtId.Text))
                    lista = await Pecuarista.GetTodos();
                else
                    lista.Add(await Pecuarista.Get(Convert.ToInt32(txtId.Text)));

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
                var pecuarista = new Pecuarista();
                pecuarista.Id = -1;
                pecuarista.Nome = txtNome.Text;
                if (await Pecuarista.Adicionar(pecuarista) == 1)
                {
                    txtId.Text = "";
                    txtNome.Text = "";
                    var lista = await Pecuarista.GetTodos();
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
                var pecuarista = new Pecuarista();
                pecuarista.Id = Convert.ToInt32(txtId.Text);
                pecuarista.Nome = txtNome.Text;
                if (await Pecuarista.Atualizar(pecuarista) == 1)
                {
                    txtId.Text = "";
                    txtNome.Text = "";
                    var lista = await Pecuarista.GetTodos();
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
                var pecuarista = new Pecuarista();
                pecuarista.Id = Convert.ToInt32(txtId.Text);
                pecuarista.Nome = txtNome.Text;
                if (await Pecuarista.Remover(pecuarista.Id) == 1)
                {
                    txtId.Text = "";
                    txtNome.Text = "";
                    var lista = await Pecuarista.GetTodos();
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
            txtNome.Text = Convert.ToString(selectedRow.Cells["Nome"].Value);
        }
    }
}
