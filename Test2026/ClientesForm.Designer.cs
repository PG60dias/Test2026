namespace Test2026
{
    partial class ClientesForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ClientesGridView = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            Borrar = new ToolStripMenuItem();
            ClientesBindingSource = new BindingSource(components);
            categoriaBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            FiltrarTextBox = new TextBox();
            FiltrarButton = new Button();
            ResetButton = new Button();
            InsertarButton = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            direccionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ClientesGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ClientesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ClientesGridView
            // 
            ClientesGridView.AutoGenerateColumns = false;
            ClientesGridView.BackgroundColor = SystemColors.ActiveCaption;
            ClientesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientesGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, direccionDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, Categoria });
            ClientesGridView.ContextMenuStrip = contextMenuStrip1;
            ClientesGridView.DataSource = ClientesBindingSource;
            ClientesGridView.Location = new Point(33, 86);
            ClientesGridView.Name = "ClientesGridView";
            ClientesGridView.ReadOnly = true;
            ClientesGridView.Size = new Size(703, 350);
            ClientesGridView.TabIndex = 0;
            ClientesGridView.CellContentClick += ClientesGridView_CellContentClick;
            ClientesGridView.DoubleClick += ClientesGridView_DoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { Borrar });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(107, 26);
            // 
            // Borrar
            // 
            Borrar.Name = "Borrar";
            Borrar.Size = new Size(106, 22);
            Borrar.Text = "Borrar";
            Borrar.Click += Borrar_Click;
            // 
            // ClientesBindingSource
            // 
            ClientesBindingSource.DataSource = typeof(Data.DTOs.ClienteDTO);
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Data.Modelo.Categoria);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F);
            label1.Location = new Point(261, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 41);
            label1.TabIndex = 1;
            label1.Text = "GESTOR CLIENTES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 60);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 2;
            label2.Text = "Campo:";
            // 
            // FiltrarTextBox
            // 
            FiltrarTextBox.Location = new Point(79, 57);
            FiltrarTextBox.Name = "FiltrarTextBox";
            FiltrarTextBox.Size = new Size(146, 23);
            FiltrarTextBox.TabIndex = 3;
            // 
            // FiltrarButton
            // 
            FiltrarButton.Location = new Point(231, 57);
            FiltrarButton.Name = "FiltrarButton";
            FiltrarButton.Size = new Size(75, 23);
            FiltrarButton.TabIndex = 4;
            FiltrarButton.Text = "FILTRAR";
            FiltrarButton.UseVisualStyleBackColor = true;
            FiltrarButton.Click += FiltrarButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(312, 57);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(53, 23);
            ResetButton.TabIndex = 5;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // InsertarButton
            // 
            InsertarButton.Location = new Point(661, 60);
            InsertarButton.Name = "InsertarButton";
            InsertarButton.Size = new Size(75, 23);
            InsertarButton.TabIndex = 6;
            InsertarButton.Text = "Insert";
            InsertarButton.UseVisualStyleBackColor = true;
            InsertarButton.Click += InsertarButton_Click;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.FillWeight = 110F;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 110;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.FillWeight = 110F;
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            nombreDataGridViewTextBoxColumn.Width = 110;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            direccionDataGridViewTextBoxColumn.FillWeight = 110F;
            direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            direccionDataGridViewTextBoxColumn.ReadOnly = true;
            direccionDataGridViewTextBoxColumn.Width = 110;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.FillWeight = 110F;
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 110;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            telefonoDataGridViewTextBoxColumn.FillWeight = 110F;
            telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            telefonoDataGridViewTextBoxColumn.Width = 110;
            // 
            // Categoria
            // 
            Categoria.DataPropertyName = "CategoriaNombre";
            Categoria.FillWeight = 110F;
            Categoria.HeaderText = "Categoria";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 110;
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 457);
            Controls.Add(InsertarButton);
            Controls.Add(ResetButton);
            Controls.Add(FiltrarButton);
            Controls.Add(FiltrarTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ClientesGridView);
            Name = "ClientesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor Clientes";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ClientesGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ClientesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ClientesGridView;
        private BindingSource ClientesBindingSource;
        private BindingSource categoriaBindingSource;
        private DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private Label label1;
        private Label label2;
        private TextBox FiltrarTextBox;
        private Button FiltrarButton;
        private Button ResetButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Borrar;
        private Button InsertarButton;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Categoria;
    }
}
