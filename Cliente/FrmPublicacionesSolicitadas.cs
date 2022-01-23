using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliente.frmNotificaciones;
using Cliente.LoginModel;

namespace Cliente
{
   public partial class FrmPublicacionesSolicitadas : Form
   {
      private ClienteAPI<TPISubastas.Dominio.SubastaProducto> cliente = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.Subasta> clienteSubasta = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", User.Usuario, User.Contraseña);
      public FrmPublicacionesSolicitadas()
      {
         InitializeComponent();
         Listar();
         EnumerarSubastasAbiertas();
         DimensionarColumnas();
      }

      public void Listar()
      {
         try
         {

            List<TPISubastas.Dominio.SubastaProducto> publicacionesSolicitadas = new List<TPISubastas.Dominio.SubastaProducto>();


            var solicitudes = cliente.Listar();
            foreach (var item in solicitudes)
            {
               if (item.IdEstadoSubasta == 1)
               {
                  publicacionesSolicitadas.Add(item);
               }
            }
            dgvPublicacionesSolicitadas.DataSource = publicacionesSolicitadas;
            lblTotalSolicitudes.Text = publicacionesSolicitadas.Count().ToString();

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
      public void EnumerarSubastasAbiertas()
      {
         List<TPISubastas.Dominio.Subasta> SubastasAbiertas = new List<TPISubastas.Dominio.Subasta>();
         var subastas = clienteSubasta.Listar();
         foreach (var item in subastas)
         {
            if (item.Habilitada)
            {
               SubastasAbiertas.Add(item);
            }
         }
         lblSubastasAbiertas.Text = SubastasAbiertas.Count().ToString();

      }

      public void DimensionarColumnas()
      {
         dgvPublicacionesSolicitadas.Columns[0].Width = 100; //IdSubastaProducto
         dgvPublicacionesSolicitadas.Columns[1].Width = 80; //IdSubasta
         dgvPublicacionesSolicitadas.Columns[2].Width = 400; //NombreProducto
         dgvPublicacionesSolicitadas.Columns[3].Width = 200; //MarcaProducto
         dgvPublicacionesSolicitadas.Columns[4].Width = 450; //DescripciónProducto
         dgvPublicacionesSolicitadas.Columns[5].Width = 100; //ImagenProducto
         dgvPublicacionesSolicitadas.Columns[6].Width = 100; //FormaPago 
         dgvPublicacionesSolicitadas.Columns[7].Width = 150; //MontoInicial
         dgvPublicacionesSolicitadas.Columns[8].Width = 100;  //IdUsuarioVendedor
         
         dgvPublicacionesSolicitadas.Columns[11].Width = 100; //IdEstadoSubasta


         dgvPublicacionesSolicitadas.Columns[9].Visible = false; //IdUsuarioComprador
         dgvPublicacionesSolicitadas.Columns[8].HeaderText = "IdUsuarioVendedor";
         dgvPublicacionesSolicitadas.Columns[10].Visible = false; //IdProducto
      }

      private void btnAplicarCambios_Click(object sender, EventArgs e)
      {
         List<TPISubastas.Dominio.SubastaProducto> aux = new List<TPISubastas.Dominio.SubastaProducto>();
         List<TPISubastas.Dominio.SubastaProducto> publicacionesSolicitadas = new List<TPISubastas.Dominio.SubastaProducto>();
         TPISubastas.Dominio.SubastaProducto publicacionSolicitada = new TPISubastas.Dominio.SubastaProducto();

         aux = (List<TPISubastas.Dominio.SubastaProducto>)dgvPublicacionesSolicitadas.DataSource;

         foreach (var item in aux)
         {
            string id = item.IdSubastaProducto.ToString();
            cliente.Actualizar(item, id);
         }
         Listar();
         
      }
   }
}
