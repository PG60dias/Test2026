using Data.DTOs;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Desktop
{ 
    public partial class ClientesEditForm : Form
    {
        private ClienteDTO _cliente = null!;
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
            _cliente = new ClienteDTO();
        }

        public void EditCliente(ClienteDTO ClienteOriginal)
        {
			this.Text = "Editar Cliente";
			_cliente = ClienteOriginal;
		
        }


        private void ClientesEditForm_Load(object sender, EventArgs e)
        {
            CategoriaCombobox.DataSource = _categoriaService.GetCategorias().ToList();
            ClienteBindingSource.DataSource = _cliente;
		}

        private void AceptarButton_Click(object sender, EventArgs e)
        {
			ClienteBindingSource.EndEdit();
			_service.Repository.UpdateCliente(_cliente);
			this.DialogResult = DialogResult.OK;
            this.Close();

		}

		private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            ClienteService.UpdateNombre(_cliente);
			AceptarButton.Enabled = true;
		}
		private void ActualizarEstadoBoton()
		{
			int idSeleccionado = 0;
			if (CategoriaCombobox.SelectedValue != null && CategoriaCombobox.SelectedValue is int)
			{
				idSeleccionado = (int)CategoriaCombobox.SelectedValue;
			}
			AceptarButton.Enabled = _service.HanCambiadoLosDatos(
		                                                _cliente,
		                                                NombreTextBox.Text,
		                                                DireccionTextBox.Text,
		                                                EmailTextBox.Text,
		                                                TelefonoTextBox.Text,
		                                                idSeleccionado);
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
