using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    // Se encarga de realizar las operaciones CRUD de los usuarios en la base de datos Tbl_Usuario.
    // Permite agregar, editar, eliminar y consultar los usuarios registrados.
    public class RepositorioUsuario : RepositorioMaestro, IRepositorioUsuario
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioUsuario()
        {
            selectAll = "SELECT IdUsuario, NombreUsuario, ContrasenaUsuario, EstadoUsuario, FechaCreacionUsuario, IdRol_Usuario FROM Tbl_Usuario";

            insert = "INSERT INTO Tbl_Usuario (NombreUsuario, ContrasenaUsuario, IdRol_Usuario) VALUES (?, ?, ?)";

            update = "UPDATE Tbl_Usuario SET NombreUsuario=?, ContrasenaUsuario=?, IdRol_Usuario=? WHERE IdUsuario=?";

            delete = "DELETE FROM Tbl_Usuario WHERE IdUsuario=?";
        }

        public int Agregar(Usuario entidad)
        {
            var _parametros = new List<OdbcParameter>();

            _parametros.Add(new OdbcParameter("p_NombreUsuario", entidad.NombreUsuario));
            _parametros.Add(new OdbcParameter("p_ContrasenaUsuario", entidad.ContrasenaUsuario));
            _parametros.Add(new OdbcParameter("p_IdRolUsuario", entidad.IdRolUsuario));

            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Editar(Usuario entidad)
        {
            var _parametros = new List<OdbcParameter>();

            _parametros.Add(new OdbcParameter("p_NombreUsuario", entidad.NombreUsuario));
            _parametros.Add(new OdbcParameter("p_ContrasenaUsuario", entidad.ContrasenaUsuario));
            _parametros.Add(new OdbcParameter("p_IdRolUsuario", entidad.IdRolUsuario));
            _parametros.Add(new OdbcParameter("p_IdUsuario", entidad.IdPK));

            return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }

        public int Remover(Usuario entidad)
        {
            var _parametros = new List<OdbcParameter>();

            _parametros.Add(new OdbcParameter("p_IdUsuario", entidad.IdPK));

            return EjecucionNonQuery(delete, _parametros, CommandType.Text);
        }

        public IEnumerable<Usuario> GetAll()
        {
            var lstUsuario = new List<Usuario>();

            var tblTabla = EjecucionConsulta(selectAll, CommandType.Text);

            if (tblTabla != null)
            {
                foreach (DataRow row in tblTabla.Rows)
                {
                    var usuario = new Usuario();

                    usuario.IdPK = Convert.ToInt32(row[0]);
                    usuario.NombreUsuario = row[1].ToString();
                    usuario.ContrasenaUsuario = row[2].ToString();
                    usuario.EstadoUsuario = Convert.ToBoolean(row[3]);
                    usuario.FechaCreacionUsuario = Convert.ToDateTime(row[4]);
                    usuario.IdRolUsuario = Convert.ToInt32(row[5]);

                    lstUsuario.Add(usuario);
                }

                tblTabla.Clear();
                tblTabla = null;
            }

            return lstUsuario;
        }
    }
}