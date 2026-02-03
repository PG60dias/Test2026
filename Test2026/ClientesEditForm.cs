using Data.Modelo;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Desktop
{
    public partial class ClientesEditForm : Form
    {
        private Cliente _cliente;
        private readonly ClienteService _service;
        private readonly CategoriaService _categoriaService;


		public ClientesEditForm(ClienteService service, CategoriaService categoriaService)
        {
            InitializeComponent();
            _service = service;
            _categoriaService = categoriaService;
			AceptarButton.Enabled = false;
        }

        public void NewCliente()
        {
            this.Text = "Nuevo Cliente";
            _cliente = new Cliente();
        }

        public void EditCliente(int idCliente)
        {
            this.Text = "Editar Cliente";
            _cliente = _service.Repository.GetCliente(idCliente);
        }


        private void ClientesEditForm_Load(object sender, EventArgs e)
        {
            CategoriaCombobox.DataSource = _categoriaService.GetCategorias().ToList();
            ClienteBindingSource.DataSource = _cliente;
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            _service.Repository.UpdateCliente(_cliente);
			this.Close();

		}

		private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            ClienteService.UpdateNombre(_cliente);
			ActualizarEstadoBoton();
		}
		private void ActualizarEstadoBoton()
		{
			bool huboCambios = false;

			if (NombreTextBox.Text != _cliente.Nombre) huboCambios = true;
			if (DireccionTextBox.Text != _cliente.Direccion) huboCambios = true;
			if (EmailTextBox.Text != _cliente.Email) huboCambios = true;
			if (TelefonoTextBox.Text != _cliente.Telefono) huboCambios = true;

			if (CategoriaCombobox.SelectedValue != null)
			{
				int idSeleccionado = (int)CategoriaCombobox.SelectedValue;
				if (idSeleccionado != _cliente.Categoria) huboCambios = true;
			}
			AceptarButton.Enabled = huboCambios;
		}

		private void CategoriaCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ActualizarEstadoBoton();
		}

		private void CamposTextBox_TextChanged(object sender, EventArgs e)
		{
			ActualizarEstadoBoton();
		}
	}
}
