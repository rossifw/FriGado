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
    public partial class FrmAnimal : Form
    {
        public FrmAnimal()
        {
            InitializeComponent();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            try
            {
                List<Animal> lista = new List<Animal>();
                if (string.IsNullOrEmpty(txtId.Text))
                    lista = await Animal.GetTodos();
                else
                    lista.Add(await Animal.Get(Convert.ToInt32(txtId.Text)));

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
                var animal = new Animal();
                animal.Id = -1;
                animal.Descricao = txtDescicao.Text;
                animal.Preco = Convert.ToDecimal(txtPreco.Text);
                if (await Animal.Adicionar(animal) == 1)
                {
                    txtId.Text = "";
                    txtDescicao.Text = "";
                    txtPreco.Text = "";
                    var lista = await Animal.GetTodos();
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
                var animal = new Animal();
                animal.Id = Convert.ToInt32(txtId.Text);
                animal.Descricao = txtDescicao.Text;
                animal.Preco = Convert.ToDecimal(txtPreco.Text);
                if (await Animal.Atualizar(animal) == 1)
                {
                    txtId.Text = "";
                    txtDescicao.Text = "";
                    txtPreco.Text = "";
                    var lista = await Animal.GetTodos();
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
                var animal = new Animal();
                animal.Id = Convert.ToInt32(txtId.Text);
                animal.Descricao = txtDescicao.Text;
                animal.Preco = Convert.ToDecimal(txtPreco.Text);
                if (await Animal.Remover(animal.Id) == 1)
                {
                    txtId.Text = "";
                    txtDescicao.Text = "";
                    txtPreco.Text = "";
                    var lista = await Animal.GetTodos();
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
            txtDescicao.Text = Convert.ToString(selectedRow.Cells["Descricao"].Value);
            txtPreco.Text = Convert.ToString(selectedRow.Cells["Preco"].Value);
        }
    }
}
