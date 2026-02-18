using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Tarea6Semana6API.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        [ValidateNever]

        public string Nombres { get; set; }
        [JsonPropertyName("email")]

        public string Email { get; set; }
        [JsonPropertyName("contrasenia")]
        public string Contrasenia { get; set; }
    }
}
