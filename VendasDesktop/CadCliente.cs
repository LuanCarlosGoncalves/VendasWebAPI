using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendasDesktop.Model;
using static System.Net.Mime.MediaTypeNames;

namespace VendasDesktop
{
    public partial class CadCliente : Form
    {
        private readonly HttpClient _httpClient;
        public CadCliente()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7234/");
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new CadastrarCliente
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Profissao = txtProfissao.Text,
                Telefone = txtTelefone.Text,
            };

            var clienteJson = JsonConvert.SerializeObject(cliente);

            var conteudo = new StringContent(clienteJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Cliente", conteudo);

            if (response.IsSuccessStatusCode)
            {
                var resposta = await response.Content.ReadAsStringAsync();

                MessageBox.Show(resposta);
            }
            else
            {
                // Lidar com resposta de erro, se necessário

            }
        }
    }
}
