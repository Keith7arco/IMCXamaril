using AppPrueba.Modelos;
using AppPrueba.VistasModelo;
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
    public partial class RegistrarUsuario : ContentPage
    {
        MVUsuario mvUsuario = new MVUsuario();
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtContrasena.Text;
            string email = txtCorreo.Text;
            if (string.IsNullOrEmpty(user))
            {
                await DisplayAlert("Alerta", "Por favor ingresa el usuario", "Ok"); ;
            }
            if (string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("Alerta", "Por favor ingresa la contrasena", "Ok"); ;
            }

            MUsuarios usuario = new MUsuarios();
            usuario.Usuario = user;
            usuario.Contrasena = pass;
            usuario.Correo = email;

            var isSaved = await mvUsuario.Save(usuario);
            if(isSaved)
            {
                await DisplayAlert("Informacion", "Usuario Registrado con Exito", "Ok"); ;
                Clear();
                await Navigation.PushAsync(new MenuPrincipal());
            }
            else
            {
                await DisplayAlert("Informacion", "El usuario no pudo ser Registrado", "Ok"); ;
            }
        }

        public void Clear()
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

    }
}