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
    public partial class rPersonas : Form
    {
        public rPersonas()
        {
            InitializeComponent();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombrestextBox.Clear();
            CedulamaskedTextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
            errorProvider1.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Personas Persona;
            bool Paso = false;

            if (!Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Persona = LlenaClase();

           
            if (IdnumericUpDown.Value == 0)
                Paso = BLL.PersonasBLL.Guardar(Persona);
            else
               
                Paso = BLL.PersonasBLL.Modificar(Persona);

           
            if (Paso)
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

        
            if (BLL.PersonasBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Personas Persona = BLL.PersonasBLL.Buscar(id);

            if (Persona != null)
            {
                FechadateTimePicker.Value = Persona.Fecha;
                NombrestextBox.Text = Persona.Nombres;
                CedulamaskedTextBox.Text = Persona.Cedula;
                DirecciontextBox.Text = Persona.Direccion;
                TelefonomaskedTextBox.Text = Persona.Telefono;
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Personas LlenaClase()
        {
            Personas Persona = new Personas();

            Persona.PersonaId = Convert.ToInt32(IdnumericUpDown.Value);
            Persona.Fecha = FechadateTimePicker.Value;
            Persona.Nombres = NombrestextBox.Text;
            Persona.Cedula = CedulamaskedTextBox.Text;
            Persona.Direccion = DirecciontextBox.Text;
            Persona.Telefono = TelefonomaskedTextBox.Text;

            return Persona;
        }

        private bool Validar()
        {
            bool Errores = false;
            
            if (String.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                errorProvider1.SetError(TelefonomaskedTextBox,
                    "No debes dejar el nombre vacio");
                Errores = true;
            }

            return Errores;
        }
    }
}
