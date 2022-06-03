using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BD_Proyecto;

namespace BD_Proyecto
{
    public partial class Form1 : Form
    {
        Conexion1 nuevaConexion = new Conexion1();

        public Form1()
        {
            InitializeComponent();
        }

        public void Buscar()
        {
            String sql = " select* from datosestudiantes where `NUM CONTROL` =" + txtBoxnoControl.Text;
            DataRow fila = nuevaConexion.getRow(sql);

            if (fila != null) {

                txtBoxnombre.Text = fila["Nombre"].ToString();
                txtBoxapellidoPaterno.Text = fila["APELLIDO P"].ToString();
                txtBoxapellidoMaterno.Text = fila["APELLIDO M"].ToString();
                txtBoxsemestre.Text = fila["SEMESTRE"].ToString();
                txtBoxcorreo.Text = fila["CORREO"].ToString();
            }
            else
            {
                MessageBox.Show("---EL NUMERO DE CONTROL NO EXISTE---");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
