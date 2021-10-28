using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Semantico_analizador
{
	public partial class First : Form
	{
		int cantLineas = 0;

		//tabla_Simbolos tabla_simbolos = new tabla_Simbolos();
		tabla_errores tabla_errorres = new tabla_errores();
		tablaExtra tabla_simb = new tablaExtra();
		tablaExtra tabla_simb2 = new tablaExtra();

		public First()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			rTexto.Text = "";
            codge.Text = "";
			cantLineas = 0;
			tabla_errorres = new tabla_errores();
			tabla_simb = new tablaExtra();
			tabla_simb2 = new tablaExtra();
		}

		private void First_Load(object sender, EventArgs e)
		{
			tabla_simb.inicialista();
		}
        public void leer_texto(string texto)
        {

            int contador_Ambitoi = 0;
            int contador_Ambitf = 0;
            int ambito = 0;

            string Rtexto = "";

            //se le asigna a esta variable el texto que contiene el codigo
            Rtexto = rTexto.Text;

            try
            {
                string[] palabra_sep;
                int num_lineas = rTexto.Lines.Length;

                int num_line_token = 0;

                while (Rtexto != "")
                {
                    //separamos las palabras divididas por espacios
                    palabra_sep = rTexto.Text.Split(' ');
                    foreach (var palabra in palabra_sep)
                    {
                        num_line_token = num_line_token + 1;

                        if (palabra == "{")
                        {
                            contador_Ambitoi = contador_Ambitoi + 1;
                        }
                        if (palabra == "}")
                        {
                            contador_Ambitf = contador_Ambitf + 1;
                        }
                        ambito = contador_Ambitoi;


                        /*en esta parte se compara si la palabra esta dentro de la tabla de simbolos que tenemos predefinida
                         con mi lenguaje*/
                        if (tabla_simb2.compararAL(palabra.ToString()) && palabra != null)
                        {
                           
                            tab_s obj = new tab_s(palabra, "", num_line_token, -0, ambito, tabla_simb2.compararALRef(palabra.ToString()), "palabra nueva", "palabra contenida en la tabla de simbolos", "");
                            tabla_simb.añadir_obj(obj);

                        }
                        //si dicha palabra no esta contenida dentro de la tabla de simbolos, pues procedemos a insertarla
                        else
                        {
                            if (Regex.IsMatch(palabra, @"[a-zA-Z]") && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, "", num_line_token, -0, ambito, tabla_simb2.contlineas() + 1, "palabra nueva", "palabra que no coincide con la Tabla de simbolos,pero no se considera error", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "+" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "suma", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "-" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "resta", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "*" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "multiplicacion", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "/" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "division", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == ">" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "mayor que", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "<" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "menor que", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "->->" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "igual igual", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "<->" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "menor igual que", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == ">->" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "mayor igual que", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == "!=" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "distinto", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra == ".<<" && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_lineas, -0, ambito, tabla_simb2.contlineas() + 1, "operador", "distinto", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (Regex.IsMatch(palabra, @"\d{1}|\d{2}|\d{3}|\d{4}|\d{5}") && palabra != null)
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_line_token, -0, ambito, tabla_simb2.contlineas() + 1, "numero nuevo", "numero", "");
                                tabla_simb.añadir_obj(obj);
                            }
                            else if (palabra != null && palabra == "->")
                            {
                                tab_s obj = new tab_s(palabra, palabra, num_line_token, -0, ambito, tabla_simb2.contlineas() + 1, "numero nuevo", "numero", "");
                                tabla_simb.añadir_obj(obj);
                            }
                        }
                    }
                    //hasta aqui se realiza el analisis lexico


                    palabra_sep = null;
                    Rtexto = "";
                    cantLineas = num_lineas;
                }

                //verificamos si existe algun error
                if (contador_Ambitf != contador_Ambitoi)
                {
                    tabla_errorres.agrega_error(8);

                }

            }
            catch (ArgumentNullException)
            {

                MessageBox.Show("Error");

                tabla_errorres.agrega_error(2);
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }


        }

        public string[] une_tokens()
        {
            string sentencia = null;
            int tam = 1;
            string[] sentencias = new string[tam + 1];

            int comp = 0;

            string tipov = "";
            List<string> Ltoken = new List<string>();

            for (int i = 1; i <= tam; i++)
            {
                foreach (var token in tabla_simb.llamatabla())
                {
                    if (token.num_linea == i && token != null)
                    {
                        if (comp == 0 && Regex.IsMatch(token.Simbolo, @"(.integer|.float|.double|.booleano|.String)$"))
                        {

                            token.Tipo_Dato = token.Simbolo;
                            tipov = token.Simbolo;
                        }


                        if (comp != 0)
                        {
                            sentencia = sentencia + " " + token.simbolo.ToString();
                            token.Tipo_Dato = tipov;
                        }
                        else
                        {
                            sentencia = sentencia + token.simbolo.ToString();
                            comp = 1;
                        }

                    }
                    else
                    {

                        sentencia = sentencia + " " + token.simbolo.ToString();
                    }
                }
                sentencias[i] = sentencia;
                sentencia = null;
                comp = 0;
                tipov = "";
            }

            return sentencias;
        }

        public void Analisis_Sint_Sem(string[] sentencias)
        {
            List<string> sintaxisCode = new List<string>();

            int cantidad = 0;

            for (int j = 0; j < sentencias.Length; j++)
            {
                if (sentencias[j] != null)
                    cantidad = Regex.Matches(sentencias[j], "\n").Count;

            }

            for (int i = 1; i < sentencias.Length; i++)
            {


                if (sentencias[i] != null)
                {
                    for (int a = 0; a < cantidad; a++)
                    {
                        if (sentencias[i].Contains(".integer") && !sintaxisCode.Contains(".integer"))
                        {
                            sintaxisCode.Add(".integer");

                            //para analisis semantico
                            string[] separanum;
                            separanum = sentencias[i].Split(' ');

                            

                            try
                            {
                                //convierto la sintaxis de mi lenguaje al del c#
                                sentencias[i] = sentencias[i].Replace(".integer", "int");
                                if (sentencias[i].Contains("->"))
                                    sentencias[i] = sentencias[i].Replace("->", "=");



                            }
                            catch (FormatException e)
                            {

                                tabla_errorres.agrega_error_l(0, i);

                            }
                            catch (IndexOutOfRangeException e)
                            {

                                tabla_errorres.agrega_error_l(10, i);
                                MessageBox.Show("Error en sintaxis");

                            }



                        }

                        else if (sentencias[i].Contains(".double") && !sintaxisCode.Contains(".double"))
                        {
                            sintaxisCode.Add(".double");

                            //para analisis semantico
                            string[] separanum;
                            separanum = sentencias[i].Split(' ');
                            try
                            {
                                //convierto la sintaxis de mi lenguaje al del c#
                                sentencias[i] = sentencias[i].Replace(".double", "double");
                                if (sentencias[i].Contains("->"))
                                    sentencias[i] = sentencias[i].Replace("->", "=");

                                double num;
                                num = double.Parse(separanum[3]);


                            }
                            catch (FormatException e)
                            {
                                tabla_errorres.agrega_error_l(0, i);

                            }
                            catch (IndexOutOfRangeException e)
                            {

                                tabla_errorres.agrega_error_l(10, i);
                                MessageBox.Show("Error en sintaxis");

                            }


                        }
                        else if (sentencias[i].Contains(".String") && !sintaxisCode.Contains(".String"))
                        {
                            sintaxisCode.Add(".String");
                            //convierto la sintaxis de mi lenguaje al del c#
                            sentencias[i] = sentencias[i].Replace(".String", "String");
                            if (sentencias[i].Contains("->"))
                                sentencias[i] = sentencias[i].Replace("->", "=");

                        }
                        else if (sentencias[i].Contains(".booleano") && !sintaxisCode.Contains(".booleano"))
                        {
                            sintaxisCode.Add(".booleano");

                            //para analisis semantico
                            string[] separavar;
                            separavar = sentencias[i].Split(' ');
                            try
                            {
                                sentencias[i] = sentencias[i].Replace(".booleano", "bool");
                                if (sentencias[i].Contains("->"))
                                    sentencias[i] = sentencias[i].Replace("->", "=");

                                bool var;
                                var = bool.Parse(separavar[3]);


                            }
                            catch (FormatException e)
                            {

                                tabla_errorres.agrega_error_l(0, i);
                            }

                        }
                        else if (sentencias[i].Contains("<<") && !sintaxisCode.Contains(".<<"))
                        {
                            sintaxisCode.Add(".<<");
                            sentencias[i] = sentencias[i].Replace(".<<", "//");
                            if (sentencias[i].Contains("->"))
                                sentencias[i] = sentencias[i].Replace("->", "=");
                        }
                        else if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s[a-z]|(\w)*\s\+\s(\w)*|\d(0,32000)*\s;$") && !sintaxisCode.Contains("->"))
                        {
                            sintaxisCode.Add("->");
                            MessageBox.Show("Es una sentecia de asignacion");
                            if (sentencias[i].Contains("->"))
                                sentencias[i] = sentencias[i].Replace("->", "=");

                            //para analisis semantico
                            string tpv1 = "";
                            string tpv2 = "";
                            string tpv3 = "";

                            string[] separavar;
                            separavar = sentencias[i].Split(' ');

                            if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\+\s(\w)*\s;$"))
                            {

                                foreach (var token in tabla_simb.llamatabla())
                                {
                                    if (token.Simbolo == separavar[0])
                                    {
                                        tpv1 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[2])
                                    {
                                        tpv2 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[4])
                                    {
                                        tpv3 = token.Tipo_Dato;
                                    }

                                }
                                if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                                {
                                    MessageBox.Show("el tipo de las variables son el mismo");
                                }
                            }
                            if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\-\s(\w)*\s;$"))
                            {

                                foreach (var token in tabla_simb.llamatabla())
                                {
                                    if (token.Simbolo == separavar[0])
                                    {
                                        tpv1 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[2])
                                    {
                                        tpv2 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[4])
                                    {
                                        tpv3 = token.Tipo_Dato;
                                    }

                                }
                                if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                                {
                                    MessageBox.Show("El tipo de las variables son iguales");
                                }
                            }
                            if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\/\s(\w)*\s;$"))
                            {

                                foreach (var token in tabla_simb.llamatabla())
                                {
                                    if (token.Simbolo == separavar[0])
                                    {
                                        tpv1 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[2])
                                    {
                                        tpv2 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[4])
                                    {
                                        tpv3 = token.Tipo_Dato;
                                    }

                                }
                                if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                                {
                                    MessageBox.Show("El tipo de las variables son iguales");
                                }
                            }
                            if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\*\s(\w)*\s;$"))
                            {

                                foreach (var token in tabla_simb.llamatabla())
                                {
                                    if (token.Simbolo == separavar[0])
                                    {
                                        tpv1 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[2])
                                    {
                                        tpv2 = token.Tipo_Dato;
                                    }
                                    if (token.Simbolo == separavar[4])
                                    {
                                        tpv3 = token.Tipo_Dato;
                                    }

                                }
                                if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                                {
                                    MessageBox.Show("El tipo de las variables son iguales");
                                }
                            }

                        }
                        else if (Regex.IsMatch(sentencias[i], @"^{$"))
                        {
                            MessageBox.Show("inicio de ambito");
                        }
                        else if (Regex.IsMatch(sentencias[i], @"^}$"))
                        {
                            MessageBox.Show("fin de ambito");
                        }
                        else if (sentencias[i].Contains(".si") && !sintaxisCode.Contains(".si"))
                        {
                            sintaxisCode.Add(".si");
                            sentencias[i] = sentencias[i].Replace(".si", "if");
                        }
                        else if (sentencias[i].Contains(".ent si") && !sintaxisCode.Contains(".ent si"))
                        {
                            sintaxisCode.Add(".ent si");
                            sentencias[i] = sentencias[i].Replace(".ent si", "else if");
                        }
                        else if (sentencias[i].Contains(".ent") && !sintaxisCode.Contains(".ent"))
                        {
                            sintaxisCode.Add(".ent");
                            sentencias[i] = sentencias[i].Replace(".ent", "else");
                        }
                        else if (sentencias[i].Contains(".switch") && !sintaxisCode.Contains(".switch"))
                        {
                            sintaxisCode.Add(".switch");
                            sentencias[i] = sentencias[i].Replace(".switch", "switch");
                        }
                        else if (sentencias[i].Contains(".caso") && !sintaxisCode.Contains(".caso"))
                        {
                            sintaxisCode.Add(".caso");
                            sentencias[i] = sentencias[i].Replace(".caso", "case");
                        }
                        else if (sentencias[i].Contains("break") && !sintaxisCode.Contains(".break"))
                        {
                            sintaxisCode.Add(".break");
                            sentencias[i] = sentencias[i].Replace(".break", "break");
                        }
                        else if (sentencias[i].Contains(".mientras") && !sintaxisCode.Contains(".mientras"))
                        {
                            sintaxisCode.Add(".mientras");
                            sentencias[i] = sentencias[i].Replace(".mientras", "while");
                        }

                        else if (sentencias[i].Contains(".imprim") && !sintaxisCode.Contains(".imprim"))
                        {
                            sintaxisCode.Add(".imprim");
                            sentencias[i] = sentencias[i].Replace(".imprim", "Console.WriteLine");

                        }

                        else
                        {
                            if (sentencias[i] != null)
                            {
                                tabla_errorres.agrega_error_l(9, i);
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < sentencias.Length; i++)
            {
                if (sentencias[i] != null)
                    codge.Text += sentencias[i];
            }


        }

        //BOTON COMPILAR
        private void button2_Click(object sender, EventArgs e)
		{

            tabla_simb = new tablaExtra();
            codge.Text = "";

            //inicializamos la tabla de errores
            tabla_errorres.inicialestaE();
            //funcion que se encarga de leer el texto y a la vez aplicar el analisis lexico 
            leer_texto(rTexto.Text);

            //esta funcion se encarga de unir los tokens de cada linea de codigo
            string[] sent = une_tokens();

            //se realiza la comparacion semantica de la tabla de simbolos
            tabla_simb.comparacion_semantic();

            //funcion que se encarga de realizar tanto el analisis sintactico como el semantico
            Analisis_Sint_Sem(sent);
        }
	}
}
