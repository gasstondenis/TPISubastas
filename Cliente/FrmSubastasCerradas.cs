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
    public partial class FrmSubastasCerradas : Form
    {

        private ClienteAPI<TPISubastas.Dominio.Subasta> cliente = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", "UsuarioPrueba", "Password1234");
        private ClienteAPI<TPISubastas.Dominio.SubastaProducto> clienteProductos = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", "UsuarioPrueba", "Password1234");

        public FrmSubastasCerradas()
        {
            InitializeComponent();
            ListarProductos();
            DimensionarColumnas();
        }

        public void ListarProductos()
        {
            try
            {
                List<TPISubastas.Dominio.Subasta> subastasCerradas = new List<TPISubastas.Dominio.Subasta>();
                var subastas = cliente.Listar();
                foreach (var item in subastas)
                {
                    if (item.FechaCierre <= DateTime.Now && !item.Habilitada)
                    {
                        subastasCerradas.Add(item);
                    }
                }

                lblProductosVendidos.Text = (ProductosVendidos(clienteProductos.Listar())).Count().ToString();
                lblCantidadSubastasCerradas.Text = subastasCerradas.Count().ToString();
                tablaSubastasCerradas.DataSource = subastasCerradas;

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
        private List<TPISubastas.Dominio.SubastaProducto> ProductosVendidos(List<TPISubastas.Dominio.SubastaProducto> productos)
        {
            List<TPISubastas.Dominio.SubastaProducto> productosVendidos = new List<TPISubastas.Dominio.SubastaProducto>();
            foreach (var item in productos)
            {
                if (item.IdEstadoSubasta == 3)
                {
                    productosVendidos.Add(item);
                }
            }
            return productosVendidos;
        }

        public void DimensionarColumnas()
        {
            tablaSubastasCerradas.Columns[0].Width = 80;
            tablaSubastasCerradas.Columns[1].Width = 150;
            tablaSubastasCerradas.Columns[2].Width = 150;
            tablaSubastasCerradas.Columns[3].Width = 150;
            tablaSubastasCerradas.Columns[4].Width = 100;
            tablaSubastasCerradas.Columns[5].Width = 300;
            tablaSubastasCerradas.Columns[6].Width = 500;
            tablaSubastasCerradas.Columns[7].Width = 100;
        }

    }
}
