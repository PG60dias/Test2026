namespace Desktop
{
    partial class ClientesInsertForm
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
            label6 = new Label();
            CancelarButton = new Button();
            AceptarButton = new Button();
            clienteBindingSource = new BindingSource(components);
            categoriaBindingSource = new BindingSource(components);
            TelefonoTextBox = new TextBox();
            label5 = new Label();
            EmailTextBox = new TextBox();
            label4 = new Label();
            DireccionTextBox = new TextBox();
            label3 = new Label();
            NombreTextBox = new TextBox();
            label2 = new Label();
            CategoriaCombobox = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(117, 192);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 28;
            label6.Text = "Categoría";
            // 
            // CancelarButton
            // 
            CancelarButton.FlatAppearance.BorderSize = 0;
            CancelarButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            CancelarButton.FlatStyle = FlatStyle.Flat;
            CancelarButton.Location = new Point(263, 254);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 27;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click_1;
            // 
            // AceptarButton
            // 
            AceptarButton.FlatAppearance.BorderSize = 0;
            AceptarButton.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            AceptarButton.FlatStyle = FlatStyle.Flat;
            AceptarButton.Location = new Point(182, 254);
            AceptarButton.Name = "AceptarButton";
            AceptarButton.Size = new Size(75, 23);
            AceptarButton.TabIndex = 26;
            AceptarButton.Text = "Aceptar";
            AceptarButton.UseVisualStyleBackColor = true;
            AceptarButton.Click += AceptarButton_Click;
            // 
            // clienteBindingSource
            // 
            clienteBindingSource.DataSource = typeof(Data.DTOs.ClienteDTO);
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Data.Modelo.Categoria);
            // 
            // TelefonoTextBox
            // 
            TelefonoTextBox.DataBindings.Add(new Binding("Text", clienteBindingSource, "Telefono", true));
            TelefonoTextBox.Location = new Point(182, 163);
            TelefonoTextBox.Name = "TelefonoTextBox";
            TelefonoTextBox.Size = new Size(156, 23);
            TelefonoTextBox.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(120, 166);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 23;
            label5.Text = "Teléfono:";
            // 
            // EmailTextBox
            // 
            EmailTextBox.DataBindings.Add(new Binding("Text", clienteBindingSource, "Email", true));
            EmailTextBox.Location = new Point(182, 134);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(156, 23);
            EmailTextBox.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(120, 137);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 21;
            label4.Text = "Email:";
            // 
            // DireccionTextBox
            // 
            DireccionTextBox.DataBindings.Add(new Binding("Text", clienteBindingSource, "Direccion", true));
            DireccionTextBox.Location = new Point(182, 105);
            DireccionTextBox.Name = "DireccionTextBox";
            DireccionTextBox.Size = new Size(156, 23);
            DireccionTextBox.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 108);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 19;
            label3.Text = "Dirección:";
            // 
            // NombreTextBox
            // 
            NombreTextBox.DataBindings.Add(new Binding("Text", clienteBindingSource, "Nombre", true));
            NombreTextBox.Location = new Point(182, 76);
            NombreTextBox.Name = "NombreTextBox";
            NombreTextBox.Size = new Size(156, 23);
            NombreTextBox.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 79);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 17;
            label2.Text = "Nombre:";
            // 
            // CategoriaCombobox
            // 
            CategoriaCombobox.DataBindings.Add(new Binding("SelectedValue", clienteBindingSource, "Categoria", true));
            CategoriaCombobox.DataBindings.Add(new Binding("Text", clienteBindingSource, "Categoria", true));
            CategoriaCombobox.DataSource = categoriaBindingSource;
            CategoriaCombobox.DisplayMember = "Nombre";
            CategoriaCombobox.FormattingEnabled = true;
            CategoriaCombobox.Location = new Point(182, 192);
            CategoriaCombobox.Name = "CategoriaCombobox";
            CategoriaCombobox.Size = new Size(157, 23);
            CategoriaCombobox.TabIndex = 29;
            CategoriaCombobox.ValueMember = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(182, 9);
            label1.Name = "label1";
            label1.Size = new Size(159, 30);
            label1.TabIndex = 30;
            label1.Text = "Insertar Cliente";
            // 
            // ClientesInsertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(527, 343);
            Controls.Add(label1);
            Controls.Add(CategoriaCombobox);
            Controls.Add(label6);
            Controls.Add(CancelarButton);
            Controls.Add(AceptarButton);
            Controls.Add(TelefonoTextBox);
            Controls.Add(label5);
            Controls.Add(EmailTextBox);
            Controls.Add(label4);
            Controls.Add(DireccionTextBox);
            Controls.Add(label3);
            Controls.Add(NombreTextBox);
            Controls.Add(label2);
            Name = "ClientesInsertForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientesInsertForm";
            Load += ClientesInsertForm_Load;
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Button CancelarButton;
        private Button AceptarButton;
        private TextBox TelefonoTextBox;
        private Label label5;
        private TextBox EmailTextBox;
        private Label label4;
        private TextBox DireccionTextBox;
        private Label label3;
        private TextBox NombreTextBox;
        private Label label2;
        private BindingSource clienteBindingSource;
        private BindingSource categoriaBindingSource;
        private ComboBox CategoriaCombobox;
        private Label label1;
    }
}