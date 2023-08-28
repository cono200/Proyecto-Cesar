﻿using System.ComponentModel.DataAnnotations;

namespace FinaliPB.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Contraseña { get; set; }


    }
}
