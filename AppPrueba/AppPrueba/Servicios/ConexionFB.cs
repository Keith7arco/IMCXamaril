using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrueba.Servicios
{
    public class ConexionFB
    {
        public static FirebaseClient firebaseClient = new FirebaseClient("https://appimc-fbe6f-default-rtdb.firebaseio.com/");
    }
}
