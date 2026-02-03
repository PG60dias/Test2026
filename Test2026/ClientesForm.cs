using System.ComponentModel;
using System.Linq;
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
        private BindingList<Cliente> _clientesBindingList;

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
            ClientesBindingSource.DataSource = _service.Repository.GetAllClientes();
        }

        private void ClientesGridView_DoubleClick(object sender, EventArgs e)
        {
            if (ClientesGridView.CurrentRow.DataBoundItem is Cliente cliente)
            {
                using var scope = _serviceProvider.CreateScope();
                var form = scope.ServiceProvider.GetRequiredService<ClientesEditForm>();
                form.EditCliente(cliente.Id);
                form.ShowDialog();
                LoadDataSource();
            }
        }

        private void FiltrarButton_Click(object sender, EventArgs e)
        {
            var filtrados = _service.Repository.GetClientesFiltrados(FiltrarTextBox.Text);
            _clientesBindingList = new BindingList<Cliente>(filtrados.ToList());
            ClientesBindingSource.DataSource = _clientesBindingList;
            ClientesGridView.Refresh();

        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            FiltrarTextBox.Text = "";
            LoadDataSource();
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            int idABorrar = int.Parse(ClientesGridView.CurrentRow.Cells[0].Value.ToString());
            _service.Repository.DeleteCliente(idABorrar);
            LoadDataSource();
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
            var clientes = _service.Repository.GetAllClientes().AsEnumerable();

            List<int> categoriasSeleccionadas = new List<int>();

            if (PremiumCheckBox.Checked) categoriasSeleccionadas.Add(2);
            if (ClientesStandardCheckBox.Checked) categoriasSeleccionadas.Add(1);
            if (ClientesPruebaCheckBox.Checked) categoriasSeleccionadas.Add(3);

            if (categoriasSeleccionadas.Any())
            {
                clientes = clientes.Where(c => categoriasSeleccionadas.Contains(c.Categoria ?? 0));
            }

            _clientesBindingList = new BindingList<Cliente>(clientes.ToList());
            ClientesBindingSource.DataSource = _clientesBindingList;
        }


    }
}
