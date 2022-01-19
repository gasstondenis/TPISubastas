using Cliente.frmNotificaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class FrmSubastasAbiertas : Form
    {
        
        private ClienteAPI<TPISubastas.Dominio.Subasta> cliente = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", "UsuarioPrueba", "Password1234");
        public FrmSubastasAbiertas()
        {
            InitializeComponent();
            ListarProductos();
            DimensionarColumnas();
        }

        public void ListarProductos()
        {
            try
            {
                List<TPISubastas.Dominio.Subasta> subastasAbiertas = new List<TPISubastas.Dominio.Subasta>();
                var subastas = cliente.Listar();
                foreach (var item in subastas)
                {
                    if(item.FechaCierre > DateTime.Now && item.Habilitada)
                    {
                        subastasAbiertas.Add(item);
                    }
                }
                tablaSubastasAbiertas.DataSource = subastasAbiertas;
                         
            }
            catch (Exception ex)
            {
                DialogResult resultado = new DialogResult();
                Form mensaje = new FrmInformation("Ha ocurrido un error: " + ex);
                resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    mensaje.Close();

                }
            }
        }

        public void DimensionarColumnas()
        {
            tablaSubastasAbiertas.Columns[0].Width = 80;
            tablaSubastasAbiertas.Columns[1].Width = 150;
            tablaSubastasAbiertas.Columns[2].Width = 150;
            tablaSubastasAbiertas.Columns[3].Width = 150;
            tablaSubastasAbiertas.Columns[4].Width = 100;
            tablaSubastasAbiertas.Columns[5].Width = 300;
            tablaSubastasAbiertas.Columns[6].Width = 500;
            tablaSubastasAbiertas.Columns[7].Width = 100;
        }

        public void BuscarElementos(int id)
        {
            ClienteAPI<TPISubastas.Dominio.Subasta> clienteBusqueda = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", "UsuarioPrueba", "Password1234");
            try
            {

                tablaSubastasAbiertas.DataSource = clienteBusqueda.Obtener(id);
            }
            catch (Exception ex)
            {
                DialogResult resultado = new DialogResult();
                Form mensaje = new FrmInformation("Ha ocurrido un error: " + ex);
                resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    mensaje.Close();

                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            var caracter = int.Parse(txtBuscar.Text);

            BuscarElementos(caracter);
        }
    }
}
