using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_ComboI.Repositorios
{
    // Se encarga de obtener los datos de la base de datos para el funcionamiento del ComboBox Inteligente.
    public class RepositorioComboI : Repositorio
    {


        public DataTable obtenerDatos(string _tabla, string _campo1, string _campo2)
        {

            string sql = "SELECT " + _campo1 + "," + _campo2 + " FROM " + _tabla + ";";

            OdbcCommand command = new OdbcCommand(sql, ObtenerConexion());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dtDatos = new DataTable();
            adaptador.Fill(dtDatos);
            return dtDatos;
        }
    }
}
