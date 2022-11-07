using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriGado.App.Login
{
    public partial class FrmLogin : Form
    {
        private bool isItToExit = true;

        private static readonly string _url = $"{Config.APIUrl}/login";
        private static readonly HttpClient _client = new HttpClient();

        public FrmLogin()
        {
            InitializeComponent();
        }





        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isItToExit)
                Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autenticar(txtUsuario.Text, txtSenha.Text);
        }

        private async void Autenticar(string usuario, string senha)
        {
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            btnEntrar.Enabled = false;

            var hashSenha = GetHMAC(senha);
            var credencial = new { Login = usuario, Senha = hashSenha };

            var content = new StringContent(JsonConvert.SerializeObject(credencial), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, content).Result.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<Token>(response);

            if (token.Authenticated)
            {
                Config.BearerToken = token.AccessToken;
                isItToExit = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(token.Message);
                txtUsuario.Enabled = true;
                txtSenha.Enabled = true;
                btnEntrar.Enabled = true;

                txtUsuario.Text = "";
                txtSenha.Text = "";
            }
        }

        private string GetHMAC(string text)
        {
            byte[] hash;
            string key = Config.HKey;

            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            }

            var sBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private class Token
        {
            public bool Authenticated { get; set; }
            public string AccessToken { get; set; }
            public string Message { get; set; }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
                txtSenha.Focus();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
                Autenticar(txtUsuario.Text, txtSenha.Text);
        }
    }
}
