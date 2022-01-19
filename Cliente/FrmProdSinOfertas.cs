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
    public partial class FrmProdSinOfertas : Form
    {
        private ClienteAPI<TPISubastas.Dominio.SubastaProducto> cliente = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", "UsuarioPrueba", "Password1234");
        public FrmProdSinOfertas()
        {
            InitializeComponent();
            ListarProductos();
            DimensionarColumnas();
        }
        public void ListarProductos()
        {
            try
            {
                List<TPISubastas.Dominio.SubastaProducto> productosSinOferta = new List<TPISubastas.Dominio.SubastaProducto>();
                var productos = cliente.Listar();
                foreach (var item in productos)
                {
                    if (item.IdEstadoSubasta == 5)
                    {
                        productosSinOferta.Add(item);
                    }
                }
                dgvProductosSinOfertas.DataSource = productosSinOferta;

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
            dgvProductosSinOfertas.Columns[0].Width = 100; //IdSubastaProducto
            dgvProductosSinOfertas.Columns[1].Width = 80; //IdSubasta
            dgvProductosSinOfertas.Columns[2].Width = 400; //NombreProducto
            dgvProductosSinOfertas.Columns[3].Width = 200; //MarcaProducto
            dgvProductosSinOfertas.Columns[4].Width = 450; //DescripciónProducto
            dgvProductosSinOfertas.Columns[5].Width = 100; //ImagenProducto
            dgvProductosSinOfertas.Columns[6].Width = 100; //FormaPago 
            dgvProductosSinOfertas.Columns[7].Width = 150; // MontoInicial
            dgvProductosSinOfertas.Columns[8].Width = 100;  //IdUsuarioVendedor
            dgvProductosSinOfertas.Columns[9].Width = 100; //IdUsuarioComprador
            dgvProductosSinOfertas.Columns[11].Width = 100; //IdEstadoSubasta

            dgvProductosSinOfertas.Columns[8].HeaderText = "IdUsuarioVendedor";
            dgvProductosSinOfertas.Columns[10].Visible = false;
        }

    }
}

