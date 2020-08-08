using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Comun.cache
{
    public static class LoginUsuarioCache
    {   
            public static int UserId { get; set; }
             public static string UserName { get; set; }
              public static string PassWord { get; set; }
            public static string Nombre { get; set; }
            public static string Apellido { get; set; }
            public static string Posicion { get; set; }
            public static string Email { get; set; }
    }
}
