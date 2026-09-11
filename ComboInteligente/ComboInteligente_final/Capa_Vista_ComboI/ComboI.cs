using Capa_Controlador_ComboI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_ComboI
{
    public partial class ComboI : UserControl
    {
        ModeloComboI controlador = new ModeloComboI();

        public ComboI()
        {
            InitializeComponent();
        }

        public object SelectedValue
        {
            get { return cboPrueba.SelectedValue; }
            set { cboPrueba.SelectedValue = value; }
        }

        public object SelectedItem
        {
            get { return cboPrueba.SelectedItem; }
            set { cboPrueba.SelectedItem = value; }
        }

        public int SelectedIndex
        {
            get { return cboPrueba.SelectedIndex; }
            set { cboPrueba.SelectedIndex = value; }
        }

        public void llenarCombo(string _tabla, string _campo1, string _campo2)
        {
            var dtTabla = controlador.enviarDatos(_tabla, _campo1, _campo2);

            cboPrueba.DataSource = null;

            if (dtTabla != null && dtTabla.Columns.Count >= 2)
            {
                // Busca si existen los nombres pasados por parámetro; si no, asigna automáticamente por posición de columna
                string colValue = dtTabla.Columns.Contains(_campo1) ? _campo1 : dtTabla.Columns[0].ColumnName;
                string colDisplay = dtTabla.Columns.Contains(_campo2) ? _campo2 : dtTabla.Columns[1].ColumnName;

                cboPrueba.ValueMember = colValue;
                cboPrueba.DisplayMember = colDisplay;
                cboPrueba.DataSource = dtTabla;

                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                foreach (DataRow row in dtTabla.Rows)
                {
                    coleccion.Add(Convert.ToString(row[colValue]) + "-" + Convert.ToString(row[colDisplay]));
                    coleccion.Add(Convert.ToString(row[colDisplay]) + "-" + Convert.ToString(row[colValue]));
                }
                cboPrueba.AutoCompleteCustomSource = coleccion;
                cboPrueba.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboPrueba.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
    }
}