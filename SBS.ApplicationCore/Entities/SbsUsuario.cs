using System;
using System.Collections.Generic;

namespace SBS.ApplicationCore.Entities
{
    public partial class SbsUsuario
    {
        public int Usuarioid { get; set; }
        public byte Rolid { get; set; }
        public string Codigousuario { get; set; }
        public string Clavesecreta { get; set; }
        public string Email { get; set; }
        public string Apellidopaterno { get; set; }
        public string Apellidomaterno { get; set; }
        public string Primernombre { get; set; }
        public string Segundonombre { get; set; }
        public string Alias { get; set; }
        public bool? Primeravezlogin { get; set; }
        public bool Activo { get; set; }
    }
}
