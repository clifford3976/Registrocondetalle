using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle.UI.Consultas
{
    public partial class cGrupos : Form
    {
        public cGrupos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            Expression<Func<Grupos, bool>> Filtro = p => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 1://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = p => p.GrupoId == id
                    && (p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value);
                    break;

                case 2:// Fecha
                    Filtro = p => p.Fecha.Equals(CriteriotextBox.Text)
                    && (p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value);
                    break;

                case 3:// Descripcion
                    Filtro = p => p.Descripcion.Contains(CriteriotextBox.Text)
                    && (p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value);
                    break;

                case 4:// Cantidad
                    Filtro = p => p.Cantidad.Equals(CriteriotextBox.Text)
                    && (p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value);
                    break;

                case 5:// Grupos
                    Filtro = p => p.grupos.Equals(CriteriotextBox.Text)
                    && (p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value);
                    break;

                case 6:// Integrantes
                    Filtro = p => p.Integrantes.Equals(CriteriotextBox.Text)
                    && (p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value);
                    break;
                case 7:// Comentarios
                    Filtro = p => p.Comentarios.Contains(CriteriotextBox.Text)
                    && (p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value);
                    break;
            }

            ConsultadataGridView.DataSource = BLL.GruposBLL.GetList(Filtro);
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {

        }
    }
}