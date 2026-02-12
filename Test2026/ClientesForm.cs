using System.ComponentModel;
using System.Linq;
using Data.DTOs;
using Data.Modelo;
using Desktop;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Test2026
{
    public partial class ClientesForm : Form
    {
        private readonly ClienteService _service;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<ClienteDTO> _clientesBindingList;

        public ClientesForm(ClienteService service, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _service = service;
            _serviceProvider = serviceProvider;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            var ds = _service.Repository.GetAllClientes();
            ClientesBindingSource.DataSource = ds;
        }

        private void ClientesGridView_DoubleClick(object sender, EventArgs e)
        {

            if (ClientesGridView.CurrentRow.DataBoundItem is ClienteDTO clientedto)
            {
				var cliente = _service.Repository.GetCliente(clientedto.Id);
				if (cliente != null)
				{
					using var scope = _serviceProvider.CreateScope();
					var form = scope.ServiceProvider.GetRequiredService<ClientesEditForm>();
					form.EditCliente(cliente);
					form.ShowDialog();
					LoadDataSource();
				}
            }
        }

        private void FiltrarButton_Click(object sender, EventArgs e)
        {
            AplicarFiltros();

        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            FiltrarTextBox.Text = "";
            PremiumCheckBox.Checked = false;
            ClientesStandardCheckBox.Checked = false;
            ClientesPruebaCheckBox.Checked = false;
            LoadDataSource();
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            int idABorrar = int.Parse(ClientesGridView.CurrentRow.Cells[0].Value.ToString());
            _service.Repository.DeleteCliente(idABorrar);
            LoadDataSource();
        }


		private void subirCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int idcliente = int.Parse(ClientesGridView.CurrentRow.Cells[0].Value.ToString());
			var cliente = _service.Repository.GetCliente(idcliente);

			if (cliente != null)
			{
				bool cambio = false;

				if (cliente.Categoria == 3) 
				{
					cliente.Categoria = 1;
					cambio = true;
				}
				else if (cliente.Categoria == 1)
				{
					cliente.Categoria = 2;
					cambio = true;
				}
				if (cambio)
				{
					_service.Repository.UpdateCliente(cliente);
					LoadDataSource();
				}
			}
		}

		private void InsertarButton_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<ClientesInsertForm>();
            form.InsertCliente();
            form.ShowDialog();
            LoadDataSource();
        }

        private void PremiumCheckBox_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.PremiumCheckBox, "Filtra por los clientes con premium");
        }

        private void InsertarButton_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.InsertarButton, "Insertar un nuevo cliente");
        }

        private void ResetButton_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.ResetButton, "Resetea los filtros de la lista");
        }

        private void FiltrarButton_MouseHover(object sender, EventArgs e)
        {
            string text = "Filtra por el texto introducido";

            toolTip1.SetToolTip(this.label2, text);
            toolTip1.SetToolTip(this.FiltrarTextBox, text);
            toolTip1.SetToolTip(this.FiltrarButton, text);

        }

        private void ClientesPremiumCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        private void ClientesStandarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void ClientePruebaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            var seleccionados = new List<int>();
            if (PremiumCheckBox.Checked) seleccionados.Add((int)CategoriaCliente.VIP);
            if (ClientesStandardCheckBox.Checked) seleccionados.Add((int)CategoriaCliente.Habitual);
            if (ClientesPruebaCheckBox.Checked) seleccionados.Add((int)CategoriaCliente.DePaso);

            List<int> filtroCategorias = seleccionados.Any() ? seleccionados : null;

            var resultado = _service.GetClientesFiltrados(filtroCategorias, FiltrarTextBox.Text);

            _clientesBindingList = new BindingList<ClienteDTO>(resultado.ToList());
            ClientesBindingSource.DataSource = _clientesBindingList;
        }


    }
}
