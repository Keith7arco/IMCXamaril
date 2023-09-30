using AppPrueba.Modelos;
using AppPrueba.Vistas;
using AppPrueba.VistasModelo;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrueba
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private FirebaseClient firebaseClient;
        MVUsuario MVUsuario = new MVUsuario();
        public LoginPage()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://appimc-fbe6f-default-rtdb.firebaseio.com/");
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string userVali="", passVali="";

            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Inicio de Sesion", "Ingrese correctamente el usuario", "OK");
            }
            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Inicio de Sesion", "Ingrese correctamente la contraseña", "OK");
            }

            var usuarios=await MVUsuario.GetAll();
            foreach (var usuar in usuarios)
            {
                if(usuar.Usuario == username)
                {
                    userVali= usuar.Usuario;
                    passVali = usuar.Contrasena;
                }
            }
           
            if (userVali == username && passVali == password)
            {
                await DisplayAlert("Inicio de Sesion", "Bienvenido " + username, "OK");
                await Navigation.PushAsync(new CalculadoraIMC());
            }
            else
            {
                await DisplayAlert("Inicio de Sesion", "Usuario o Contraseña Incorrectos", "OK");
            }
        }
    }
}