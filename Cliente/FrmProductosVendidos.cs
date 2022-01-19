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
    public partial class FrmProductosVendidos : Form
    {
        private ClienteAPI<TPISubastas.Dominio.SubastaProducto> cliente = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", "UsuarioPrueba", "Password1234");
        public FrmProductosVendidos()
        {
            InitializeComponent();
            ListarProductos();
            DimensionarColumnas();
        }
        public void ListarProductos()
        {
            try
            {
                List<TPISubastas.Dominio.SubastaProducto> productosVendidos = new List<TPISubastas.Dominio.SubastaProducto>();
                var productos = cliente.Listar();
                foreach (var item in productos)
                {
                    if (item.IdEstadoSubasta == 3)
                    {
                        productosVendidos.Add(item);
                    }
                }
                tablaProductosVendidos.DataSource = productosVendidos;

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
            tablaProductosVendidos.Columns[0].Width = 100; //IdSubastaProducto
            tablaProductosVendidos.Columns[1].Width = 80; //IdSubasta
            tablaProductosVendidos.Columns[2].Width = 400; //NombreProducto
            tablaProductosVendidos.Columns[3].Width = 200; //MarcaProducto
            tablaProductosVendidos.Columns[4].Width = 450; //DescripciónProducto
            tablaProductosVendidos.Columns[5].Width = 100; //ImagenProducto
            tablaProductosVendidos.Columns[6].Width = 100; //FormaPago 
            tablaProductosVendidos.Columns[7].Width = 150; // MontoInicial
            tablaProductosVendidos.Columns[8].Width = 100;  //IdUsuarioVendedor
            tablaProductosVendidos.Columns[9].Width = 100; //IdUsuarioComprador
            tablaProductosVendidos.Columns[11].Width = 100; //IdEstadoSubasta

            tablaProductosVendidos.Columns[8].HeaderText = "IdUsuarioVendedor";
            tablaProductosVendidos.Columns[10].Visible = false;
        }

    }
}
