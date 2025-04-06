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

namespace ColinScript
{
    public partial class Form1 : Form
    {
        List<string> nombre = new List<string>();
        List<int> numero = new List<int>();
        List<string> tipodato = new List<string>();
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
                new KeyValuePair<string, string>("FOR", "PARE11 CAE( IDEN OPASIG IDEN CAE; CONDIC CAE; IDEN OPA OPA CAE)"),
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
                new KeyValuePair<string, string>("OPARI", "IDEN OPA IDEN"),
                new KeyValuePair<string, string>("OPARI", "IDEN OPA CONU"),
                new KeyValuePair<string, string>("OPARI", "CONU OPA IDEN"),
                new KeyValuePair<string, string>("OPARI", "CONU OPA CONU"),

                
                new KeyValuePair<string, string>("OPR", "OPR=|OPR>|OPR<"),
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
            else { MessageBox.Show("Sintaxis Correcta!", "Analizador Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Information); }
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
            if (_VarAux != "CON " && _VarAux != "START " && _VarAux != "END " && _VarAux != "IF " && _VarAux != "FOR " && _VarAux != "DO " && _VarAux != "WHILE " && _VarAux != "OUT " && _VarAux != "IN " && _VarAux != "{ " && _VarAux != "} ")
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
            int j = 0;
            int indice = 0;
            
            string nuevalinea = "";

            for (int i = 0; i < _VarAux.Length; i++)
            {
                if ((j == _strToken.Length && _VarAux[i] == ' ')) //Si j llego al tamaño del token, y llego a un blanco o al final, coincidencia encontrada
                {
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
            i = 1;

            List<KeyValuePair<string, string>> gramaticaexpresiones = new List<KeyValuePair<string, string>>()
            {
                //ASIGNACION
                new KeyValuePair<string, string>("S", "CNE OPASIG CNE"),
                new KeyValuePair<string, string>("S", "CNR OPASIG CNR"),
                new KeyValuePair<string, string>("S", "STRING OPASIG STRING"),

                //DECLARACION DE VARIABLES
                new KeyValuePair<string, string>("S", "PARE14 CNE OPASIG CNE"),
                new KeyValuePair<string, string>("S", "PARE07 CNR OPASIG CNR"),
                new KeyValuePair<string, string>("S", "PARE18 STRING OPASIG STRING"),

            };

            List<KeyValuePair<string, string>> JELU = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("S", "START CON END"),
                new KeyValuePair<string, string>("CON", "CON CON"),
                new KeyValuePair<string, string>("CON", "IF CON"),
                new KeyValuePair<string, string>("CON", "{ CON }")

            };

            foreach (string Lineas in richtxt_token.Lines)
            {
                _strToken = "";
                richtxtJELU.Text += "---------------------------------------------------------------------LINEA " + i + "---------------------------------------------------------------------\r\n" + Lineas + "\r\n";
                if (Lineas[Lineas.Length - 1] == ' ') { _VarAux = Lineas.Substring(0, Lineas.Length - 1); _VarAux += " "; }//Quito el \r y \n y agrego el espacio en blanco
                else { _VarAux = Lineas + " "; }
                i++;
                renglon += 2;

                _blnS = true;

                //Primera pasada (Verificar tipos de datos)
                foreach (char letra in _VarAux)
                {
                    if (_strIden == "IDEN" && _blnIden)
                    {
                        if(letra != ' ') { _strNumIden += letra; } //Guarda IDEN + el numero del identificador
                        else 
                        { 
                            VerificarTipoDato(int.Parse(_strNumIden)); //Al verificar, cambia _VarAux por la nueva linea
                            _blnIden = false; 
                            _strIden = "";  
                            _strNumIden = "";
                            _blnS = false;

                            for (int i = 0; i < 3; i++)
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

                if (_blnS)
                {
                    _VarAux = "S ";
                    //richtxtJELU.Text = "S ";
                }

                if (_VarAux != "S ")
                {
                    _intErroresSemanticos++;
                    lineasErroresSemanticos.Add(i);
                }

            }

            if (_intErroresSemanticos > 0)
            {
                foreach (int LineaError in lineasErroresSemanticos) { _strMensajeLineas += LineaError + ", ";  }
                MessageBox.Show($"La(s) linea(s) {_strMensajeLineas.Substring(0, _strMensajeLineas.Length - 2)} tienen errores de tipo de dato", "Analizador Semantico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
            else { MessageBox.Show("Tipos de datos correctos!", "Analizador Semantico", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            //JELU
            string _strConcatenacionJELU = "";
            _VarAux = "";
            foreach (string lineas in archivoTemporal)
            {
                _VarAux += lineas;
            }

            for (int i = 0; i < 3; i++)
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

        }

        public void VerificarTipoDato(int _intIden)
        {
            _strToken = "IDEN" + _intIden;
            switch (dgvTablaSimbolos.Rows[_intIden - 1].Cells[2].Value.ToString())
            {
                case "int":
                    VerificarCoincidencia("CNE", richtxtJELU);
                    break;

                case "dec":
                    VerificarCoincidencia("CNR", richtxtJELU);
                    break;

                case "string":
                    VerificarCoincidencia("STRING", richtxtJELU);
                    break;
            }
        }
    }
}
