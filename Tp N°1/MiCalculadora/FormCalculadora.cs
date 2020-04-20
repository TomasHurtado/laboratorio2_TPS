using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {


        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbSigno.Items.Add("+");
            this.cmbSigno.Items.Add("-");
            this.cmbSigno.Items.Add("*");
            this.cmbSigno.Items.Add("/");

            FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }

        void Limpiar()
        {
            this.txbPriOperando.Text = "";
            this.txbSegOperando.Text = "";
            this.cmbSigno.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(this.txbPriOperando.Text, this.txbSegOperando.Text, this.cmbSigno.Text).ToString();
        }

        private void cmbSigno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            Entidades.Numero resultado = new Entidades.Numero();
            string aux;
            aux = resultado.DecimalBinario(this.lblResultado.Text);
            if (aux == "error")
            {
                MessageBox.Show(aux);

            }
            else
            {
                this.lblResultado.Text = aux;
            }


        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            Entidades.Numero resultado = new Entidades.Numero();

            if (lblResultado.Text == "" || lblResultado.Text == "error")
            {
                lblResultado.Text = "error";
            }
            else
            {
                lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text).ToString();
            }
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }
    }
}
