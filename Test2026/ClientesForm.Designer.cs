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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            ClientesGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            direccionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
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
            PremiumCheckBox = new CheckBox();
            toolTip1 = new ToolTip(components);
            ClientesStandardCheckBox = new CheckBox();
            ClientesPruebaCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)ClientesGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ClientesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ClientesGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            ClientesGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ClientesGridView.AutoGenerateColumns = false;
            ClientesGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ClientesGridView.BackgroundColor = SystemColors.InactiveCaption;
            ClientesGridView.BorderStyle = BorderStyle.None;
            ClientesGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ClientesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ClientesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientesGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, direccionDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, Categoria });
            ClientesGridView.ContextMenuStrip = contextMenuStrip1;
            ClientesGridView.DataSource = ClientesBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ClientesGridView.DefaultCellStyle = dataGridViewCellStyle3;
            ClientesGridView.EnableHeadersVisualStyles = false;
            ClientesGridView.GridColor = Color.FromArgb(230, 230, 230);
            ClientesGridView.Location = new Point(24, 86);
            ClientesGridView.Name = "ClientesGridView";
            ClientesGridView.ReadOnly = true;
            ClientesGridView.ScrollBars = ScrollBars.Vertical;
            ClientesGridView.Size = new Size(714, 372);
            ClientesGridView.TabIndex = 0;
            ClientesGridView.DoubleClick += ClientesGridView_DoubleClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.FillWeight = 50F;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 50;
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
            direccionDataGridViewTextBoxColumn.FillWeight = 180F;
            direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            direccionDataGridViewTextBoxColumn.ReadOnly = true;
            direccionDataGridViewTextBoxColumn.Width = 180;
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
            label1.Location = new Point(341, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 41);
            label1.TabIndex = 1;
            label1.Text = "GESTOR CLIENTES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(765, 102);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 2;
            label2.Text = "Filtrar Cliente:";
            label2.MouseHover += FiltrarButton_MouseHover;
            // 
            // FiltrarTextBox
            // 
            FiltrarTextBox.Location = new Point(765, 120);
            FiltrarTextBox.Name = "FiltrarTextBox";
            FiltrarTextBox.Size = new Size(146, 23);
            FiltrarTextBox.TabIndex = 3;
            FiltrarTextBox.MouseHover += FiltrarButton_MouseHover;
            // 
            // FiltrarButton
            // 
            FiltrarButton.FlatAppearance.BorderSize = 0;
            FiltrarButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            FiltrarButton.FlatStyle = FlatStyle.Flat;
            FiltrarButton.Location = new Point(810, 149);
            FiltrarButton.Name = "FiltrarButton";
            FiltrarButton.Size = new Size(53, 23);
            FiltrarButton.TabIndex = 4;
            FiltrarButton.Text = "Filtrar";
            FiltrarButton.UseVisualStyleBackColor = true;
            FiltrarButton.Click += FiltrarButton_Click;
            FiltrarButton.MouseHover += FiltrarButton_MouseHover;
            // 
            // ResetButton
            // 
            ResetButton.FlatAppearance.BorderSize = 0;
            ResetButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            ResetButton.FlatStyle = FlatStyle.Flat;
            ResetButton.Location = new Point(810, 178);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(53, 23);
            ResetButton.TabIndex = 5;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            ResetButton.MouseHover += ResetButton_MouseHover;
            // 
            // InsertarButton
            // 
            InsertarButton.FlatAppearance.BorderSize = 0;
            InsertarButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            InsertarButton.FlatStyle = FlatStyle.Flat;
            InsertarButton.Location = new Point(810, 321);
            InsertarButton.Name = "InsertarButton";
            InsertarButton.Size = new Size(53, 23);
            InsertarButton.TabIndex = 6;
            InsertarButton.Text = "Insert";
            InsertarButton.UseVisualStyleBackColor = true;
            InsertarButton.Click += InsertarButton_Click;
            InsertarButton.MouseHover += InsertarButton_MouseHover;
            // 
            // PremiumCheckBox
            // 
            PremiumCheckBox.AutoSize = true;
            PremiumCheckBox.Location = new Point(765, 280);
            PremiumCheckBox.Name = "PremiumCheckBox";
            PremiumCheckBox.Size = new Size(120, 19);
            PremiumCheckBox.TabIndex = 7;
            PremiumCheckBox.Text = "Clientes Premium";
            PremiumCheckBox.UseVisualStyleBackColor = true;
            PremiumCheckBox.CheckedChanged += PremiumCheckBox_MouseHover;
            // 
            // ClientesStandardCheckBox
            // 
            ClientesStandardCheckBox.AutoSize = true;
            ClientesStandardCheckBox.Location = new Point(765, 255);
            ClientesStandardCheckBox.Name = "ClientesStandardCheckBox";
            ClientesStandardCheckBox.Size = new Size(118, 19);
            ClientesStandardCheckBox.TabIndex = 8;
            ClientesStandardCheckBox.Text = "Clientes Standard";
            ClientesStandardCheckBox.UseVisualStyleBackColor = true;
            ClientesStandardCheckBox.CheckedChanged += ClientesStandarCheckBox_CheckedChanged;
            // 
            // ClientesPruebaCheckBox
            // 
            ClientesPruebaCheckBox.AutoSize = true;
            ClientesPruebaCheckBox.Location = new Point(765, 230);
            ClientesPruebaCheckBox.Name = "ClientesPruebaCheckBox";
            ClientesPruebaCheckBox.Size = new Size(108, 19);
            ClientesPruebaCheckBox.TabIndex = 9;
            ClientesPruebaCheckBox.Text = "Clientes Prueba";
            ClientesPruebaCheckBox.UseVisualStyleBackColor = true;
            ClientesPruebaCheckBox.CheckedChanged += ClientePruebaCheckBox_CheckedChanged;
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(933, 499);
            Controls.Add(ClientesPruebaCheckBox);
            Controls.Add(ClientesStandardCheckBox);
            Controls.Add(PremiumCheckBox);
            Controls.Add(InsertarButton);
            Controls.Add(ResetButton);
            Controls.Add(FiltrarButton);
            Controls.Add(FiltrarTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ClientesGridView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ClientesForm";
            SizeGripStyle = SizeGripStyle.Show;
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
        private CheckBox PremiumCheckBox;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Categoria;
        private ToolTip toolTip1;
        private CheckBox ClientesStandardCheckBox;
        private CheckBox ClientesPruebaCheckBox;
    }
}
