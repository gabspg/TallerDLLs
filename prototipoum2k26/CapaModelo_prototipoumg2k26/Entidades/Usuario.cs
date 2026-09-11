using System;

namespace CapaModelo_prototipoumg2k26.Entidades
{
    // Representa los datos de un usuario del sistema y contiene las propiedades
    // correspondientes a los campos de la tabla tbl_Usuario.
    public class Usuario
    {
        public int IdPK { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaUsuario { get; set; }
        public bool EstadoUsuario { get; set; }
        public DateTime FechaCreacionUsuario { get; set; }
        public int IdRolUsuario { get; set; }
    }
}