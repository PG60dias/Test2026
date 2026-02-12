using Data.Modelo;
using Domain.Services;

namespace Desktop
{
    public partial class ClientesInsertForm : Form
    {
        private Cliente _nuevoCliente;
        private readonly ClienteService _service;
        private readonly CategoriaService _categoriaService;

        public ClientesInsertForm(ClienteService service, CategoriaService categoriaService)
        {
            InitializeComponent();
            _service = service;
            _categoriaService = categoriaService;
            _nuevoCliente = new Cliente();
        }

        public void InsertCliente()
        {
            this.Text = "Insertar Nuevo Cliente";
            _nuevoCliente = new Cliente();
        }

        private void ClientesInsertForm_Load(object sender, EventArgs e)
        {
            CategoriaCombobox.DataSource = _categoriaService.GetAllCategorias().ToList();

            clienteBindingSource.DataSource = _nuevoCliente;
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
			clienteBindingSource.EndEdit();

			try
			{
				_service.Repository.AddCliente(_nuevoCliente);

				MessageBox.Show("Guardado correctamente");
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al guardar: " + ex.Message);
			}
			this.Close();
		}

		private void CancelarButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

	