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

namespace VendasDesktop
{
    public partial class CadCategoria : Form
    {
        private readonly HttpClient _httpClient;

        public CadCategoria()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7234/");
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var cadastrarCategoria = new CadastrarCategoria();

            cadastrarCategoria.Nome = txtNome.Text;
            cadastrarCategoria.Medida = Convert.ToInt32(txtMedida.Text);
            cadastrarCategoria.Tipo = txtTipo.Text;

            var categoriaJson = JsonConvert.SerializeObject(cadastrarCategoria);
            
            var conteudo = new StringContent(categoriaJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Categoria", conteudo);

            if (response.IsSuccessStatusCode)
            {
                var resposta = await response.Content.ReadAsStringAsync();

                MessageBox.Show(resposta);
            }
            else
            {
                var resposta = await response.Content.ReadAsStringAsync();
                MessageBox.Show("ERRO --->"+resposta);

            }
        }
    }
}
