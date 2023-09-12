using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrueba.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculadoraIMC : ContentPage
    {
        int peso;
        double altura, resultado;
        string msg;
        public CalculadoraIMC()
        {
            InitializeComponent();
        }

        private void Calcular()
        {
            peso = Convert.ToInt32(txtPeso.Text);
            altura = Convert.ToDouble(txtAltura.Text);

            resultado = peso / ((altura/100)*(altura/100));
            if (resultado < 18.5)
            {
                msg = "Bajo Peso";
                imgMedidor.Source = "Bajo.png";
            }
            else if (resultado >= 18.5 && resultado <= 24.9)
            {
                msg = "Peso Normal";
                imgMedidor.Source = "bajomedio.png";
            }
            else if (resultado >= 25 && resultado <= 29.9)
            {
                msg = "SobrePeso";
                imgMedidor.Source = "mitad.png";
            }
            else if (resultado >= 30 && resultado <= 34.9)
            {
                msg = "Obesidad Tipo 1";
                imgMedidor.Source = "medioalto.png";
            }
            else if (resultado >= 35 && resultado <= 39.9)
            {
                msg = "Obesidad Tipo 2";
                imgMedidor.Source = "alto.png";
            }
            else { 
                msg = "Obesidad Tipo 3";
                imgMedidor.Source = "alto.png";
            }

            lblResultado.Text = resultado.ToString("N1");
            lblCategoria.Text = msg;
            DisplayAlert("Resultados del IMC", "Usted Tiene "+msg, "OK");
        }

        private void Validar()
        {
            if(!string.IsNullOrEmpty(txtPeso.Text) && !string.IsNullOrEmpty(txtAltura.Text))
            {
                Calcular();
            }
            else
            {
                DisplayAlert("Error", "Ingrese los Datos Correctamente", "OK");
            }
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            Validar();
        }

        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            txtAltura.Text = string.Empty;
            txtPeso.Text = string.Empty;
            lblResultado.Text = " --- ";
            lblCategoria.Text = " --- ";
            imgMedidor.Source = "mitad.png";
        }

        private void btnAtras_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}