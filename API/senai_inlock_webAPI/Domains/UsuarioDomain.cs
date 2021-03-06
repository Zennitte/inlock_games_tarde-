using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
