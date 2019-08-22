using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaConexion1
{
    public partial class Form1 : Form
    {
        Conection c = new Conection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbtAgregar.Select();
            c.mostrarDatos(dgvPersonas);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(c.insertar(Convert.ToInt32(txtId.Text), txtNombre.Text, txtApellidos.Text, dtFechaNacimiento.Text));
            c.mostrarDatos(dgvPersonas);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void rbtAgregar_CheckedChanged(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void rbtModificar_CheckedChanged(object sender, EventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = false;
        }

        private void rbtEliminar_CheckedChanged(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = true;
            btnAgregar.Enabled = false;
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;
            dtFechaNacimiento.Enabled = false;
        }
    }
}
