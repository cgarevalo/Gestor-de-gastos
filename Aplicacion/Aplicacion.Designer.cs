namespace Aplicacion
{
    partial class Aplicacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.nunMonto = new System.Windows.Forms.NumericUpDown();
            this.dgvRegistroDatos = new System.Windows.Forms.DataGridView();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreRegistro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.nunTotalGastado = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDescargarRegistroPDF = new System.Windows.Forms.Button();
            this.btnTodosRegistros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nunMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nunTotalGastado)).BeginInit();
            this.SuspendLayout();
            // 
            // nunMonto
            // 
            this.nunMonto.Location = new System.Drawing.Point(332, 313);
            this.nunMonto.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nunMonto.Name = "nunMonto";
            this.nunMonto.Size = new System.Drawing.Size(120, 20);
            this.nunMonto.TabIndex = 0;
            this.nunMonto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvRegistroDatos
            // 
            this.dgvRegistroDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroDatos.Location = new System.Drawing.Point(12, 12);
            this.dgvRegistroDatos.MultiSelect = false;
            this.dgvRegistroDatos.Name = "dgvRegistroDatos";
            this.dgvRegistroDatos.ReadOnly = true;
            this.dgvRegistroDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistroDatos.Size = new System.Drawing.Size(440, 263);
            this.dgvRegistroDatos.TabIndex = 0;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(12, 313);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(121, 21);
            this.cboCategoria.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Categoría:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Monto:";
            // 
            // txtNombreRegistro
            // 
            this.txtNombreRegistro.Location = new System.Drawing.Point(183, 314);
            this.txtNombreRegistro.Name = "txtNombreRegistro";
            this.txtNombreRegistro.Size = new System.Drawing.Size(100, 20);
            this.txtNombreRegistro.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre del registro:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(458, 304);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(170, 36);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(458, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(222, 38);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // nunTotalGastado
            // 
            this.nunTotalGastado.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nunTotalGastado.Location = new System.Drawing.Point(458, 208);
            this.nunTotalGastado.Name = "nunTotalGastado";
            this.nunTotalGastado.ReadOnly = true;
            this.nunTotalGastado.Size = new System.Drawing.Size(222, 20);
            this.nunTotalGastado.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total gastado:";
            // 
            // btnDescargarRegistroPDF
            // 
            this.btnDescargarRegistroPDF.Location = new System.Drawing.Point(458, 56);
            this.btnDescargarRegistroPDF.Name = "btnDescargarRegistroPDF";
            this.btnDescargarRegistroPDF.Size = new System.Drawing.Size(222, 38);
            this.btnDescargarRegistroPDF.TabIndex = 13;
            this.btnDescargarRegistroPDF.Text = "Descargar PDF del registro";
            this.btnDescargarRegistroPDF.UseVisualStyleBackColor = true;
            this.btnDescargarRegistroPDF.Click += new System.EventHandler(this.btnDescargarRegistroPDF_Click);
            // 
            // btnTodosRegistros
            // 
            this.btnTodosRegistros.Location = new System.Drawing.Point(458, 100);
            this.btnTodosRegistros.Name = "btnTodosRegistros";
            this.btnTodosRegistros.Size = new System.Drawing.Size(222, 38);
            this.btnTodosRegistros.TabIndex = 14;
            this.btnTodosRegistros.Text = "Descargar todos los registros";
            this.btnTodosRegistros.UseVisualStyleBackColor = true;
            this.btnTodosRegistros.Click += new System.EventHandler(this.btnTodosRegistros_Click);
            // 
            // Aplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 346);
            this.Controls.Add(this.btnTodosRegistros);
            this.Controls.Add(this.btnDescargarRegistroPDF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nunTotalGastado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreRegistro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.dgvRegistroDatos);
            this.Controls.Add(this.nunMonto);
            this.MaximizeBox = false;
            this.Name = "Aplicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gastos";
            this.Load += new System.EventHandler(this.Aplicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nunMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nunTotalGastado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nunMonto;
        private System.Windows.Forms.DataGridView dgvRegistroDatos;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreRegistro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.NumericUpDown nunTotalGastado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDescargarRegistroPDF;
        private System.Windows.Forms.Button btnTodosRegistros;
    }
}

