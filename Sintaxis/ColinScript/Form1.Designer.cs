﻿namespace ColinScript
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richtxt_token = new System.Windows.Forms.RichTextBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.dgvErroresLexicos = new System.Windows.Forms.DataGridView();
            this.cLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ejecutar = new System.Windows.Forms.Button();
            this.lblErrores = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrgPrograma = new System.Windows.Forms.Button();
            this.btnGrdTokens = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLineasCod = new System.Windows.Forms.TextBox();
            this.txtLineasToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTablaSimbolos = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Validar = new System.Windows.Forms.Button();
            this.btnGuardarSimbolos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richtxtBottomUp = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErroresLexicos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaSimbolos)).BeginInit();
            this.SuspendLayout();
            // 
            // richtxt_token
            // 
            this.richtxt_token.BackColor = System.Drawing.Color.Cornsilk;
            this.richtxt_token.Enabled = false;
            this.richtxt_token.Location = new System.Drawing.Point(379, 68);
            this.richtxt_token.Name = "richtxt_token";
            this.richtxt_token.Size = new System.Drawing.Size(469, 374);
            this.richtxt_token.TabIndex = 0;
            this.richtxt_token.Text = "";
            // 
            // txt_codigo
            // 
            this.txt_codigo.BackColor = System.Drawing.Color.Cornsilk;
            this.txt_codigo.Location = new System.Drawing.Point(35, 68);
            this.txt_codigo.Multiline = true;
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(241, 374);
            this.txt_codigo.TabIndex = 1;
            this.txt_codigo.TextChanged += new System.EventHandler(this.txt_codigo_TextChanged);
            // 
            // dgvErroresLexicos
            // 
            this.dgvErroresLexicos.AllowUserToOrderColumns = true;
            this.dgvErroresLexicos.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvErroresLexicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cLinea,
            this.cError});
            this.dgvErroresLexicos.Location = new System.Drawing.Point(12, 497);
            this.dgvErroresLexicos.Name = "dgvErroresLexicos";
            this.dgvErroresLexicos.Size = new System.Drawing.Size(401, 145);
            this.dgvErroresLexicos.TabIndex = 2;
            // 
            // cLinea
            // 
            this.cLinea.HeaderText = "Linea";
            this.cLinea.Name = "cLinea";
            // 
            // cError
            // 
            this.cError.HeaderText = "Error";
            this.cError.Name = "cError";
            this.cError.Width = 350;
            // 
            // btn_ejecutar
            // 
            this.btn_ejecutar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_ejecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ejecutar.FlatAppearance.BorderSize = 0;
            this.btn_ejecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ejecutar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ejecutar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ejecutar.Location = new System.Drawing.Point(704, 0);
            this.btn_ejecutar.Name = "btn_ejecutar";
            this.btn_ejecutar.Size = new System.Drawing.Size(161, 53);
            this.btn_ejecutar.TabIndex = 8;
            this.btn_ejecutar.Text = "EJECUTAR";
            this.btn_ejecutar.UseVisualStyleBackColor = false;
            this.btn_ejecutar.Click += new System.EventHandler(this.btn_ejecutar_Click);
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.BackColor = System.Drawing.Color.Transparent;
            this.lblErrores.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrores.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblErrores.Location = new System.Drawing.Point(14, 460);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(93, 22);
            this.lblErrores.TabIndex = 10;
            this.lblErrores.Text = "Errores: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.btn_ejecutar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCrgPrograma);
            this.panel2.Controls.Add(this.btnGrdTokens);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1377, 53);
            this.panel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "ColinScript";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCrgPrograma
            // 
            this.btnCrgPrograma.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCrgPrograma.FlatAppearance.BorderSize = 0;
            this.btnCrgPrograma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrgPrograma.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrgPrograma.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCrgPrograma.Location = new System.Drawing.Point(193, 0);
            this.btnCrgPrograma.Margin = new System.Windows.Forms.Padding(0);
            this.btnCrgPrograma.Name = "btnCrgPrograma";
            this.btnCrgPrograma.Size = new System.Drawing.Size(107, 53);
            this.btnCrgPrograma.TabIndex = 12;
            this.btnCrgPrograma.Text = "Cargar programa\r\n";
            this.btnCrgPrograma.UseVisualStyleBackColor = false;
            this.btnCrgPrograma.Click += new System.EventHandler(this.btnCrgPrograma_Click_1);
            // 
            // btnGrdTokens
            // 
            this.btnGrdTokens.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGrdTokens.FlatAppearance.BorderSize = 0;
            this.btnGrdTokens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrdTokens.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrdTokens.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnGrdTokens.Location = new System.Drawing.Point(419, 0);
            this.btnGrdTokens.Margin = new System.Windows.Forms.Padding(0);
            this.btnGrdTokens.Name = "btnGrdTokens";
            this.btnGrdTokens.Size = new System.Drawing.Size(107, 53);
            this.btnGrdTokens.TabIndex = 14;
            this.btnGrdTokens.Text = "Guardar tokens";
            this.btnGrdTokens.UseVisualStyleBackColor = false;
            this.btnGrdTokens.Click += new System.EventHandler(this.btnGrdTokens_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(306, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 53);
            this.button1.TabIndex = 13;
            this.button1.Text = "Guardar programa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ColinScript.Properties.Resources.d6588d2a_0058_4e4e_8f3b_1f28b31swadwd3459a;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(523, -44);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 122);
            this.panel1.TabIndex = 15;
            // 
            // txtLineasCod
            // 
            this.txtLineasCod.Enabled = false;
            this.txtLineasCod.Location = new System.Drawing.Point(12, 68);
            this.txtLineasCod.Multiline = true;
            this.txtLineasCod.Name = "txtLineasCod";
            this.txtLineasCod.Size = new System.Drawing.Size(24, 374);
            this.txtLineasCod.TabIndex = 15;
            // 
            // txtLineasToken
            // 
            this.txtLineasToken.Enabled = false;
            this.txtLineasToken.Location = new System.Drawing.Point(356, 68);
            this.txtLineasToken.Multiline = true;
            this.txtLineasToken.Name = "txtLineasToken";
            this.txtLineasToken.Size = new System.Drawing.Size(24, 374);
            this.txtLineasToken.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(513, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tabla de símbolos:";
            // 
            // dgvTablaSimbolos
            // 
            this.dgvTablaSimbolos.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvTablaSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.cNombre,
            this.cTipoDato});
            this.dgvTablaSimbolos.Location = new System.Drawing.Point(419, 497);
            this.dgvTablaSimbolos.Name = "dgvTablaSimbolos";
            this.dgvTablaSimbolos.Size = new System.Drawing.Size(429, 145);
            this.dgvTablaSimbolos.TabIndex = 3;
            // 
            // Num
            // 
            this.Num.HeaderText = "Num";
            this.Num.Name = "Num";
            this.Num.Width = 120;
            // 
            // cNombre
            // 
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.Width = 160;
            // 
            // cTipoDato
            // 
            this.cTipoDato.HeaderText = "Tipo de dato";
            this.cTipoDato.Name = "cTipoDato";
            // 
            // btn_Validar
            // 
            this.btn_Validar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Validar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Validar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Validar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_Validar.Location = new System.Drawing.Point(1044, 545);
            this.btn_Validar.Name = "btn_Validar";
            this.btn_Validar.Size = new System.Drawing.Size(164, 58);
            this.btn_Validar.TabIndex = 18;
            this.btn_Validar.Text = "Validar";
            this.btn_Validar.UseVisualStyleBackColor = false;
            this.btn_Validar.Click += new System.EventHandler(this.btn_Validar_Click);
            // 
            // btnGuardarSimbolos
            // 
            this.btnGuardarSimbolos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGuardarSimbolos.FlatAppearance.BorderSize = 0;
            this.btnGuardarSimbolos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSimbolos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarSimbolos.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnGuardarSimbolos.Location = new System.Drawing.Point(730, 441);
            this.btnGuardarSimbolos.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardarSimbolos.Name = "btnGuardarSimbolos";
            this.btnGuardarSimbolos.Size = new System.Drawing.Size(107, 53);
            this.btnGuardarSimbolos.TabIndex = 19;
            this.btnGuardarSimbolos.Text = "Guardar simbolos";
            this.btnGuardarSimbolos.UseVisualStyleBackColor = false;
            this.btnGuardarSimbolos.Click += new System.EventHandler(this.btnGuardarSimbolos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1005, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 50);
            this.label3.TabIndex = 21;
            this.label3.Text = "Analizador Sintactico\r\n(Bottom-Up)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richtxtBottomUp
            // 
            this.richtxtBottomUp.BackColor = System.Drawing.Color.Cornsilk;
            this.richtxtBottomUp.Location = new System.Drawing.Point(866, 174);
            this.richtxtBottomUp.Name = "richtxtBottomUp";
            this.richtxtBottomUp.Size = new System.Drawing.Size(497, 320);
            this.richtxtBottomUp.TabIndex = 22;
            this.richtxtBottomUp.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1375, 654);
            this.Controls.Add(this.richtxtBottomUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardarSimbolos);
            this.Controls.Add(this.btn_Validar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLineasToken);
            this.Controls.Add(this.txtLineasCod);
            this.Controls.Add(this.lblErrores);
            this.Controls.Add(this.dgvTablaSimbolos);
            this.Controls.Add(this.dgvErroresLexicos);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.richtxt_token);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ColinScript";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErroresLexicos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaSimbolos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richtxt_token;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.DataGridView dgvErroresLexicos;
        private System.Windows.Forms.Button btn_ejecutar;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrgPrograma;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGrdTokens;
        private System.Windows.Forms.TextBox txtLineasCod;
        private System.Windows.Forms.TextBox txtLineasToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTablaSimbolos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Validar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDato;
        private System.Windows.Forms.Button btnGuardarSimbolos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richtxtBottomUp;
    }
}

