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
   public partial class FrmFuturasSubastas : Form
   {
      private ClienteAPI<TPISubastas.Dominio.Subasta> cliente = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.SubastaProducto> clienteProducto = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", User.Usuario, User.Contraseña);

      DialogResult resultado = new DialogResult();
      Form mensaje = null;
      public FrmFuturasSubastas()
      {
         InitializeComponent();
         ListarSubastas();
         ListarSolicitudes();         
      }


      public void ListarSubastas()
      {
         try
         {
            List<TPISubastas.Dominio.Subasta> futurasSubastas = new List<TPISubastas.Dominio.Subasta>();
            List<TPISubastas.Dominio.Subasta> subastasAbiertas = new List<TPISubastas.Dominio.Subasta>();

            //Listado de futuras subastas:
            var subastas = cliente.Listar();
            foreach (var item in subastas)
            {
               if (item.FechaInicio > DateTime.Now && item.Habilitada)
               {
                  futurasSubastas.Add(item);
               }
            }
            dgvFuturasSubastas.DataSource = futurasSubastas;
            DimensionarColumnas();

            //Listado de subastas abiertas:
            foreach(var item in subastas)
            {
               if(item.FechaCierre > DateTime.Now.Date && item.FechaInicio <= DateTime.Now.Date && item.Habilitada)
               {
                  subastasAbiertas.Add(item);
               }
            }
            lblSubastasAbiertas.Text = subastasAbiertas.Count().ToString();
         }
         catch (Exception ex)
         {
            DialogResult resultado = new DialogResult();
            mensaje = new FrmInformation("Ha ocurrido un error: " + ex);
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
               mensaje.Close();

            }
         }
      }
      private void ListarSolicitudes()
      {
         List<TPISubastas.Dominio.SubastaProducto> solicitudes = new List<TPISubastas.Dominio.SubastaProducto>();
         var productos = clienteProducto.Listar();
         foreach (var item in productos)
         {
            if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Propuesto))
            {
               solicitudes.Add(item);
            }
         }
         lblTotalSolicitudes.Text = solicitudes.Count().ToString();
      }

      public void DimensionarColumnas()
      {
         dgvFuturasSubastas.Columns[0].Width = 80;
         dgvFuturasSubastas.Columns[1].Width = 150;
         dgvFuturasSubastas.Columns[2].Width = 150;
         dgvFuturasSubastas.Columns[3].Width = 150;
         dgvFuturasSubastas.Columns[4].Width = 100;
         dgvFuturasSubastas.Columns[5].Width = 300;
         dgvFuturasSubastas.Columns[6].Width = 500;
         dgvFuturasSubastas.Columns[7].Width = 100;
      }

      private void btnGuardarCambios_Click(object sender, EventArgs e)
      {

         List<TPISubastas.Dominio.Subasta> subastas = (List<TPISubastas.Dominio.Subasta>)dgvFuturasSubastas.DataSource;
         try
         {
            foreach (var item in subastas)
            {
               string id = item.IdSubasta.ToString();
               cliente.Actualizar(item, id);
            }
            mensaje = new FrmSuccess("¡Los cambios se han guardado y aplicado de manera exitosa!");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
            ListarSubastas();
         }
         catch (Exception ex)
         {
            mensaje = new FrmInformation("Ha ocurrido un error al guardar los cambios: " + ex.Message);
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
         }
      }

      private void btnEliminarSubasta_Click(object sender, EventArgs e)
      {
         /*
          Conflicto de referencias al intentar borrar una subasta a la cual ya se solicitó la publicación de un producto
          */

         try
         {
            int fila = dgvFuturasSubastas.CurrentCell.RowIndex;
            var id = dgvFuturasSubastas.Rows[fila].Cells[0].Value.ToString();
            cliente.Eliminar(int.Parse(id));

            mensaje = new FrmSuccess("¡La subasta seleccionada se ha eliminado correctamente!");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
            ListarSubastas();
         }
         catch (Exception ex)
         {
            mensaje = new FrmInformation("Ha ocurrido un error al eliminar la subasta: " + ex.Message);
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
         }
      }
   }

}
