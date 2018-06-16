using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rPersonas r = new UI.Registros.rPersonas();
            r.Show();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rGrupos r = new UI.Registros.rGrupos();
            r.Show();
        }

        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.cPersonas r = new UI.Consultas.cPersonas();
            r.Show();
        }

        private void gruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.cGrupos r = new UI.Consultas.cGrupos();
            r.Show();
        }
    }
}
