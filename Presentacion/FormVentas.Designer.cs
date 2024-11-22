namespace Presentacion
{
    partial class FormVentas
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombreP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCodigoP = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.textBoxMontoPagado = new System.Windows.Forms.TextBox();
            this.buttonAgregarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarCl = new System.Windows.Forms.Button();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButtonEfectivo = new System.Windows.Forms.RadioButton();
            this.radioButtonDebito = new System.Windows.Forms.RadioButton();
            this.radioButtonCredito = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.labelMontoT = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.labelVuelto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Monto pagado";
            // 
            // textBoxNombreP
            // 
            this.textBoxNombreP.Location = new System.Drawing.Point(148, 200);
            this.textBoxNombreP.Multiline = true;
            this.textBoxNombreP.Name = "textBoxNombreP";
            this.textBoxNombreP.Size = new System.Drawing.Size(273, 30);
            this.textBoxNombreP.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Codigo Producto";
            // 
            // textBoxCodigoP
            // 
            this.textBoxCodigoP.Location = new System.Drawing.Point(148, 153);
            this.textBoxCodigoP.Multiline = true;
            this.textBoxCodigoP.Name = "textBoxCodigoP";
            this.textBoxCodigoP.Size = new System.Drawing.Size(273, 32);
            this.textBoxCodigoP.TabIndex = 9;
            this.textBoxCodigoP.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(29, 111);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(74, 16);
            this.Nombre.TabIndex = 8;
            this.Nombre.Text = "DNI Cliente";
            // 
            // textBoxMontoPagado
            // 
            this.textBoxMontoPagado.Location = new System.Drawing.Point(148, 373);
            this.textBoxMontoPagado.Multiline = true;
            this.textBoxMontoPagado.Name = "textBoxMontoPagado";
            this.textBoxMontoPagado.Size = new System.Drawing.Size(121, 30);
            this.textBoxMontoPagado.TabIndex = 7;
            this.textBoxMontoPagado.TextChanged += new System.EventHandler(this.textBoxMontoPagado_TextChanged);
            // 
            // buttonAgregarVenta
            // 
            this.buttonAgregarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.buttonAgregarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.buttonAgregarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarVenta.Location = new System.Drawing.Point(32, 472);
            this.buttonAgregarVenta.Name = "buttonAgregarVenta";
            this.buttonAgregarVenta.Size = new System.Drawing.Size(317, 52);
            this.buttonAgregarVenta.TabIndex = 14;
            this.buttonAgregarVenta.Text = "Agregar Venta";
            this.buttonAgregarVenta.UseVisualStyleBackColor = false;
            this.buttonAgregarVenta.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "VENTA NUEVA";
            // 
            // btnAgregarCl
            // 
            this.btnAgregarCl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.btnAgregarCl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnAgregarCl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCl.Location = new System.Drawing.Point(554, 153);
            this.btnAgregarCl.Name = "btnAgregarCl";
            this.btnAgregarCl.Size = new System.Drawing.Size(120, 77);
            this.btnAgregarCl.TabIndex = 15;
            this.btnAgregarCl.Text = "Agregar a la venta";
            this.btnAgregarCl.UseVisualStyleBackColor = false;
            this.btnAgregarCl.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(148, 104);
            this.textBoxDNI.Multiline = true;
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(273, 28);
            this.textBoxDNI.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Monto Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Vuelto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Nombre Producto";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(330, 246);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(539, 202);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Medio de Pago";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(554, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 48);
            this.button3.TabIndex = 22;
            this.button3.Text = "Registrar Cliente Nuevo";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(432, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 48);
            this.button4.TabIndex = 23;
            this.button4.Text = "Buscar Cliente";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(383, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 52);
            this.button2.TabIndex = 24;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // radioButtonEfectivo
            // 
            this.radioButtonEfectivo.AutoSize = true;
            this.radioButtonEfectivo.Location = new System.Drawing.Point(148, 250);
            this.radioButtonEfectivo.Name = "radioButtonEfectivo";
            this.radioButtonEfectivo.Size = new System.Drawing.Size(76, 20);
            this.radioButtonEfectivo.TabIndex = 26;
            this.radioButtonEfectivo.TabStop = true;
            this.radioButtonEfectivo.Text = "Efectivo";
            this.radioButtonEfectivo.UseVisualStyleBackColor = true;
            this.radioButtonEfectivo.CheckedChanged += new System.EventHandler(this.radioButtonEfectivo_CheckedChanged);
            // 
            // radioButtonDebito
            // 
            this.radioButtonDebito.AutoSize = true;
            this.radioButtonDebito.Location = new System.Drawing.Point(148, 272);
            this.radioButtonDebito.Name = "radioButtonDebito";
            this.radioButtonDebito.Size = new System.Drawing.Size(68, 20);
            this.radioButtonDebito.TabIndex = 27;
            this.radioButtonDebito.TabStop = true;
            this.radioButtonDebito.Text = "Debito";
            this.radioButtonDebito.UseVisualStyleBackColor = true;
            // 
            // radioButtonCredito
            // 
            this.radioButtonCredito.AutoSize = true;
            this.radioButtonCredito.Location = new System.Drawing.Point(148, 294);
            this.radioButtonCredito.Name = "radioButtonCredito";
            this.radioButtonCredito.Size = new System.Drawing.Size(71, 20);
            this.radioButtonCredito.TabIndex = 28;
            this.radioButtonCredito.TabStop = true;
            this.radioButtonCredito.Text = "Credito";
            this.radioButtonCredito.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(432, 153);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 77);
            this.button5.TabIndex = 29;
            this.button5.Text = "Buscar Producto";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // labelMontoT
            // 
            this.labelMontoT.AutoSize = true;
            this.labelMontoT.Location = new System.Drawing.Point(145, 337);
            this.labelMontoT.Name = "labelMontoT";
            this.labelMontoT.Size = new System.Drawing.Size(0, 16);
            this.labelMontoT.TabIndex = 30;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Location = new System.Drawing.Point(147, 335);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(56, 16);
            this.lblMontoTotal.TabIndex = 31;
            this.lblMontoTotal.Text = "0 Pesos";
            // 
            // labelVuelto
            // 
            this.labelVuelto.AutoSize = true;
            this.labelVuelto.Location = new System.Drawing.Point(147, 423);
            this.labelVuelto.Name = "labelVuelto";
            this.labelVuelto.Size = new System.Drawing.Size(56, 16);
            this.labelVuelto.TabIndex = 32;
            this.labelVuelto.Text = "0 Pesos";
            this.labelVuelto.Click += new System.EventHandler(this.labelVuelto_Click);
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(969, 565);
            this.Controls.Add(this.labelVuelto);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.labelMontoT);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.radioButtonCredito);
            this.Controls.Add(this.radioButtonDebito);
            this.Controls.Add(this.radioButtonEfectivo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.btnAgregarCl);
            this.Controls.Add(this.buttonAgregarVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNombreP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCodigoP);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.textBoxMontoPagado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVentas";
            this.Text = "formVentas";
            this.Load += new System.EventHandler(this.formVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombreP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCodigoP;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.TextBox textBoxMontoPagado;
        private System.Windows.Forms.Button buttonAgregarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarCl;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButtonEfectivo;
        private System.Windows.Forms.RadioButton radioButtonDebito;
        private System.Windows.Forms.RadioButton radioButtonCredito;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labelMontoT;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label labelVuelto;
    }
}