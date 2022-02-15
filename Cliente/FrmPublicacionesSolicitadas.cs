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
      DialogResult resultado = new DialogResult();
      Form mensaje;

      public FrmPublicacionesSolicitadas()
      {
         InitializeComponent();
         Listar();
         EnumerarSubastas();
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
      public void EnumerarSubastas()
      {
         List<TPISubastas.Dominio.Subasta> SubastasAbiertas = new List<TPISubastas.Dominio.Subasta>();
         List<TPISubastas.Dominio.Subasta> futurasSubastas = new List<TPISubastas.Dominio.Subasta>();
         var subastas = clienteSubasta.Listar();
         foreach (var item in subastas)
         {
            if (item.Habilitada)
            {
               if (item.FechaInicio <= DateTime.Now.Date && item.FechaCierre > DateTime.Now.Date)
                  SubastasAbiertas.Add(item);
            }
            if (item.Habilitada && item.FechaInicio > DateTime.Now.Date)
               futurasSubastas.Add(item);
         }
         lblSubastasAbiertas.Text = SubastasAbiertas.Count().ToString();
         lblFuturasSubastas.Text = futurasSubastas.Count().ToString();
      }

      public void DimensionarColumnas()
      {
         dgvPublicacionesSolicitadas.Columns[0].Width = 150; //IdSubastaProducto
         dgvPublicacionesSolicitadas.Columns[1].Width = 120; //IdSubasta
         dgvPublicacionesSolicitadas.Columns[2].Width = 400; //NombreProducto
         dgvPublicacionesSolicitadas.Columns[3].Width = 240; //MarcaProducto
         dgvPublicacionesSolicitadas.Columns[4].Width = 450; //DescripciónProducto
         dgvPublicacionesSolicitadas.Columns[5].Width = 140; //ImagenProducto
         dgvPublicacionesSolicitadas.Columns[6].Width = 140; //FormaPago 
         dgvPublicacionesSolicitadas.Columns[7].Width = 190; //MontoInicial
         dgvPublicacionesSolicitadas.Columns[8].Width = 140;  //IdUsuarioVendedor
         dgvPublicacionesSolicitadas.Columns[11].Width = 140; //IdEstadoSubasta

         dgvPublicacionesSolicitadas.Columns[0].ReadOnly = true; //IdSubastaProducto
         dgvPublicacionesSolicitadas.Columns[1].ReadOnly = true; //IdSubasta
         dgvPublicacionesSolicitadas.Columns[8].ReadOnly = true;  //IdUsuarioVendedor         
         dgvPublicacionesSolicitadas.Columns[12].ReadOnly = true; //Notificado
         dgvPublicacionesSolicitadas.Columns[13].ReadOnly = true; //Oferta final


         dgvPublicacionesSolicitadas.Columns[9].Visible = false; //IdUsuarioComprador
         dgvPublicacionesSolicitadas.Columns[8].HeaderText = "IdUsuarioVendedor";
         dgvPublicacionesSolicitadas.Columns[10].Visible = false; //IdProducto
      }
      private void btnGuardarCambios_Click(object sender, EventArgs e)
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

      private void btnEliminarSolicitud_Click(object sender, EventArgs e)
      {
         if (dgvPublicacionesSolicitadas.CurrentCell != null)
         {
            mensaje = new FrmInformation("¿Eliminar la solicitud?");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();              
               try
               {
                  int fila = dgvPublicacionesSolicitadas.CurrentCell.RowIndex;
                  var id = dgvPublicacionesSolicitadas.Rows[fila].Cells[0].Value.ToString();
                  cliente.Eliminar(int.Parse(id));
                  mensaje = new FrmSuccess("¡La solicitud seleccionada se ha ELIMINADO correctamente!");
                  resultado = mensaje.ShowDialog();
                  if (resultado == DialogResult.OK)
                  {
                     mensaje.Close();
                  }
                  Listar();
               }
               catch(Exception ex)
               {
                  mensaje = new FrmInformation("Ha ocurrido un error al eliminar la solicitud: " + ex.Message);
                  resultado = mensaje.ShowDialog();
                  if (resultado == DialogResult.OK)
                  {
                     mensaje.Close();
                  }
                  Listar();
               }
            }
         }
         else
         {
            mensaje = new FrmInformation("No se ha seleccionado ninguna solicitud");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
         }
      }

      private void btnAprobarSolicitud_Click(object sender, EventArgs e)
      {
         if (dgvPublicacionesSolicitadas.CurrentCell != null)
         {
            mensaje = new FrmInformation("¿Aprobar la solicitud?");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
               try
               {
                  int fila = dgvPublicacionesSolicitadas.CurrentCell.RowIndex;
                  var id = dgvPublicacionesSolicitadas.Rows[fila].Cells[0].Value.ToString();
                  var solicitud = cliente.Obtener(int.Parse(id));
                  solicitud.IdEstadoSubasta = ((int)TPISubastas.Dominio.Estados.Aprobado);
                  cliente.Actualizar(solicitud, id);
                  mensaje = new FrmSuccess("¡La solicitud seleccionada se ha APROBADO correctamente!");
                  resultado = mensaje.ShowDialog();
                  if (resultado == DialogResult.OK)
                  {
                     mensaje.Close();
                  }
                  Listar();
               }
               catch (Exception ex)
               {
                  mensaje = new FrmInformation("Ha ocurrido un error al aprobar la solicitud: " + ex.Message);
                  resultado = mensaje.ShowDialog();
                  if (resultado == DialogResult.OK)
                  {
                     mensaje.Close();
                  }
                  Listar();
               }
            }
         }
         else
         {
            mensaje = new FrmInformation("No se ha seleccionado ninguna solicitud");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
         }
      }
   }
}
