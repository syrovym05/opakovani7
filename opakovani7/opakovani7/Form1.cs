using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opakovani7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Text = "ukol 7";
            this.ShowIcon = false;
            this.BackColor = Color.DodgerBlue;
            this.ForeColor = Color.White;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamReader sr = null;
            try
            {
                int n = int.Parse(textBox1.Text);
                sr = new StreamReader("cisla.txt", Encoding.GetEncoding("Windows-1250"));

                int iterace = 1;
                long cislo = 0;

                while (!sr.EndOfStream)
                {
                    if (iterace == 5)
                    {
                        cislo = Convert.ToInt64(sr.ReadLine());
                        break;
                    }
                    else sr.ReadLine();
                    iterace++;
                }


                label2.Text = "Mocnina: "+cislo + "^" + n + " = ";
                
               

                if (n == 0) label2.Text += "1";
                else if (n < 0)
                {
                    n = -n;
                    double vysledek = 1;
                    for (int i = 0; i < n; i++)
                    {
                        checked { vysledek /= (double)cislo; }
                    }
                    label2.Text += vysledek.ToString();
                    n = -n;
                }
                else
                {
                    long vysledek = cislo;
                    for (int i = 1; i < n; i++)
                    {
                        checked { vysledek *= cislo; }
                    }
                    label2.Text += vysledek.ToString();
                }

                label3.Text = "Realny: " + cislo + "/" + n + " = ";
                label4.Text = "Celociselny: " + cislo + "/" + n + " = ";
                checked
                {
                    double realny = Math.Round((double)cislo / (double)n,8);
                    int celo = (int)cislo / n;
                    label3.Text += realny.ToString();
                    label4.Text += celo.ToString();
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                MessageBox.Show(ex.Message);           
            }
            catch (DivideByZeroException ex)
            {
                label3.Text = "";
                label4.Text = "";
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
    }
}
