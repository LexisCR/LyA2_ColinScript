namespace ColinScript
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvErroresSemanticos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnValidarSemantico = new System.Windows.Forms.Button();
            this.richtxtJELU = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPrefijo = new System.Windows.Forms.DataGridView();
            this.dgvTripleta = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCodigoIntermedio = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErroresLexicos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaSimbolos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErroresSemanticos)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrefijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripleta)).BeginInit();
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
            this.cLinea.Width = 50;
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
            this.Num.Width = 50;
            // 
            // cNombre
            // 
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.Width = 200;
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
            this.btn_Validar.Location = new System.Drawing.Point(174, 471);
            this.btn_Validar.Name = "btn_Validar";
            this.btn_Validar.Size = new System.Drawing.Size(164, 58);
            this.btn_Validar.TabIndex = 18;
            this.btn_Validar.Text = "Validar Sintactico";
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
            this.label3.Location = new System.Drawing.Point(143, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 50);
            this.label3.TabIndex = 21;
            this.label3.Text = "Analizador Sintactico\r\n(Bottom-Up)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richtxtBottomUp
            // 
            this.richtxtBottomUp.BackColor = System.Drawing.Color.Cornsilk;
            this.richtxtBottomUp.Location = new System.Drawing.Point(6, 72);
            this.richtxtBottomUp.Name = "richtxtBottomUp";
            this.richtxtBottomUp.Size = new System.Drawing.Size(505, 383);
            this.richtxtBottomUp.TabIndex = 22;
            this.richtxtBottomUp.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(854, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(523, 574);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage1.Controls.Add(this.richtxtBottomUp);
            this.tabPage1.Controls.Add(this.btn_Validar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(515, 548);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sintactico";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage2.Controls.Add(this.dgvErroresSemanticos);
            this.tabPage2.Controls.Add(this.btnValidarSemantico);
            this.tabPage2.Controls.Add(this.richtxtJELU);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(515, 548);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Semantico";
            // 
            // dgvErroresSemanticos
            // 
            this.dgvErroresSemanticos.AllowUserToOrderColumns = true;
            this.dgvErroresSemanticos.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvErroresSemanticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvErroresSemanticos.Location = new System.Drawing.Point(9, 394);
            this.dgvErroresSemanticos.Name = "dgvErroresSemanticos";
            this.dgvErroresSemanticos.Size = new System.Drawing.Size(369, 135);
            this.dgvErroresSemanticos.TabIndex = 26;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Linea";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Error";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // btnValidarSemantico
            // 
            this.btnValidarSemantico.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnValidarSemantico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidarSemantico.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarSemantico.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnValidarSemantico.Location = new System.Drawing.Point(397, 430);
            this.btnValidarSemantico.Name = "btnValidarSemantico";
            this.btnValidarSemantico.Size = new System.Drawing.Size(103, 58);
            this.btnValidarSemantico.TabIndex = 23;
            this.btnValidarSemantico.Text = "Validar Semantico";
            this.btnValidarSemantico.UseVisualStyleBackColor = false;
            this.btnValidarSemantico.Click += new System.EventHandler(this.btnValidarSemantico_Click);
            // 
            // richtxtJELU
            // 
            this.richtxtJELU.BackColor = System.Drawing.Color.Cornsilk;
            this.richtxtJELU.Location = new System.Drawing.Point(9, 68);
            this.richtxtJELU.Name = "richtxtJELU";
            this.richtxtJELU.Size = new System.Drawing.Size(491, 320);
            this.richtxtJELU.TabIndex = 25;
            this.richtxtJELU.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 50);
            this.label4.TabIndex = 24;
            this.label4.Text = "Analizador Semantico\r\n(Metodo JELU)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage3.Controls.Add(this.btnCodigoIntermedio);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.dgvPrefijo);
            this.tabPage3.Controls.Add(this.dgvTripleta);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(515, 548);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Codigo Intermedio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(206, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "Tripletas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Expresiones Aritmeticas (Prefija)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPrefijo
            // 
            this.dgvPrefijo.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvPrefijo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrefijo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvPrefijo.Location = new System.Drawing.Point(3, 64);
            this.dgvPrefijo.Name = "dgvPrefijo";
            this.dgvPrefijo.Size = new System.Drawing.Size(509, 167);
            this.dgvPrefijo.TabIndex = 5;
            // 
            // dgvTripleta
            // 
            this.dgvTripleta.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvTripleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripleta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvTripleta.Location = new System.Drawing.Point(86, 284);
            this.dgvTripleta.Name = "dgvTripleta";
            this.dgvTripleta.Size = new System.Drawing.Size(345, 167);
            this.dgvTripleta.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Dato Objeto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Dato Fuente";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Operador";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // btnCodigoIntermedio
            // 
            this.btnCodigoIntermedio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCodigoIntermedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCodigoIntermedio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodigoIntermedio.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCodigoIntermedio.Location = new System.Drawing.Point(190, 468);
            this.btnCodigoIntermedio.Name = "btnCodigoIntermedio";
            this.btnCodigoIntermedio.Size = new System.Drawing.Size(141, 58);
            this.btnCodigoIntermedio.TabIndex = 27;
            this.btnCodigoIntermedio.Text = "Generar Codigo Intermedio";
            this.btnCodigoIntermedio.UseVisualStyleBackColor = false;
            this.btnCodigoIntermedio.Click += new System.EventHandler(this.btnCodigoIntermedio_Click);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Expresion Original";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 240;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Expresion PreFija";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 240;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1370, 654);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGuardarSimbolos);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErroresSemanticos)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrefijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripleta)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTablaSimbolos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Validar;
        private System.Windows.Forms.Button btnGuardarSimbolos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richtxtBottomUp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richtxtJELU;
        private System.Windows.Forms.Button btnValidarSemantico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvErroresSemanticos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cError;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDato;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvTripleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView dgvPrefijo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCodigoIntermedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}

