using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;
using System.Diagnostics;

//roslyn
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using static System.Windows.Forms.LinkLabel;

namespace ColinScript
{
    public partial class Form1 : Form
    {
        List<string> nombre = new List<string>();
        List<int> numero = new List<int>();
        List<string> tipodato = new List<string>();
        List<string> idensindeclarar = new List<string>();
        SqlConnection miConexion = new SqlConnection("server=ALEX;database=Automatas2; integrated security=true");
        public static string[] matrizaracteres = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", "/", "*", "&", "|", "!", "=", ">", "<", "(", ")", "[", "]", "{", "}", ":", ";", "'", "^", "#", "$", ".", "_" };

        string mostrar = "";
        string tokens = "";
        bool comentario = true;
        int linea = 1;
        int numiden = 0;
        string nomiden = "";
        bool iden = false;
        int _intLinea = 0;
        bool _blnTipoDato = false;
        string simbolos = "";

        public Form1()
        {
            InitializeComponent();
            txtLineasCod.Text = "1";
            txtLineasToken.Text = "1";
        }

        private void btn_ejecutar_Click(object sender, EventArgs e)
        {
            mostrar = "";
            comentario = true;
            linea = 1;
            dgvErroresLexicos.Rows.Clear();
            dgvTablaSimbolos.Rows.Clear();
            iden = false;
            nomiden = "";
            _blnTipoDato = false;

            //TABLA DE SIMBOLOS
            numero.Clear();
            nombre.Clear();
            numiden = 0;
            tipodato.Clear();

            idensindeclarar.Clear();


            foreach (char letra in txt_codigo.Text)
            {
                // if para consultar las palabras, r es para cuando haya un salto de linea y volver al inicio de la linea, validar comentarios no va a consultar nada solo muestra token
                if (letra == '\r' || letra == ' ' && comentario)
                {
                    ConsultarBD(87, false);
                    mostrar += ConsultarBD(88, true);
                    richtxt_token.Text = mostrar;
                    mostrar += " ";
                    iden = false;
                    nomiden = "";
                }
                else if (letra == '\n')
                {
                    mostrar += "\n";
                    comentario = true;
                    linea++;
                }
                else if (comentario)
                {
                    if (CalcularNumeroColumna(letra) != -1)
                    {

                        ConsultarBD(CalcularNumeroColumna(letra), false);
                        if (letra == '#')
                        {
                            comentario = false;
                        }

                        if (letra == '$')
                        {
                            comentario = false;
                            ConsultarBD(CalcularNumeroColumna('$'), false);
                        }

                        if (letra == '_' || iden)
                        {
                            iden = true;
                            nomiden += letra;
                        }
                    }
                }
            }
            ConsultarBD(87, false);
            mostrar += ConsultarBD(88, true);
            richtxt_token.Text = mostrar;
            
            lblErrores.Text = "Errores: " + (dgvErroresLexicos.Rows.Count - 1).ToString();

            for (int i = 0; i < numero.Count; i++)
            {
                dgvTablaSimbolos.Rows.Add(numero[i], nombre[i], tipodato[i]);
            }

            // Itera sobre cada coincidencia de la palabra "errores" en el texto.
            foreach (Match match in Regex.Matches(richtxt_token.Text, @"\bError\b", RegexOptions.IgnoreCase))
            {
                // Cambia el color de la palabra "errores" a rojo.
                richtxt_token.Select(match.Index, match.Length);
                richtxt_token.SelectionColor = Color.Red;
            }

            // Restaura el color predeterminado del texto.
            richtxt_token.Select(0, 0);
            richtxt_token.SelectionColor = richtxt_token.ForeColor;
        }
        string estado = "";
        int fila = 0;

        

        public string ConsultarBD(int posicionColumna, bool FDC)
        {
            SqlConnection miConexion = new SqlConnection("server=ALEX;database=Automatas2; integrated security=true");
            miConexion.Open();

            //selecciona la columna en base a la posicion de la letra, en la donde la columna 1 sea igual a la fila (iniciando en 1)
            SqlCommand miComando = new SqlCommand("SELECT column" + (posicionColumna + 1) + " FROM Matriz WHERE column1 = " + fila, miConexion);
            //ejecuta el query
            SqlDataReader miLector = miComando.ExecuteReader();
            //hace lectura del resultado del query
            miLector.Read();
            //valida si es un fin de cadena
            if (!FDC)
            {
                //si no, guarda el numero de la fila para el estado a mover
                fila = int.Parse(miLector[0].ToString());

            }
            else
            {
                //si es un FDC, no convierte a entero y da el string como "error" o asi
                estado = miLector[0].ToString();

                //ERRORES
                if (estado.Substring(0, 3) == "ERR")
                {
                    MostrarError(ref estado);
                    estado = "Error";
                }
                fila = 0;

                //TIPO DE DATO
                switch (estado)
                {
                    case "PARE02":
                        tipodato.Add("bool");
                        _blnTipoDato = true;
                        break;

                    case "PARE07":
                        tipodato.Add("dec");
                        _blnTipoDato = true;
                        break;

                    case "PARE14":
                        tipodato.Add("int");
                        _blnTipoDato = true;
                        break;

                    case "PARE18":
                        tipodato.Add("string");
                        _blnTipoDato = true;
                        break;
                }

                //IDENTIFICADORES
                if (estado == "IDEN" && _blnTipoDato)
                {
                    MostrarSimbolos(nomiden);
                    estado = "IDEN" + numiden;
                    _blnTipoDato = false;
                }
                else if (estado == "IDEN")
                {
                    for (int i = 0; i < nombre.Count; i++)
                    {
                        if (nomiden == nombre[i]) { estado = "IDEN" + numero[i]; }
                    }
                    if (estado == "IDEN") { idensindeclarar.Add(nomiden); }
                }
            }

            //cierra la conec
            miLector.Close();
            miConexion.Close();
            return estado;
        }

        public void MostrarError(ref string _strError)
        {
            switch (_strError)
            {
                case "ERR_PARE":
                    dgvErroresLexicos.Rows.Add(linea, "Palabra reservada no valida");
                    break;

                case "ERR_IDEN":
                    dgvErroresLexicos.Rows.Add(linea, "Identificador no valido");
                    break;

                case "ERR_OPA":
                    dgvErroresLexicos.Rows.Add(linea, "Operador aritmetico no valido");
                    break;

                case "ERR_OPL":
                    dgvErroresLexicos.Rows.Add(linea, "Operador logico no valido");
                    break;

                case "ERR_OPR":
                    dgvErroresLexicos.Rows.Add(linea, "Operador relacional no valido");
                    break;

                case "ERR_CAE":
                    dgvErroresLexicos.Rows.Add(linea, "Error de caracter especial");
                    break;

                case "ERR_CAD":
                    dgvErroresLexicos.Rows.Add(linea, "Error de cadena");
                    break;

                case "ERR_CNX":
                    dgvErroresLexicos.Rows.Add(linea, "Error Exponencial");
                    break;
                case "ERR_CNE":
                    dgvErroresLexicos.Rows.Add(linea, "Error de Constante Entera");
                    break;
                case "ERR_CNR":
                    dgvErroresLexicos.Rows.Add(linea, "Error de Constante Real");
                    break;
            }
        }

        public void MostrarSimbolos(string _strToken)
        {
            bool repetido = false;
            for (int i = 0; i < numero.Count; i++)
            {
                if (_strToken == nombre[i])
                {
                    repetido = true;
                    numiden = numero[i];
                }

            }
            if (!repetido)
            {
                numiden++;
                numero.Add(numiden);
                nombre.Add(_strToken);
            }
        }

        public int CalcularNumeroColumna(char _cCaracter)
        {
            for (int i = 0; i < matrizaracteres.Length; i++)
            {
                if (matrizaracteres[i] == _cCaracter.ToString())
                {
                    return (i + 1);
                }
            }
            return -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void btnGdrArchivo_Click(object sender, EventArgs e)
        {
            Guardar(richtxt_token.Text);
        }

        public void Guardar(string _strTexto)
        {
            // Abre un cuadro de diálogo para seleccionar la ubicación y el nombre del archivo
            SaveFileDialog miArchivoGuardado = new SaveFileDialog();
            miArchivoGuardado.Filter = "Archivos de texto (*.txt)|*.txt";
            miArchivoGuardado.FilterIndex = 1;

            if (miArchivoGuardado.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Guarda el contenido del TextBox en el archivo seleccionado
                    File.WriteAllText(miArchivoGuardado.FileName, _strTexto);
                    MessageBox.Show("El archivo se ha guardado correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar el archivo: " + ex.Message);
                }
            }
        }

        private void btnGdrPrograma_Click(object sender, EventArgs e)
        {
            Guardar(txt_codigo.Text);
        }

        private void btnCrgPrograma_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog miArchivoTxt = new OpenFileDialog();
            miArchivoTxt.Filter = "Archivos de texto (*.txt)|*.txt";
            miArchivoTxt.FilterIndex = 1;

            if (miArchivoTxt.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lee el contenido del archivo seleccionado
                    string _strArchivoTxt = File.ReadAllText(miArchivoTxt.FileName);

                    // Ingresa el contenido en el TextBox
                    txt_codigo.Text = _strArchivoTxt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al leer el archivo: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar(txt_codigo.Text);
        }

        private void btnGrdTokens_Click(object sender, EventArgs e)
        {
            Guardar(richtxt_token.Text);
        }

        private void txt_codigo_TextChanged(object sender, EventArgs e)
        {
            _intLinea = 1;
            txtLineasCod.Text = "";
            txtLineasToken.Text = "";

            foreach (char otraLetra in txt_codigo.Text)
            {
                if (otraLetra == '\n')
                {
                    _intLinea++;
                }
            }

            for (int i = 0; i < _intLinea; i++)
            {
                txtLineasCod.Text += (i + 1) + "\r\n";
                txtLineasToken.Text += (i + 1) + "\r\n";
            }
        }

        bool _blnCoincidencias = false;
        string _VarAux = "";
        string _strToken = "";
        List<int> lineasErroresSintacticos = new List<int>();
        List<string> archivoTemporal = new List<string>();
        int i = 1;
        int _intErroresSintacticos = 0;
        string _strMensajeLineas = "";
        int renglon = 0;
        Dictionary<int, int> Indices = new Dictionary<int, int>();
        Dictionary<int, int> IndicesErrores = new Dictionary<int, int>();

        private void btn_Validar_Click(object sender, EventArgs e)
        {
            if (richtxt_token.Text == "") 
            {   
                MessageBox.Show("Debes ejecutar el Analizador Lexico", "Analizador Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            richtxtBottomUp.Text = "";
            renglon = 1;

            Indices.Clear();
            IndicesErrores.Clear();
            archivoTemporal.Clear();


            // Lista que permite claves duplicadas
            List<KeyValuePair<string, string>> gramaticaOut = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("S", "S S S S"),

                //For
                new KeyValuePair<string, string>("FOR", "PARE11 CAE( CON CAE; CONDIC CAE; IDEN OPA OPA CAE)"),
                new KeyValuePair<string, string>("FOR", "PARE11 CAE( IDEN OPASIG CONU CAE; CONDIC CAE; IDEN OPA OPA CAE)"),

                //Do While
                new KeyValuePair<string, string>("DO", "PARE08"), //Do 
                //new KeyValuePair<string, string>("S", "PARE08 CAE{ S CAE} PARE22 CAE( CONDIC CAE)"), //Do { S } While ( 5 < 3 )

                //While
                new KeyValuePair<string, string>("WHILE", "PARE22 CAE( CONDIC CAE)"), //While ( 5 < 3 )
                new KeyValuePair<string, string>("WHILE", "PARE22 CAE( CONDIC CAE) CAE{ S CAE}"), //While ( 5 < 3 ) { S }

                //If
                new KeyValuePair<string, string>("IF", "PARE12 CAE( CONDIC CAE)"), //If ( 5 < 3 )
                new KeyValuePair<string, string>("IF", "PARE12 CAE( CONDIC CAE) CAE{ S CAE}"), //If ( 5 < 3 ) { S }
                
                new KeyValuePair<string, string>("}", "CAE}"), //Fin ( } )
                new KeyValuePair<string, string>("{", "CAE{"), //Entonces ( { )
                new KeyValuePair<string, string>("START", "PARE17 CAE{"), //Start
                new KeyValuePair<string, string>("END", "CAE} PARE09"), //End
                new KeyValuePair<string, string>("CON", "PARE13 IDEN"), //In

                //Asignacion
                new KeyValuePair<string, string>("CON", "IDEN OPASIG IDEN"),
                new KeyValuePair<string, string>("CON", "IDEN OPASIG IDEN"),
                new KeyValuePair<string, string>("CON", "IDEN OPASIG CONU"),
                new KeyValuePair<string, string>("CON", "IDEN OPASIG STRING"),
                new KeyValuePair<string, string>("CON", "IDEN OPASIG OPARI"),
                new KeyValuePair<string, string>("CON", "IDEN OPASIG PARE19"),
                new KeyValuePair<string, string>("CON", "IDEN OPASIG PARE10"),

                //Declaracion
                new KeyValuePair<string, string>("CON", "TIPDAT IDEN OPASIG IDEN"),
                new KeyValuePair<string, string>("CON", "TIPDAT IDEN OPASIG IDEN"),
                new KeyValuePair<string, string>("CON", "TIPDAT IDEN OPASIG CONU"),
                new KeyValuePair<string, string>("CON", "TIPDAT IDEN OPASIG STRING"),
                new KeyValuePair<string, string>("CON", "TIPDAT IDEN OPASIG OPARI"),
                new KeyValuePair<string, string>("CON", "TIPDAT IDEN OPASIG PARE19"),
                new KeyValuePair<string, string>("CON", "TIPDAT IDEN OPASIG PARE10"),

                //out
                new KeyValuePair<string, string>("CON", "PARE16 IDEN"),
                new KeyValuePair<string, string>("CON", "PARE16 CONU"),
                new KeyValuePair<string, string>("CON", "PARE16 STRING"),
                new KeyValuePair<string, string>("CON", "PARE16 OPARI"),

                new KeyValuePair<string, string>("CONDIC", "OPLOG|OPREL"),
                new KeyValuePair<string, string>("OPREL", "CONU OPR CONU"),
                new KeyValuePair<string, string>("OPREL", "CONU OPR IDEN"),
                new KeyValuePair<string, string>("OPREL", "IDEN OPR CONU"),
                new KeyValuePair<string, string>("OPREL", "IDEN OPR IDEN"),
                new KeyValuePair<string, string>("OPLOG", "CONDIC OPL CONDIC"),

                new KeyValuePair<string, string>("OPARI", "OPARI OPA OPARI"),
                new KeyValuePair<string, string>("OPARI", "OPARI OPA IDEN"),
                new KeyValuePair<string, string>("OPARI", "OPARI OPA CONU"),
                new KeyValuePair<string, string>("OPARI", "OPARI OPA IDEN"),
                new KeyValuePair<string, string>("OPARI", "OPARI OPA CONU"),

                new KeyValuePair<string, string>("OPARI", "IDEN OPA IDEN"),
                new KeyValuePair<string, string>("OPARI", "IDEN OPA CONU"),
                new KeyValuePair<string, string>("OPARI", "CONU OPA IDEN"),
                new KeyValuePair<string, string>("OPARI", "CONU OPA CONU"),



                
                new KeyValuePair<string, string>("OPR", "OPR==|OPR>|OPR<"),
                new KeyValuePair<string, string>("OPL", "OPL&|OPL!"),
                new KeyValuePair<string, string>("TIPDAT", "PARE14|PARE07|PARE18|PARE02"),
                new KeyValuePair<string, string>("IDEN", "IDEN1|IDEN2|IDEN3|IDEN4|IDEN5"),
                new KeyValuePair<string, string>("CONU", "CNE|CNR"),
                new KeyValuePair<string, string>("OPA", "OPAS|OPAR|OPAM|OPAD")

            };

            i = 1;
            _intErroresSintacticos = 0;
            _strMensajeLineas = "";
            lineasErroresSintacticos.Clear();

            foreach (string Lineas in richtxt_token.Lines)
            {
                _strToken = "";
                richtxtBottomUp.Text += "---------------------------------------------------------------------LINEA " + i + "---------------------------------------------------------------------\r\n" + Lineas + "\r\n";
                if (Lineas[Lineas.Length - 1] == ' ') { _VarAux = Lineas.Substring(0, Lineas.Length - 1); _VarAux += " "; }//Quito el \r y \n y agrego el espacio en blanco
                else { _VarAux = Lineas + " "; }
                RecorrerGramatica(gramaticaOut);
                i++;
                renglon+=2;
            }

            

            foreach (var item in Indices)
            {
                richtxtBottomUp.Select(item.Key, item.Value);
                richtxtBottomUp.SelectionColor = Color.Blue;
            }

            foreach (var item in IndicesErrores)
            {
                richtxtBottomUp.Select(item.Key, item.Value);
                richtxtBottomUp.SelectionColor = Color.Red;
            }

            if (_intErroresSintacticos > 0) 
            {
                foreach (int LineaError in lineasErroresSintacticos){ _strMensajeLineas += LineaError + ", "; }
                MessageBox.Show($"La(s) linea(s) {_strMensajeLineas.Substring(0, _strMensajeLineas.Length - 2)} tienen errores de sintaxis", "Analizador Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else { MessageBox.Show("¡Sintaxis Correcta!", "Analizador Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        string _strVarAux2 = "";

        public void RecorrerGramatica(List<KeyValuePair<string, string>> Gramatica)
        {
            for (int i = 0; i < 3; i++)
            {
                //Recorre el diccionario de abajo hacia arriba
                foreach (var item in Gramatica.AsEnumerable().Reverse())
                {
                    foreach (char letra in item.Value)
                    {
                        if (letra == '|')
                        {
                            VerificarCoincidencia(item.Key, richtxtBottomUp);
                        }
                        else
                        {
                            //Palabra o espacio
                            _strToken += letra;
                        }
                    }
                    VerificarCoincidencia(item.Key, richtxtBottomUp);
                }
            }
            if (_VarAux != "CON " && _VarAux != "START " && _VarAux != "END " && _VarAux != "IF " && _VarAux != "FOR " && _VarAux != "DO " && _VarAux != "WHILE " && _VarAux != "OUT " && _VarAux != "IN " && _VarAux != "{ " && _VarAux != "} " && _VarAux != "ASIG")
            {
                _intErroresSintacticos++;
                lineasErroresSintacticos.Add(i);
                IndicesErrores.Add(richtxtBottomUp.GetFirstCharIndexFromLine(renglon), richtxtBottomUp.Lines[renglon].Length);
            }
            else
            {
                archivoTemporal.Add(_VarAux);
            }
        }
        
        public void VerificarCoincidencia(string _strKey, RichTextBox richtxt)
        {
            
            _blnCoincidencias = false;
            int j = 0;
            int indice = 0;
            
            string nuevalinea = "";

            if (_strKey == "S")
            {
                if (_strToken + " " == _VarAux)
                {
                    //No hace nada
                }
                else
                {
                    _strToken = "";
                    return;
                }
            }

            for (int i = 0; i < _VarAux.Length; i++)
            {
                if ((j == _strToken.Length && _VarAux[i] == ' ')) //Si j llego al tamaño del token, y llego a un blanco o al final, coincidencia encontrada
                {
                    _blnCoincidencias = true;
                    for (int k = 0; k < _VarAux.Length; k++)
                    {
                        if (k == indice)
                        {
                            nuevalinea += _strKey;
                        }
                        else if (k > indice && k < (indice + _strToken.Length))
                        {
                            // No hace nada
                        }
                        else
                        {
                            nuevalinea += _VarAux[k];
                        }
                    }
                    richtxt.Text += nuevalinea + "\r\n";

                    Indices.Add(richtxt.GetFirstCharIndexFromLine(renglon) + indice, _strToken.Length);
                    renglon = renglon + 1;

                    _VarAux = nuevalinea;
                    nuevalinea = "";
                    j = 0;
                }
                else if (j == _strToken.Length)
                {
                    j = 0;
                }
                else if (_strToken[j] == _VarAux[i]) //Si encuentra una coincidencia en la linea
                {
                    if (j == 0) { indice = i; } //Guarda su indice por si lo es
                    j++; //Avanza al siguiente caracter
                }
                else //Si ya no encontro, se reinicia y ya no es una coincidencia
                {
                    j = 0;

                    //VUELVE A VERIFICAR EN LA POSICION ACTUAL

                    if (_strToken[j] == _VarAux[i]) //Si encuentra una coincidencia en la linea
                    {
                        if (j == 0) { indice = i; } //Guarda su indice por si lo es
                        j++; //Avanza al siguiente caracter
                    }
                }
            }

            _strToken = "";
        }

        private void btnGuardarSimbolos_Click(object sender, EventArgs e)
        {
            simbolos = "";

            for (int i = 0; i < numero.Count; i++)
            {
                simbolos += numero[i] + " " + nombre[i] + " " + tipodato[i] + "\n\r";
            }
            Guardar(simbolos);
        }

        private void btnValidarSemantico_Click(object sender, EventArgs e)
        {
            string _strIden = "";
            string _strNumIden = "";
            bool _blnIden = false;
            bool _blnS = true;
            int _intErroresSemanticos = 0;
            List<int> lineasErroresSemanticos = new List<int>();

            richtxtJELU.Text = "";
            renglon = 1;

            Indices.Clear();
            IndicesErrores.Clear();
            lineasErroresSemanticos.Clear();
            dgvErroresSemanticos.Rows.Clear();
            _strMensajeLineas = "";
            i = 1;
            int _intIden = 0;

            List<KeyValuePair<string, string>> gramaticaexpresiones = new List<KeyValuePair<string, string>>()
            {
                //ASIGNACION
                new KeyValuePair<string, string>("S", "ENT OPASIG ENT"),
                new KeyValuePair<string, string>("S", "DEC OPASIG DEC"),
                new KeyValuePair<string, string>("S", "CAD OPASIG CAD"),

                //DECLARACION DE VARIABLES
                new KeyValuePair<string, string>("S", "PARE14 ENT OPASIG ENT"),
                new KeyValuePair<string, string>("S", "PARE07 DEC OPASIG DEC"),
                new KeyValuePair<string, string>("S", "PARE18 CAD OPASIG CAD"),

                //FOR
                new KeyValuePair<string, string>("S", "PARE11 CAE( ENT OPASIG ENT CAE; ENT OPR ENT CAE; ENT OPAS OPAS CAE)"),
                
                //IF
                new KeyValuePair<string, string>("S", "PARE12 CAE( ENT OPR ENT CAE)"),
                new KeyValuePair<string, string>("S", "PARE12 CAE( ENT OPR DEC CAE)"),
                new KeyValuePair<string, string>("S", "PARE12 CAE( DEC OPR ENT CAE)"),
                new KeyValuePair<string, string>("S", "PARE12 CAE( DEC OPR DEC CAE)"),
                new KeyValuePair<string, string>("S", "PARE12 CAE( CAD OPR CAD CAE)"),
                new KeyValuePair<string, string>("OPR", "OPR==|OPR>|OPR<"),

                //OUT
                new KeyValuePair<string, string>("S", "PARE16 ENT"),
                new KeyValuePair<string, string>("S", "PARE16 DEC"),
                new KeyValuePair<string, string>("S", "PARE16 CAD"),
                new KeyValuePair<string, string>("S", "PARE16 ENT OPAS ENT"),
                new KeyValuePair<string, string>("S", "PARE16 ENT OPAS DEC"),
                new KeyValuePair<string, string>("S", "PARE16 DEC OPAS ENT"),
                new KeyValuePair<string, string>("S", "PARE16 DEC OPAS DEC"),
                new KeyValuePair<string, string>("S", "PARE16 ENT OPAR ENT"),
                new KeyValuePair<string, string>("S", "PARE16 ENT OPAR DEC"),
                new KeyValuePair<string, string>("S", "PARE16 DEC OPAR ENT"),
                new KeyValuePair<string, string>("S", "PARE16 DEC OPAR DEC"),
                new KeyValuePair<string, string>("S", "PARE16 ENT OPAM ENT"),
                new KeyValuePair<string, string>("S", "PARE16 ENT OPAM DEC"),
                new KeyValuePair<string, string>("S", "PARE16 DEC OPAM ENT"),
                new KeyValuePair<string, string>("S", "PARE16 DEC OPAM DEC"),
                new KeyValuePair<string, string>("S", "PARE16 DEC OPAD DEC"),

                //IN
                new KeyValuePair<string, string>("S", "PARE13 ENT"),
                new KeyValuePair<string, string>("S", "PARE13 DEC"),
                new KeyValuePair<string, string>("S", "PARE13 CAD"),

                //TRANSFORMACION DE TIPOS DE DATOS
                new KeyValuePair<string, string>("ENT", "ENT OPAD ENT"),
                new KeyValuePair<string, string>("ENT", "ENT OPAM ENT"),
                new KeyValuePair<string, string>("ENT", "ENT OPAS ENT"),
                new KeyValuePair<string, string>("DEC", "CNR"),

                new KeyValuePair<string, string>("ENT", "CNE"),
                new KeyValuePair<string, string>("DEC", "CNR"),
                new KeyValuePair<string, string>("CAD", "STRING"),
            };

            List<KeyValuePair<string, string>> JELU = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("S", "START CON END"),
                new KeyValuePair<string, string>("CON", "CON CON"),
                new KeyValuePair<string, string>("CON", "IF { CON }"),
                new KeyValuePair<string, string>("CON", "IF { }"),
                new KeyValuePair<string, string>("CON", "FOR { CON }"),
                new KeyValuePair<string, string>("CON", "FOR { }"),
            };

            foreach (string Lineas in richtxt_token.Lines)
            {
                _strToken = "";
                richtxtJELU.Text += "---------------------------------------------------------------------LINEA " + i + "---------------------------------------------------------------------\r\n" + Lineas + "\r\n";
                if (Lineas[Lineas.Length - 1] == ' ') { _VarAux = Lineas.Substring(0, Lineas.Length - 1); _VarAux += " "; }//Quito el \r y \n y agrego el espacio en blanco
                else { _VarAux = Lineas + " "; }

                _blnS = true;

                //Primera pasada (Verificar tipos de datos)
                foreach (char letra in _VarAux)
                {
                    if (_strIden == "IDEN" && _blnIden)
                    {
                        _blnS = false;
                        if (letra != ' ') { _strNumIden += letra; } //Guarda IDEN + el numero del identificador
                        else 
                        {
                            if (int.TryParse(_strNumIden, out _))
                            {
                                VerificarTipoDato(int.Parse(_strNumIden)); //Al verificar, cambia _VarAux por la nueva linea
                            }
                            else {  dgvErroresSemanticos.Rows.Add(i, "Variable \"" + idensindeclarar[_intIden] + "\" no declarado"); _intIden++; }
                            
                            _blnIden = false; 
                            _strIden = "";  
                            _strNumIden = "";

                            //AQUI
                        }
                    }

                    else if (letra == 'I' || _blnIden) //Posible IDEN
                    {
                        _blnIden = true;
                        _strIden += letra;
                    }
                    
                    if (letra == ' ')
                    {
                        _strIden = "";
                        _blnIden = false;
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    //Recorre el diccionario de abajo hacia arriba
                    foreach (var item in gramaticaexpresiones.AsEnumerable().Reverse())
                    {
                        foreach (char letra1 in item.Value)
                        {
                            if (letra1 == '|')
                            {
                                VerificarCoincidencia(item.Key, richtxtJELU);
                            }
                            else
                            {
                                //Palabra o espacio
                                _strToken += letra1;
                            }
                        }
                        VerificarCoincidencia(item.Key, richtxtJELU);
                    }
                }

                if (_blnS)
                {
                    _VarAux = "S ";
                    richtxtJELU.Text += _VarAux + "\r\n";
                    renglon++;
                }
                else if (_VarAux != "S ")
                {
                    _intErroresSemanticos++;
                    lineasErroresSemanticos.Add(i);
                    IndicesErrores.Add(richtxtJELU.GetFirstCharIndexFromLine(renglon), richtxtJELU.Lines[renglon].Length);
                }
                i++; //Incremento la linea
                renglon += 2;
            }

            

            //JELU
            _VarAux = "";
            List<int> PosibleDesbalance = new List<int>();
            List<int> Corchetes = new List<int>(); //1 = {, 0 = vacio, -1 = }

            for (int i = 0; i < archivoTemporal.Count; i++)
            {
                _VarAux += archivoTemporal[i];

                //Validacion de corchetes

                if (archivoTemporal[i] == "IF " || archivoTemporal[i] == "FOR " || archivoTemporal[i] == "DO ")
                {
                    PosibleDesbalance.Add(i + 1);
                    Corchetes.Add(0);
                }

                if (archivoTemporal[i] == "{ ")
                {
                    Corchetes[Corchetes.Count - 1]++;
                }
                else if (archivoTemporal[i] == "} ")
                {
                    Corchetes[Corchetes.Count - 1]--;
                    if (Corchetes[Corchetes.Count - 1] == 0)
                    {
                        PosibleDesbalance.RemoveAt(PosibleDesbalance.Count - 1);
                        Corchetes.RemoveAt(Corchetes.Count - 1);
                    }
                }
            }

            richtxtJELU.Text += "------------------------------------------------------------------------JELU" + "------------------------------------------------------------------------\r\n" + _VarAux + "\r\n";



            for (int i = 0; i < 8; i++)
            {
                //Recorre el diccionario de abajo hacia arriba
                foreach (var item in JELU.AsEnumerable().Reverse())
                {
                    foreach (char letra in item.Value)
                    {
                        if (letra == '|')
                        {
                            VerificarCoincidencia(item.Key, richtxtJELU);
                        }
                        else
                        {
                            //Palabra o espacio
                            _strToken += letra;
                        }
                    }
                    VerificarCoincidencia(item.Key, richtxtJELU);
                }
            }


            if (_VarAux != "S ") //Si no hay S, buscar los corchetes que no cerraron
            {
                _intErroresSemanticos++;
                IndicesErrores.Add(richtxtJELU.GetFirstCharIndexFromLine(renglon), richtxtJELU.Lines[renglon].Length);

                
            }

            if (PosibleDesbalance.Count > 0 || _intErroresSemanticos > 0)
            {
                MessageBox.Show("El codigo tiene errores semanticos", "Analizador Semantico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (archivoTemporal[0] != "START ")
                {
                    dgvErroresSemanticos.Rows.Add(1, "Se esperaba un \"Start {\" en la primera linea");
                }

                if (archivoTemporal[archivoTemporal.Count - 1] != "END ")
                {
                    dgvErroresSemanticos.Rows.Add(archivoTemporal.Count + 1, "Se esperaba un \"} End\" en la ultima linea");
                }

                for (int i = 0; i < PosibleDesbalance.Count; i++)
                {
                    switch (Corchetes[i])
                    {
                        case -1:
                            dgvErroresSemanticos.Rows.Add(PosibleDesbalance[i], "Se esperaba un \"{\" para la instruccion " + archivoTemporal[PosibleDesbalance[i] - 1]);
                            break;
                        case 0:
                            dgvErroresSemanticos.Rows.Add(PosibleDesbalance[i], "Se esperaba un \"{\" y \"}\" para la instruccion " + archivoTemporal[PosibleDesbalance[i] - 1]);
                            break;
                        case 1:
                            dgvErroresSemanticos.Rows.Add(PosibleDesbalance[i], "Se esperaba un \"}\" para la instruccion " + archivoTemporal[PosibleDesbalance[i] - 1]);
                            break;
                    }
                }

                foreach (int LineaError in lineasErroresSemanticos)
                {
                    dgvErroresSemanticos.Rows.Add(LineaError, "Tipos de datos no compatibles");
                }
                dgvErroresSemanticos.Sort(dgvErroresSemanticos.Columns[0], ListSortDirection.Ascending);
            }
            else
            {
                MessageBox.Show("¡Semantica Correcta!", "Analizador Semantico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (var item in Indices)
            {
                richtxtJELU.Select(item.Key, item.Value);
                richtxtJELU.SelectionColor = Color.Blue;
            }

            foreach (var item in IndicesErrores)
            {
                richtxtJELU.Select(item.Key, item.Value);
                richtxtJELU.SelectionColor = Color.Red;
            }
        }

        public void VerificarTipoDato(int _intIden)
        {
            _strToken = "IDEN" + _intIden;
            switch (dgvTablaSimbolos.Rows[_intIden - 1].Cells[2].Value.ToString())
            {
                case "int":
                    VerificarCoincidencia("ENT", richtxtJELU);
                    break;

                case "dec":
                    VerificarCoincidencia("DEC", richtxtJELU);
                    break;

                case "string":
                    VerificarCoincidencia("CAD", richtxtJELU);
                    break;
            }
        }

        private void btnCodigoIntermedio_Click(object sender, EventArgs e)
        {
            dgvPrefijo.Rows.Clear();
            dgvTripleta.Rows.Clear();

            int _intNumLinea = 0;
            _intTemporal = 0;

            List<string> Codigo = new List<string>();

            foreach (string Linea in txt_codigo.Lines)
            {
                if (Linea.StartsWith("_")) //Asignacion
                {
                    dgvPrefijo.Rows.Add(Linea, ConvertirInfijaAPrefija(Linea));
                }

                if (Linea.StartsWith("Int")) //Declaracion
                {
                    dgvPrefijo.Rows.Add(Linea.Substring(4, Linea.Length - 4), ConvertirInfijaAPrefija(Linea.Substring(4, Linea.Length - 4)));
                }
            }

            
            foreach (DataGridViewRow fila in dgvPrefijo.Rows)
            {
                if (fila.Cells[1].Value != null)
                {
                    var tripletas = GenerarTripletasDesdePrefija(fila.Cells[1].Value.ToString());
                    foreach (var tripleta in tripletas)
                    {
                        dgvTripleta.Rows.Add(tripleta.Objeto, tripleta.Fuente, tripleta.Operador);
                    }
                }
            }
        }

        static int Precedencia(char op)
        {
            if (op == '+' || op == '-')
                return 1;
            else if (op == '*' || op == '/')
                return 2;
            else
                return 0;
        }

        static string ConvertirInfijaAPrefija(string infija)
        {
            Stack<string> operandos = new Stack<string>();
            Stack<char> operadores = new Stack<char>();

            for (int i = infija.Length - 1; i >= 0; i--)
            {
                char c = infija[i];

                if (c == ' ')
                    continue;

                if (char.IsLetterOrDigit(c))
                {
                    string operando = c.ToString();

                    while (i - 1 >= 0 && (char.IsLetterOrDigit(infija[i - 1]) || infija[i - 1] == '_'))
                    {
                        i--;
                        operando = infija[i] + operando;
                    }

                    operandos.Push(operando);
                }
                else // operador
                {
                    while (operadores.Count > 0 &&
                           Precedencia(c) < Precedencia(operadores.Peek()))
                    {
                        ProcesarOperador(operadores, operandos);
                    }
                    operadores.Push(c);
                }
            }

            while (operadores.Count > 0)
            {
                ProcesarOperador(operadores, operandos);
            }

            return operandos.Pop();
        }

        static void ProcesarOperador(Stack<char> operadores, Stack<string> operandos)
        {
            char op = operadores.Pop();
            string op1 = operandos.Pop();
            string op2 = operandos.Pop();
            string expresion = op + " " + op1 + " " + op2;
            operandos.Push(expresion);
        }

        public class Tripleta
        {
            public string Objeto { get; set; }
            public string Fuente { get; set; }
            public string Operador { get; set; }
        }

        int _intTemporal = 0;
        private List<Tripleta> GenerarTripletasDesdePrefija(string prefija)
        {
            string[] tokens = prefija.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> pila = new Stack<string>();
            List<Tripleta> tripletas = new List<Tripleta>();

            

            // Caso especial: asignación simple sin operación
            if (tokens.Length == 3 && tokens[0] == "=")
            {
                // tokens[1] = variable destino
                // tokens[2] = valor o variable fuente
                tripletas.Add(new Tripleta
                {
                    Objeto = tokens[1],
                    Fuente = tokens[2],
                    Operador = "="
                });
                return tripletas;
            }

            _intTemporal++;
            string temporal = "T" + _intTemporal;

            string destinoFinal = null;

            int inicio = 0;

            if (tokens.Length >= 3 && tokens[0] == "=")
            {
                destinoFinal = tokens[1];
                inicio = 2;
            }

            for (int i = tokens.Length - 1; i >= inicio; i--)
            {
                string token = tokens[i];

                if (EsOperador(token))
                {
                    string op1 = pila.Pop();
                    string op2 = pila.Pop();

                    // Ambos operandos no son T1
                    if (op1 != temporal && op2 != temporal)
                    {
                        tripletas.Add(new Tripleta { Objeto = temporal, Fuente = op1, Operador = "=" });
                        tripletas.Add(new Tripleta { Objeto = temporal, Fuente = op2, Operador = token });
                    }
                    else if (op1 == temporal && op2 != temporal)
                    {
                        tripletas.Add(new Tripleta { Objeto = temporal, Fuente = op2, Operador = token });
                    }
                    else if (op2 == temporal && op1 != temporal)
                    {
                        tripletas.Add(new Tripleta { Objeto = temporal, Fuente = op1, Operador = token });
                    }
                    else if (op1 == temporal && op2 == temporal)
                    {
                        // Esto en teoría no debería pasar con una sola temporal
                    }

                    pila.Push(temporal);
                }
                else
                {
                    pila.Push(token);
                }
            }

            if (destinoFinal != null)
            {
                tripletas.Add(new Tripleta { Objeto = destinoFinal, Fuente = temporal, Operador = "=" });
            }

            return tripletas;
        }

        private bool EsOperador(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "=";
        }

        private void btnEjecutarEnsamblador_Click(object sender, EventArgs e)
        {
            string codigo = "using System;" +
                "\n\rclass Program()" +
                "\n\r{" +
                "\n\rstatic void Main()" +
                "\n\r{";

            foreach (var linea in txt_codigo.Lines)
            {
                string traducida = TraducirLinea(linea);
                codigo += "\n\r" + traducida;
            }


            codigo += "\n\rConsole.ReadKey();" +
                "\n\r}" +
                "\n\r}";

            

            string codigoFuente = txt_codigo.Text;
            string[] lineas = codigoFuente.Split('\n');
            string resultadoASM = TraducirATASM(lineas, dgvPrefijo);
            richEnsamblador.Text = resultadoASM;

            Ejecutar(codigo);
        }

        string TraducirLinea(string linea)
        {
            linea = linea.Trim();

            if (linea.StartsWith("Dec "))
                return "double " + linea.Substring(4) + ";";

            if (linea.StartsWith("Int "))
                return "int " + linea.Substring(4) + ";";

            if (linea.StartsWith("In "))
            {
                string variable = linea.Substring(3).Trim();
                string tipo = ObtenerTipoDeVariable(variable);

                if (tipo == "int")
                    return $"{variable} = int.Parse(Console.ReadLine());";
                else if (tipo == "dec")
                    return $"{variable} = double.Parse(Console.ReadLine());";
                else if (tipo == "string")
                    return $"{variable} = Console.ReadLine();";
                else
                    return $"// Tipo desconocido para {variable}";
            }

            if (linea.StartsWith("Out "))
            {
                var contenido = linea.Substring(4).Trim();

                if (contenido == "$\\n$" || contenido == "$\n$")
                {
                    return "Console.WriteLine();";
                }
                else if (contenido.StartsWith("$") && contenido.EndsWith("$"))
                {
                    string literal = contenido.Substring(1, contenido.Length - 2)
                                             .Replace("\\\"", "\"");
                    return $"Console.Write(\"{literal}\");";
                }
                else
                {
                    return $"Console.Write({contenido});";
                }
            }

            if (linea.StartsWith("If "))
            {
                string condicion = linea.Substring(3).Trim();
                return "if " + condicion;
            }

            if (linea == "Start {") return "";
            if (linea == "} End") return "";

            if (linea.StartsWith("For "))
            {
                string contenido = linea.Substring(4).Trim();

                // Por si hay espacios de más en el "++"
                contenido = contenido.Replace("+ +", "++");

                return "for " + contenido;
            }

            if (linea.StartsWith("_"))
            {
                return linea + ";";
            }

            // Por si acaso, corregimos ++ mal escritos
            linea = linea.Replace("+ +", "++");

            
            return linea;
        }

        string ObtenerTipoDeVariable(string nombreVariable)
        {
            foreach (DataGridViewRow fila in dgvTablaSimbolos.Rows)
            {
                if (fila.Cells[1].Value?.ToString() == nombreVariable)
                {
                    return fila.Cells[2].Value?.ToString(); // "int", "double", "string"
                }
            }
            return null; // Si no se encuentra
        }

        private string TraducirATASM(string[] lineas, DataGridView dgvPrefijo)
        {
            var asm = new StringBuilder();

            // Encabezado TASM
            asm.AppendLine(".model small");
            asm.AppendLine(".stack 100h");
            asm.AppendLine(".data");

            var variables = new List<string>();
            var cadenas = new List<string>();
            int contadorCadenas = 1;

            // Primera pasada: detectar variables y cadenas
            foreach (var linea in lineas)
            {
                if (linea.Trim().StartsWith("Int "))
                {
                    var nombre = linea.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    asm.AppendLine($"{nombre} dw 0");
                    variables.Add(nombre);
                }
                else if (linea.Trim().StartsWith("Dec "))
                {
                    var nombre = linea.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    asm.AppendLine($"{nombre} dw 0 ; decimal simulado");
                    variables.Add(nombre);
                }
                else if (linea.Trim().StartsWith("Out $"))
                {
                    var contenido = linea.Trim().Replace("Out $", "").Replace("$", "").Replace("\\n", "\r\n");
                    var nombreCadena = $"Cad{contadorCadenas}";
                    asm.AppendLine($"{nombreCadena} db \"{contenido}\", '$'");
                    cadenas.Add(nombreCadena);
                    contadorCadenas++;
                }
            }

            // Variables temporales
            for (int i = 1; i <= 3; i++)
            {
                asm.AppendLine($"T{i} dw 0");
            }

            asm.AppendLine(".code");
            asm.AppendLine("start:");
            asm.AppendLine("    mov ax, @data");
            asm.AppendLine("    mov ds, ax");

            // Segunda pasada: instrucciones
            foreach (var linea in lineas)
            {
                var l = linea.Trim();

                if (l.StartsWith("Out $"))
                {
                    asm.AppendLine($"    mov ah, 9");
                    asm.AppendLine($"    lea dx, {cadenas[0]}");
                    asm.AppendLine($"    int 21h");
                    cadenas.RemoveAt(0);
                }
                else if (l.StartsWith("Out "))
                {
                    var valor = l.Replace("Out ", "").Trim();
                    asm.AppendLine($"    mov ax, {valor}");
                    asm.AppendLine($"    call PrintNumber");
                }
                else if (l.StartsWith("In "))
                {
                    var nombre = l.Split(' ')[1];
                    asm.AppendLine($"    ; Lectura para {nombre} (requiere rutina personalizada)");
                }
                else if (l.StartsWith("For"))
                {
                    asm.AppendLine("    mov It, 1");
                    asm.AppendLine("for_loop:");
                    asm.AppendLine("    cmp It, 11");
                    asm.AppendLine("    jge end_for");
                }
                else if (l.StartsWith("If"))
                {
                    var condicion = l.Replace("If", "").Trim('(', ')', ' ');
                    var etiqueta = $"cond_{Guid.NewGuid().ToString("N").Substring(0, 6)}";
                    asm.AppendLine($"    ; If ({condicion})");
                    asm.AppendLine($"    ; Aquí iría lógica para {condicion}");
                    asm.AppendLine($"    ; jnz {etiqueta}");
                }
                else if (l.Contains('=') && (l.Contains('+') || l.Contains('*') || l.Contains('-') || l.Contains('/')))
                {
                    var asmDesdePrefijo = GenerarAsmDesdePrefijoParaLinea(l, dgvPrefijo);
                    asm.AppendLine(asmDesdePrefijo);
                }
                else if (l.StartsWith("}"))
                {
                    asm.AppendLine("    ; Fin de bloque");
                }
            }

            asm.AppendLine("end_for:");
            asm.AppendLine("    mov ah, 4Ch");
            asm.AppendLine("    int 21h");

            // Subrutina PrintNumber
            asm.AppendLine(@"
PrintNumber proc
    push ax
    push bx
    push cx
    push dx
    xor cx, cx
    mov bx, 10
.next:
    xor dx, dx
    div bx
    push dx
    inc cx
    test ax, ax
    jnz .next
.print:
    pop dx
    add dl, '0'
    mov ah, 2
    int 21h
    loop .print
    pop dx
    pop cx
    pop bx
    pop ax
    ret
PrintNumber endp
");

            return asm.ToString();
        }

        private string GenerarAsmDesdePrefijoParaLinea(string lineaOriginal, DataGridView dgvPrefijo)
        {
            var sb = new StringBuilder();

            string destino = lineaOriginal.Split('=')[0].Trim();

            string prefija = null;
            foreach (DataGridViewRow fila in dgvPrefijo.Rows)
            {
                if (fila.IsNewRow) continue;

                string infija = fila.Cells[0].Value?.ToString()?.Trim();
                if (infija == lineaOriginal.Trim())
                {
                    prefija = fila.Cells[1].Value?.ToString()?.Trim();
                    break;
                }
            }

            if (string.IsNullOrEmpty(prefija))
            {
                sb.AppendLine($"; No se encontró versión prefija de: {lineaOriginal}");
                return sb.ToString();
            }

            var tokens = prefija.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var pila = new Stack<string>();
            int tempNum = 1;

            for (int i = tokens.Length - 1; i >= 0; i--)
            {
                string token = tokens[i];

                if (EsOperador(token))
                {
                    string op1 = pila.Pop();
                    string op2 = pila.Pop();
                    string temp = $"T{tempNum++}";

                    sb.AppendLine($"; {temp} = {op1} {token} {op2}");
                    sb.AppendLine($"    mov ax, {op1}");

                    switch (token)
                    {
                        case "*":
                            sb.AppendLine($"    mov bx, {op2}");
                            sb.AppendLine($"    mul bx");
                            break;
                        case "/":
                            sb.AppendLine($"    mov dx, 0");
                            sb.AppendLine($"    mov bx, {op2}");
                            sb.AppendLine($"    div bx");
                            break;
                        case "+":
                            sb.AppendLine($"    mov bx, {op2}");
                            sb.AppendLine($"    add ax, bx");
                            break;
                        case "-":
                            sb.AppendLine($"    mov bx, {op2}");
                            sb.AppendLine($"    sub ax, bx");
                            break;
                    }

                    sb.AppendLine($"    mov {temp}, ax");
                    pila.Push(temp);
                }
                else
                {
                    pila.Push(token);
                }
            }

            string resultadoFinal = pila.Pop();
            sb.AppendLine($"    mov ax, {resultadoFinal}");
            sb.AppendLine($"    mov {destino}, ax");
            sb.AppendLine();

            return sb.ToString();
        }




        public void Ejecutar(string codigo)
        {
            // Compilar y generar exe
            string rutaExe = Path.Combine(Path.GetTempPath(), "programaGenerado.exe");

            var syntaxTree = CSharpSyntaxTree.ParseText(codigo);

            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
            };

            var compilation = CSharpCompilation.Create(
                "programaGenerado.exe",
                new[] { syntaxTree },
                references,
                new CSharpCompilationOptions(OutputKind.ConsoleApplication)
            );

            EmitResult result;

            using (var fs = new FileStream(rutaExe, FileMode.Create))
            {
                result = compilation.Emit(fs);
            }

            if (!result.Success)
            {
                // Mostrar errores de compilación
                var errores = string.Join(Environment.NewLine, result.Diagnostics);
                MessageBox.Show("Errores de compilación:" + Environment.NewLine + errores);
                return;
            }

            // Ejecutar el exe y mostrar consola
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaExe,
                UseShellExecute = true,
                CreateNoWindow = false
            });
        }
    }
}
