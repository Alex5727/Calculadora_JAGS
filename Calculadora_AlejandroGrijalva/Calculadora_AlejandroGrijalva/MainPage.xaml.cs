using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static System.Net.Mime.MediaTypeNames;

namespace Calculadora_AlejandroGrijalva
{
    public partial class MainPage : ContentPage
    {
        double Resultado = 0;
        int con = 0;

        public MainPage()
        {

            InitializeComponent();
        }

        public void Precionar(object sender, EventArgs e)
        {
            if (Respuesta.Text == "SintaxError" || Respuesta.Text == "Infinito")
            {
                Respuesta.Text = "";
            }
            else
            {
                var button = sender as Button;

                string parametro = button.CommandParameter.ToString();

                Respuesta.Text = Respuesta.Text + parametro;

                con = con + 1;
            }

        }

        public void Precionar_Punto(object sender, EventArgs e)
        {
            if (Respuesta.Text == "SintaxError" || Respuesta.Text == "Infinito")
            {
                Respuesta.Text = "";

            }
            else
            {
                if (con == 0)
                {
                    Respuesta.Text = "0.";
                }

                string input = Respuesta.Text;
                bool puntoEncontrado = false;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    char currentChar = input[i];

                    if (currentChar == '+' || currentChar == '-' || currentChar == '*' || currentChar == '/')
                    {
                        Respuesta.Text += ".";
                        return;
                    }
                    if (currentChar == '.')
                    {
                        puntoEncontrado = true;
                        break;
                    }

                }


                if (!puntoEncontrado)
                {
                    var button = sender as Button;

                    string parametro = button.CommandParameter.ToString();

                    Respuesta.Text = Respuesta.Text + parametro;
                }

            }

        }


        public void Operador(object sender, EventArgs e)
        {
            if (Respuesta.Text == "SintaxError" || Respuesta.Text == "Infinito")
            {
                Respuesta.Text = "";
            }
            else if (Respuesta.Text.EndsWith("+") || Respuesta.Text.EndsWith("X") || Respuesta.Text.EndsWith("-") || Respuesta.Text.EndsWith("/"))
            {
                Respuesta.Text = Respuesta.Text.Substring(0, Respuesta.Text.Length - 1);

                var button = sender as Button;

                string parametro = button.CommandParameter.ToString();

                Respuesta.Text = Respuesta.Text + parametro;
                con = con + 1;
            }
            else
            {
                var button = sender as Button;

                string parametro = button.CommandParameter.ToString();

                Respuesta.Text = Respuesta.Text + parametro;
                con = con + 1;
            }
        }




        public void Responder3(object sender, EventArgs e)//3333333333333333333333333333333333333333333333333333333333
        {
            if (Respuesta.Text != "" && !Respuesta.Text.EndsWith("+") && !Respuesta.Text.EndsWith("X") && !Respuesta.Text.EndsWith("-") && !Respuesta.Text.EndsWith("/") && !Respuesta.Text.StartsWith("+") && !Respuesta.Text.StartsWith("X") && !Respuesta.Text.StartsWith("-") && !Respuesta.Text.StartsWith("/"))
            {
                string[] numeros = Respuesta.Text.Split('+', '-', '/', 'X');


                List<double> listaNumeros = new List<double>();
                string[] operadores = Respuesta.Text.Split('1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.');
                List<string> listaOperadores = new List<string>();
                string Respuesta2 = Respuesta.Text;

                foreach (char ope in Respuesta.Text)
                {
                    if (ope == '+' || ope == '-' || ope == '/' || ope == 'X')
                    {
                        listaOperadores.Add(ope.ToString());
                    }
                }

                if (listaOperadores.Count == 0)
                {
                    Respuesta.Text = Respuesta.Text;
                }
                else
                {

                    foreach (string numero in numeros)
                    {
                        if (double.TryParse(numero, out double valor))
                        {
                            if (numero == ".")
                            {
                                listaNumeros.Add(0);
                            }
                            else
                            {
                                listaNumeros.Add(valor);
                            }
                        }
                        else
                        {
                            Respuesta.Text = "2015";
                        }
                    }
                    Resultado = listaNumeros[0];
                    listaNumeros.RemoveAt(0);

                    int aa = listaOperadores.Count;

                    for (int l = 0; l < aa; l++)
                    {
                        if (listaOperadores.Contains("X"))
                        {
                            int primer = listaOperadores.IndexOf("X");
                            int segundo = primer;
                            primer = primer - 1;

                            if (listaNumeros.Count <= 1)
                            {
                                Resultado = Resultado * listaNumeros[0];
                                listaNumeros.RemoveAt(0);
                            }
                            else
                            {
                                if (listaOperadores[0] == "X")
                                {
                                    Resultado = Resultado * listaNumeros[0];
                                    listaNumeros.RemoveAt(0);
                                }
                                else
                                {
                                    double Resultadooo = listaNumeros[primer] * listaNumeros[segundo];
                                    listaNumeros.RemoveAt(primer);
                                    listaNumeros[primer] = Resultadooo;


                                }
                            }
                            listaOperadores.RemoveAt(segundo);
                        }
                        else if (listaOperadores.Contains("/"))
                        {
                            int primer = listaOperadores.IndexOf("/");
                            int segundo = primer;
                            primer = primer - 1;

                            if (listaNumeros.Count <= 1)
                            {
                                Resultado = Resultado / listaNumeros[0];
                                listaNumeros.RemoveAt(0);
                            }
                            else
                            {
                                if (listaOperadores[0] == "/")
                                {
                                    Resultado = Resultado / listaNumeros[0];
                                    listaNumeros.RemoveAt(0);

                                }
                                else
                                {
                                    double Resultadooo = listaNumeros[primer] * listaNumeros[segundo];
                                    listaNumeros.RemoveAt(primer);
                                    listaNumeros[primer] = Resultadooo;

                                }
                            }
                            listaOperadores.RemoveAt(segundo);
                        }
                        else if (listaOperadores[0] == "+")
                        {
                            Resultado = Resultado + listaNumeros[0];
                            listaNumeros.RemoveAt(0);
                            listaOperadores.RemoveAt(0);
                        }
                        else if (listaOperadores[0] == "-")
                        {
                            Resultado = Resultado - listaNumeros[0];
                            listaNumeros.RemoveAt(0);
                            listaOperadores.RemoveAt(0);
                        }
                        else
                        {
                            Resultado = Resultado;
                        }
                    }

                    Respuesta.Text = Resultado.ToString();
                    listaNumeros.Clear();
                }
            }
            else
            {
                Respuesta.Text = "SintaxError";
            }

        }



        public void Quitar(object sender, EventArgs e)
        {
            if (Respuesta.Text == "SintaxError" || Respuesta.Text == "Infinito")
            {
                Respuesta.Text = "";
            }
            else
            {
                if (Respuesta.Text.Length > 0)
                {
                    //  string a = Respuesta.Text = Respuesta.Text.Substring(0, Respuesta.Text.Length - 1);

                    Respuesta.Text = Respuesta.Text.Substring(0, Respuesta.Text.Length - 1);
                    con = con - 1;
                }
            }
        }

        public void Borrar(object sender, EventArgs e)
        {
            Respuesta.Text = "";

            con = 0;
        }


    }
}
