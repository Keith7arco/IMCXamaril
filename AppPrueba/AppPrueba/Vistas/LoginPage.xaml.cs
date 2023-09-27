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
        public LoginPage()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://appimc-fbe6f-default-rtdb.firebaseio.com/");
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            var user = (await firebaseClient
                .Child("MUsuarios")
                .OrderBy("Usuario")
                .EqualTo(username)
                .OnceSingleAsync<MUsuarios>()) ?? new MUsuarios();

            if (user.Contrasena == password)
            {
                await DisplayAlert("Inicio de Sesion", "Bienvenido" + user.Usuario, "OK");
                await Navigation.PushAsync(new CalculadoraIMC());
            }
            else
            {
                await DisplayAlert("Inicio de Sesion", "Bienvenido", "OK");
                await Navigation.PushAsync(new CalculadoraIMC());
            }
        }
    }
}