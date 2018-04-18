namespace MiCalculadora
{
    partial class LaCalculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaCalculadora));
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnBinario = new System.Windows.Forms.Button();
            this.btnDecimal = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.text_Numero1 = new System.Windows.Forms.TextBox();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.text_Numero2 = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(21, 83);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(132, 45);
            this.btnOperar.TabIndex = 0;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_click);
            // 
            // btnBinario
            // 
            this.btnBinario.Location = new System.Drawing.Point(21, 150);
            this.btnBinario.Name = "btnBinario";
            this.btnBinario.Size = new System.Drawing.Size(204, 46);
            this.btnBinario.TabIndex = 3;
            this.btnBinario.Text = "Convertir a Binario";
            this.btnBinario.UseVisualStyleBackColor = true;
            this.btnBinario.Click += new System.EventHandler(this.btnConvertirABinario_Click);
            // 
            // btnDecimal
            // 
            this.btnDecimal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDecimal.Location = new System.Drawing.Point(231, 150);
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.Size = new System.Drawing.Size(195, 46);
            this.btnDecimal.TabIndex = 4;
            this.btnDecimal.Text = "Convertir a Decimal";
            this.btnDecimal.UseVisualStyleBackColor = true;
            this.btnDecimal.Click += new System.EventHandler(this.btnConvertirADecimal_click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(159, 83);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(139, 45);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(304, 83);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(122, 45);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_click);
            // 
            // text_Numero1
            // 
            this.text_Numero1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.text_Numero1.Font = new System.Drawing.Font("Arial Narrow", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Numero1.Location = new System.Drawing.Point(21, 42);
            this.text_Numero1.Name = "text_Numero1";
            this.text_Numero1.Size = new System.Drawing.Size(97, 35);
            this.text_Numero1.TabIndex = 7;
            // 
            // cmbOperador
            // 
            this.cmbOperador.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold);
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cmbOperador.Location = new System.Drawing.Point(172, 40);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(105, 37);
            this.cmbOperador.TabIndex = 9;
            this.cmbOperador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_keypress);
            // 
            // text_Numero2
            // 
            this.text_Numero2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold);
            this.text_Numero2.Location = new System.Drawing.Point(321, 42);
            this.text_Numero2.Name = "text_Numero2";
            this.text_Numero2.Size = new System.Drawing.Size(105, 35);
            this.text_Numero2.TabIndex = 10;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(379, 6);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 33);
            this.lblResultado.TabIndex = 11;
            // 
            // LaCalculadora
            // 
            this.AcceptButton = this.btnOperar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCerrar;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.text_Numero2);
            this.Controls.Add(this.cmbOperador);
            this.Controls.Add(this.text_Numero1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnDecimal);
            this.Controls.Add(this.btnBinario);
            this.Controls.Add(this.btnOperar);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LaCalculadora";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Julian Graziano 2°D";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnBinario;
        private System.Windows.Forms.Button btnDecimal;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox text_Numero1;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.TextBox text_Numero2;
        private System.Windows.Forms.Label lblResultado;
    }
}

