namespace Desktop
{
    partial class ClientesEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ClienteBindingSource = new BindingSource(components);
            NombreTextBox = new TextBox();
            label2 = new Label();
            DireccionTextBox = new TextBox();
            label3 = new Label();
            EmailTextBox = new TextBox();
            label4 = new Label();
            TelefonoTextBox = new TextBox();
            label5 = new Label();
            CategoriaCombobox = new ComboBox();
            categoriaBindingSource = new BindingSource(components);
            AceptarButton = new Button();
            CancelarButton = new Button();
            TestButton = new Button();
            label6 = new Label();
            ClientesBindingSource = new BindingSource(components);
            label1 = new Label();
            IdTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ClienteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClientesBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ClienteBindingSource
            // 
            ClienteBindingSource.DataSource = typeof(Data.DTOs.ClienteDTO);
            // 
            // NombreTextBox
            // 
            NombreTextBox.DataBindings.Add(new Binding("Text", ClienteBindingSource, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged));
            NombreTextBox.Location = new Point(98, 85);
            NombreTextBox.Name = "NombreTextBox";
            NombreTextBox.Size = new Size(156, 23);
            NombreTextBox.TabIndex = 3;
            NombreTextBox.TextChanged += CamposTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 88);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // DireccionTextBox
            // 
            DireccionTextBox.DataBindings.Add(new Binding("Text", ClienteBindingSource, "Direccion", true, DataSourceUpdateMode.OnPropertyChanged));
            DireccionTextBox.Location = new Point(98, 114);
            DireccionTextBox.Name = "DireccionTextBox";
            DireccionTextBox.Size = new Size(156, 23);
            DireccionTextBox.TabIndex = 5;
            DireccionTextBox.TextChanged += CamposTextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 117);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Dirección:";
            // 
            // EmailTextBox
            // 
            EmailTextBox.DataBindings.Add(new Binding("Text", ClienteBindingSource, "Email", true, DataSourceUpdateMode.OnPropertyChanged));
            EmailTextBox.Location = new Point(98, 143);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(156, 23);
            EmailTextBox.TabIndex = 7;
            EmailTextBox.TextChanged += CamposTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 146);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // TelefonoTextBox
            // 
            TelefonoTextBox.DataBindings.Add(new Binding("Text", ClienteBindingSource, "Telefono", true, DataSourceUpdateMode.OnPropertyChanged));
            TelefonoTextBox.Location = new Point(98, 172);
            TelefonoTextBox.Name = "TelefonoTextBox";
            TelefonoTextBox.Size = new Size(156, 23);
            TelefonoTextBox.TabIndex = 9;
            TelefonoTextBox.TextChanged += CamposTextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 175);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 8;
            label5.Text = "Teléfono:";
            // 
            // CategoriaCombobox
            // 
            CategoriaCombobox.DataBindings.Add(new Binding("SelectedValue", ClienteBindingSource, "Categoria", true));
            CategoriaCombobox.DisplayMember = "Nombre";
            CategoriaCombobox.FormattingEnabled = true;
            CategoriaCombobox.Location = new Point(98, 201);
            CategoriaCombobox.Name = "CategoriaCombobox";
            CategoriaCombobox.Size = new Size(156, 23);
            CategoriaCombobox.TabIndex = 10;
            CategoriaCombobox.ValueMember = "Id";
            CategoriaCombobox.SelectedIndexChanged += CategoriaCombobox_SelectedIndexChanged;
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Data.Modelo.Categoria);
            // 
            // AceptarButton
            // 
            AceptarButton.FlatAppearance.BorderSize = 0;
            AceptarButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            AceptarButton.FlatStyle = FlatStyle.Flat;
            AceptarButton.Location = new Point(98, 291);
            AceptarButton.Name = "AceptarButton";
            AceptarButton.Size = new Size(75, 23);
            AceptarButton.TabIndex = 11;
            AceptarButton.Text = "Aceptar";
            AceptarButton.UseVisualStyleBackColor = true;
            AceptarButton.Click += AceptarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.FlatAppearance.BorderSize = 0;
            CancelarButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            CancelarButton.FlatStyle = FlatStyle.Flat;
            CancelarButton.Location = new Point(179, 291);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 12;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // TestButton
            // 
            TestButton.FlatAppearance.BorderSize = 0;
            TestButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            TestButton.FlatStyle = FlatStyle.Flat;
            TestButton.Location = new Point(425, 274);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(90, 57);
            TestButton.TabIndex = 13;
            TestButton.Text = "lógica negocio (mayus nom)";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 201);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 14;
            label6.Text = "Categoría";
            // 
            // ClientesBindingSource
            // 
            ClientesBindingSource.DataSource = typeof(Data.DTOs.ClienteDTO);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 59);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // IdTextBox
            // 
            IdTextBox.DataBindings.Add(new Binding("Text", ClienteBindingSource, "Id", true));
            IdTextBox.Location = new Point(98, 56);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.Size = new Size(156, 23);
            IdTextBox.TabIndex = 1;
            // 
            // ClientesEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(527, 343);
            Controls.Add(label6);
            Controls.Add(TestButton);
            Controls.Add(CancelarButton);
            Controls.Add(AceptarButton);
            Controls.Add(CategoriaCombobox);
            Controls.Add(TelefonoTextBox);
            Controls.Add(label5);
            Controls.Add(EmailTextBox);
            Controls.Add(label4);
            Controls.Add(DireccionTextBox);
            Controls.Add(label3);
            Controls.Add(NombreTextBox);
            Controls.Add(label2);
            Controls.Add(IdTextBox);
            Controls.Add(label1);
            Name = "ClientesEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientesEditForm";
            Load += ClientesEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)ClienteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClientesBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox NombreTextBox;
        private Label label2;
        private TextBox DireccionTextBox;
        private Label label3;
        private TextBox EmailTextBox;
        private Label label4;
        private TextBox TelefonoTextBox;
        private Label label5;
        private ComboBox CategoriaCombobox;
        private Button AceptarButton;
        private Button CancelarButton;
        private BindingSource ClienteBindingSource;
        private Button TestButton;
        private BindingSource categoriaBindingSource;
        private Label label6;
        private BindingSource ClientesBindingSource;
        private Label label1;
        private TextBox IdTextBox;
    }
}