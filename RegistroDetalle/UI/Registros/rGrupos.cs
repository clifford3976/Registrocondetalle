using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle.UI.Registros
{
    public partial class rGrupos : Form
    {
        public rGrupos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GrupoIDnumericUpDown.Value);
            Grupos Grupo = BLL.GruposBLL.Buscar(id);

            if (Grupo != null)
            {
                LlenarCampos(Grupo);
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {

            GrupoIDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            GruposnumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            ComentariostextBox.Clear();


            DetalledataGridView.DataSource = null;
            errorProvider1.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Grupos Grupo;
            bool Paso = false;

            if (Errores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Grupo = LlenaClase();


            if (GrupoIDnumericUpDown.Value == 0)
                Paso = BLL.GruposBLL.Guardar(Grupo);
            else

                Paso = BLL.GruposBLL.Modificar(Grupo);


            if (Paso)
            {
                Nuevobutton.PerformClick();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GrupoIDnumericUpDown.Value);


            if (BLL.GruposBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<GruposDetalle> Detalle = new List<GruposDetalle>();

            if (DetalledataGridView.DataSource != null)
            {
                Detalle = (List<GruposDetalle>)DetalledataGridView.DataSource;
            }

            
            Detalle.Add(
                new GruposDetalle(
                    id: 0,
                    GrupoId: (int)GrupoIDnumericUpDown.Value,
                    PersonaId: (int)GrupoIDnumericUpDown.Value,
                    Cargo: (int) GrupoIDnumericUpDown.Value,
                    cantidad: (int)CantidadnumericUpDown.Value
                ));


            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = Detalle;
        }


        private Grupos LlenaClase()
        {
            Grupos Grupo = new Grupos();

            Grupo.GrupoId = Convert.ToInt32(GrupoIDnumericUpDown.Value);
            Grupo.Fecha = FechadateTimePicker.Value;
            Grupo.Descripcion = DescripciontextBox.Text;
            Grupo.grupos = Convert.ToInt32(GruposnumericUpDown.Value);
            Grupo.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            Grupo.Integrantes = Convert.ToInt32(IntegrantesnumericUpDown.Value);
            Grupo.Comentarios = ComentariostextBox.Text;


            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                Grupo.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["GrupoId"].Value),
                    ToInt(item.Cells["PersonaId"].Value),
                    ToInt(item.Cells["Cargo"].Value),
                    ToInt(item.Cells["Cantidad"].Value)
                  );

            }
            return Grupo;
        }

        private void LlenarCampos(Grupos Grupo)
        {
            GrupoIDnumericUpDown.Value = Grupo.GrupoId;
            FechadateTimePicker.Value = Grupo.Fecha;
            DescripciontextBox.Text = Grupo.Descripcion;
            GruposnumericUpDown.Value = Grupo.grupos;
            CantidadnumericUpDown.Value = Grupo.Cantidad;
            IntegrantesnumericUpDown.Value = Grupo.Integrantes;
            ComentariostextBox.Text = Grupo.Comentarios;


            DetalledataGridView.DataSource = Grupo.Detalle;


            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["GrupoId"].Visible = false;
        }



        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0
              && DetalledataGridView.CurrentRow != null)
            {

                List<GruposDetalle> Detalle
                    = (List<GruposDetalle>)DetalledataGridView.DataSource;

                Detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);


                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = Detalle;
            }
        }


        private bool Errores()
        {
            bool Errores = false;

            if (String.IsNullOrWhiteSpace(ComentariostextBox.Text))
            {
                errorProvider1.SetError(ComentariostextBox,
                    "No debes dejar el Comentario vacio");
                Errores = true;
            }

            if (DetalledataGridView.RowCount == 0)
            {
                errorProvider1.SetError(DetalledataGridView,
                    "Es obligatorio seleccionar las ciudades visitadas");
                Errores = true;
            }

            return Errores;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;

            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }
    }
}