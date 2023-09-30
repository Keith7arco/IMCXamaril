using AppPrueba.Modelos;
using AppPrueba.Servicios;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrueba.VistasModelo
{
    public class MVUsuario
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://appimc-fbe6f-default-rtdb.firebaseio.com/");

        public async Task<bool> Save(MUsuarios usuario)
        {
            var data=await firebaseClient.Child(nameof(MUsuarios)).PostAsync(JsonConvert.SerializeObject(usuario));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<MUsuarios>> GetAll()
        {
            return (await firebaseClient.Child(nameof(MUsuarios)).OnceAsync<MUsuarios>()).Select(item=>new MUsuarios
            {
                Correo=item.Object.Correo,
                Contrasena=item.Object.Contrasena,
                Usuario=item.Object.Usuario,
                idUsuario=item.Key
            }).ToList();
        }
    }
}
