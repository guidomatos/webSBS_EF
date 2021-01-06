using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBS.ApplicationCore.DTO
{
    public class FiltroBusquedaUsuarioDto
    {
        public int RolId { get; set; }
        public string CodigoUsuario { get; set; }
    }
    public class BusquedaUsuarioDto
    {
        [JsonProperty(PropertyName = "UsuarioId")]
        public int UsuarioId { get; set; }
        [JsonProperty(PropertyName = "CodigoUsuario")]
        public string CodigoUsuario { get; set; }
        [JsonProperty(PropertyName = "PrimerNombre")]
        public string PrimerNombre { get; set; }
        [JsonProperty(PropertyName = "SegundoNombre")]
        public string SegundoNombre { get; set; }
        [JsonProperty(PropertyName = "ApellidoPaterno")]
        public string ApellidoPaterno { get; set; }
        [JsonProperty(PropertyName = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
    }
}
