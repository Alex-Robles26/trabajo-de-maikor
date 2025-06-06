namespace _3
{
    partial class Form1
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
            dgvClientes = new DataGridView();
            btnDescuento = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            lblTotalConDescuento = new Label();
            txtMonto = new TextBox();
            cmbTipoCliente = new ComboBox();
            dtpFechaAlta = new DateTimePicker();
            txtTelefono = new TextBox();
            txtNombre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(450, 96);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(300, 188);
            dgvClientes.TabIndex = 21;
            dgvClientes.CellClick += dgvClientes_CellClick;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // btnDescuento
            // 
            btnDescuento.Location = new Point(569, 371);
            btnDescuento.Name = "btnDescuento";
            btnDescuento.Size = new Size(94, 29);
            btnDescuento.TabIndex = 20;
            btnDescuento.Text = "DESCUENTO";
            btnDescuento.UseVisualStyleBackColor = true;
            btnDescuento.Click += btnDescuento_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(662, 322);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "ELIMI";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(548, 322);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 18;
            btnEditar.Text = "EDI";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(422, 347);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 17;
            btnAgregar.Text = "AGRE";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblTotalConDescuento
            // 
            lblTotalConDescuento.AutoSize = true;
            lblTotalConDescuento.Location = new Point(12, 257);
            lblTotalConDescuento.Name = "lblTotalConDescuento";
            lblTotalConDescuento.Size = new Size(155, 20);
            lblTotalConDescuento.TabIndex = 16;
            lblTotalConDescuento.Text = "lblTotalConDescuento";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(201, 254);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(125, 27);
            txtMonto.TabIndex = 15;
            // 
            // cmbTipoCliente
            // 
            cmbTipoCliente.FormattingEnabled = true;
            cmbTipoCliente.Location = new Point(581, 50);
            cmbTipoCliente.Name = "cmbTipoCliente";
            cmbTipoCliente.Size = new Size(151, 28);
            cmbTipoCliente.TabIndex = 14;
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Location = new Point(101, 197);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(250, 27);
            dtpFechaAlta.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(113, 164);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 12;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(113, 111);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvClientes);
            Controls.Add(btnDescuento);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(lblTotalConDescuento);
            Controls.Add(txtMonto);
            Controls.Add(cmbTipoCliente);
            Controls.Add(dtpFechaAlta);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Button btnDescuento;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private Label lblTotalConDescuento;
        private TextBox txtMonto;
        private ComboBox cmbTipoCliente;
        private DateTimePicker dtpFechaAlta;
        private TextBox txtTelefono;
        private TextBox txtNombre;
    }
}
