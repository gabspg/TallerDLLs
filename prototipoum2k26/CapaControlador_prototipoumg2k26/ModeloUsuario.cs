using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using CapaModelo_prototipoumg2k26.Repositorios;

namespace CapaControlador_prototipoumg2k26
{
    // Se encarga de gestionar la información de los usuarios y realizar las operaciones
    // de agregar, modificar, eliminar, consultar y buscar usuarios en el sistema.
    public class ModeloUsuario
    {
        private int _idPK;
        private string _nombreUsuario;
        private string _contrasenaUsuario;
        private bool _estadoUsuario;
        private DateTime _fechaCreacionUsuario;
        private int _idRolUsuario;

        private IRepositorioUsuario RepositorioUsuario;
        private List<ModeloUsuario> ListaUsuarios;

        public EstadoEntidad Estado { private get; set; }

        public int IdPK
        {
            get => _idPK;
            set => _idPK = value;
        }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "El nombre de usuario debe tener entre 3 y 50 caracteres")]
        public string NombreUsuario
        {
            get => _nombreUsuario;
            set => _nombreUsuario = value;
        }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string ContrasenaUsuario
        {
            get => _contrasenaUsuario;
            set => _contrasenaUsuario = value;
        }

        public bool EstadoUsuario
        {
            get => _estadoUsuario;
            set => _estadoUsuario = value;
        }

        public DateTime FechaCreacionUsuario
        {
            get => _fechaCreacionUsuario;
            set => _fechaCreacionUsuario = value;
        }

        public int IdRolUsuario
        {
            get => _idRolUsuario;
            set => _idRolUsuario = value;
        }

        public ModeloUsuario()
        {
            RepositorioUsuario = new RepositorioUsuario();
        }

        public string GrabarCambios()
        {
            string mensaje = null;

            try
            {
                var modeloDatosUsuario = new Usuario();

                modeloDatosUsuario.IdPK = _idPK;
                modeloDatosUsuario.NombreUsuario = _nombreUsuario;
                modeloDatosUsuario.ContrasenaUsuario = _contrasenaUsuario;
                modeloDatosUsuario.EstadoUsuario = _estadoUsuario;
                modeloDatosUsuario.FechaCreacionUsuario = _fechaCreacionUsuario;
                modeloDatosUsuario.IdRolUsuario = _idRolUsuario;

                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        RepositorioUsuario.Agregar(modeloDatosUsuario);
                        mensaje = "Grabación exitosa";
                        break;

                    case EstadoEntidad.Modified:
                        RepositorioUsuario.Editar(modeloDatosUsuario);
                        mensaje = "Actualización exitosa";
                        break;

                    case EstadoEntidad.Deleted:
                        RepositorioUsuario.Remover(modeloDatosUsuario);
                        mensaje = "Eliminación exitosa";
                        break;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }

            return mensaje;
        }

        public List<ModeloUsuario> GetAll()
        {
            var modeloDatosUsuarios = RepositorioUsuario.GetAll();

            ListaUsuarios = new List<ModeloUsuario>();

            foreach (Usuario item in modeloDatosUsuarios)
            {
                ListaUsuarios.Add(new ModeloUsuario
                {
                    _idPK = item.IdPK,
                    _nombreUsuario = item.NombreUsuario,
                    _contrasenaUsuario = item.ContrasenaUsuario,
                    _estadoUsuario = item.EstadoUsuario,
                    _fechaCreacionUsuario = item.FechaCreacionUsuario,
                    _idRolUsuario = item.IdRolUsuario
                });
            }

            return ListaUsuarios;
        }

        public IEnumerable<ModeloUsuario> FindbyId(string filter)
        {
            if (ListaUsuarios == null)
                GetAll();

            if (string.IsNullOrWhiteSpace(filter))
                return ListaUsuarios;

            return ListaUsuarios.FindAll(e =>
                (e.NombreUsuario != null &&
                 e.NombreUsuario.ToLower().Contains(filter.ToLower()))
            );
        }
    }
}