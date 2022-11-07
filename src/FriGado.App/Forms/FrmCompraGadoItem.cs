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
        private List<CompraGado> _compraGado = null;
        private List<Animal> _animal = null;


        public FrmCompraGadoItem()
        {
            InitializeComponent();
        }

        private async void FrmCompraGadoItem_Load(object sender, EventArgs e)
        {
            comboCompraGado.Items.Add("Carregando ...");
            comboAnimal.Items.Add("Carregando ...");

            comboCompraGado.SelectedIndex = 0;
            comboAnimal.SelectedIndex = 0;

            _compraGado = await CompraGado.GetTodos();
            _animal = await Animal.GetTodos();

            comboCompraGado.Items.Clear();
            comboAnimal.Items.Clear();

            foreach (var item in _compraGado)
                comboCompraGado.Items.Add($"ID:{item.Id} - Nome:{item.Pecuarista.Nome}");

            foreach (var item in _animal)
                comboAnimal.Items.Add($"ID:{item.Id} - Descrição:{item.Descricao} - Preço:{item.Preco}");

            comboCompraGado.SelectedIndex = -1;
            comboAnimal.SelectedIndex = -1;

            comboCompraGado.Text = "";
            comboAnimal.Text = "";
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

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {

            btnAdicionar.Enabled = false;
            try
            {
                CompraGado compraGado = _compraGado[comboCompraGado.SelectedIndex];
                Animal animal = _animal[comboAnimal.SelectedIndex];
                var quantidade = Convert.ToInt32(txtQuantidade.Text);

                var compraGadoItem = new CompraGadoItem();
                compraGadoItem.Id = -1;
                compraGadoItem.CompraGado = compraGado;
                compraGadoItem.Animal=animal;
                compraGadoItem.Quantidade = quantidade;

                
                if (await CompraGadoItem.Adicionar(compraGadoItem) == 1)
                {
                    txtId.Text = "";
                    comboAnimal.Text = "";
                    comboCompraGado.Text = "";
                    txtQuantidade.Text = "";

                    comboAnimal.SelectedIndex = -1;
                    comboCompraGado.SelectedIndex = -1;

                    var lista = await CompraGadoItem.GetTodos();
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
                CompraGado compraGado = _compraGado[comboCompraGado.SelectedIndex];
                Animal animal = _animal[comboAnimal.SelectedIndex];
                var quantidade = Convert.ToInt32(txtQuantidade.Text);

                var compraGadoItem = new CompraGadoItem();
                compraGadoItem.Id = Convert.ToInt32(txtId.Text);
                compraGadoItem.CompraGado = compraGado;
                compraGadoItem.Animal = animal;
                compraGadoItem.Quantidade = quantidade;

                if (await CompraGadoItem.Atualizar(compraGadoItem) == 1)
                {
                    txtId.Text = "";
                    comboAnimal.Text = "";
                    comboCompraGado.Text = "";
                    txtQuantidade.Text = "";

                    comboAnimal.SelectedIndex = -1;
                    comboCompraGado.SelectedIndex = -1;

                    var lista = await CompraGadoItem.GetTodos();
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
                CompraGado compraGado = _compraGado[comboCompraGado.SelectedIndex];
                Animal animal = _animal[comboAnimal.SelectedIndex];
                var quantidade = Convert.ToInt32(txtQuantidade.Text);

                var compraGadoItem = new CompraGadoItem();
                compraGadoItem.Id = Convert.ToInt32(txtId.Text);
                compraGadoItem.CompraGado = compraGado;
                compraGadoItem.Animal = animal;
                compraGadoItem.Quantidade = quantidade;

                if (await CompraGadoItem.Remover(compraGadoItem.Id) == 1)
                {
                    txtId.Text = "";
                    comboAnimal.Text = "";
                    comboCompraGado.Text = "";
                    txtQuantidade.Text = "";

                    comboAnimal.SelectedIndex = -1;
                    comboCompraGado.SelectedIndex = -1;

                    var lista = await CompraGadoItem.GetTodos();
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
            txtQuantidade.Text = Convert.ToString(selectedRow.Cells["Quantidade"].Value);
        }
    }
}
