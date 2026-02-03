using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            CategoriaCombobox.DataSource = _categoriaService.GetCategorias().ToList();

            clienteBindingSource.DataSource = _nuevoCliente;
        }
        private void AceptarButton_Click(object sender, EventArgs e)
        {
			clienteBindingSource.EndEdit();
			_service.Repository.AddCliente(_nuevoCliente);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

        private void CancelarButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

	