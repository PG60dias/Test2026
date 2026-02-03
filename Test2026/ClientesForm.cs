using System.ComponentModel;
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

        private void ClientesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
