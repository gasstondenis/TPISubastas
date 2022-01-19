using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPISubastas.Dominio;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cliente = new ClienteSubasta("https://localhost:44347/");
            /*
             subastagrid.DataSource = cliente.Listar();
             //var resultado = cliente.Listar();
             //var resultado = cliente.Obtener(3);
             //cliente.Eliminar(4);
             cliente.Agregar(new Subastas.Dominio.Subasta()
             {
                 Descripcion = "subasta creada desde el cliente",
                 Duracion = 10,
                 FechaCierre = DateTime.Now.AddDays(10),
                 FechaCreacion = DateTime.Now,
                 FechaInicio = DateTime.Now,
                 Habilitada = true, Nombre = "Subasta Remota"
             });
             cliente.Listar();*/


            try
            {
                subastagrid.DataSource = cliente.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void subastaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
