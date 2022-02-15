using Cliente.frmNotificaciones;
using Cliente.LoginModel;
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

      private ClienteAPI<TPISubastas.Dominio.Subasta> cliente = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.SubastaProducto> clienteProducto = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", User.Usuario, User.Contraseña);
      DialogResult resultado = new DialogResult();
      Form mensaje;

      public FrmSubastasAbiertas()
      {
         InitializeComponent();
         ListarSubastas();
         DimensionarColumnas();
      }

      public void ListarSubastas()
      {
         try
         {
            List<TPISubastas.Dominio.Subasta> subastasAbiertas = new List<TPISubastas.Dominio.Subasta>();
            var subastas = cliente.Listar();
            foreach (var item in subastas)
            {
               if (item.FechaCierre > DateTime.Now.Date && item.FechaInicio <= DateTime.Now.Date && item.Habilitada)
               {
                  subastasAbiertas.Add(item);
               }
            }
            tablaSubastasAbiertas.DataSource = subastasAbiertas;
            lblCantElementos.Text = subastasAbiertas.Count().ToString();
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
         tablaSubastasAbiertas.Columns[0].Width = 100;
         tablaSubastasAbiertas.Columns[0].ReadOnly = true;
         tablaSubastasAbiertas.Columns[1].Width = 190;
         tablaSubastasAbiertas.Columns[1].ReadOnly = true;
         tablaSubastasAbiertas.Columns[2].Width = 190;
         tablaSubastasAbiertas.Columns[2].ReadOnly = true;
         tablaSubastasAbiertas.Columns[3].Width = 190;
         tablaSubastasAbiertas.Columns[4].Width = 140;
         tablaSubastasAbiertas.Columns[4].ReadOnly = true;

         tablaSubastasAbiertas.Columns[5].Width = 300;
         tablaSubastasAbiertas.Columns[6].Width = 500;
         tablaSubastasAbiertas.Columns[7].Width = 140;
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

      private void btnGuardarCambios_Click(object sender, EventArgs e)
      {
         List<TPISubastas.Dominio.Subasta> subastas = (List<TPISubastas.Dominio.Subasta>)tablaSubastasAbiertas.DataSource;
         TPISubastas.Dominio.Subasta actualizada = new TPISubastas.Dominio.Subasta();
         try
         {
            foreach (var item in subastas)
            {
               actualizada.FechaInicio = item.FechaInicio;
               actualizada.FechaCierre = item.FechaCierre;
               actualizada.FechaCreacion = item.FechaCreacion;
               actualizada.Descripcion = item.Descripcion;
               actualizada.IdSubasta = item.IdSubasta;
               actualizada.Nombre = item.Nombre;
               actualizada.Habilitada = item.Habilitada;
               actualizada.Duracion = int.Parse((item.FechaCierre.Value.Date - item.FechaInicio.Value.Date).Days.ToString());


               cliente.Actualizar(actualizada, actualizada.IdSubasta.ToString());
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

      private void btnProductosDeLaSubasta_Click(object sender, EventArgs e)
      {
         int fila = tablaSubastasAbiertas.CurrentCell.RowIndex;
         var idString = tablaSubastasAbiertas.Rows[fila].Cells[0].Value.ToString();
         var idInt = int.Parse(idString);

         List<TPISubastas.Dominio.SubastaProducto> productosDeLaSubasta = new List<TPISubastas.Dominio.SubastaProducto>();
         var productos = clienteProducto.Listar();
         foreach (var item in productos)
         {
            if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Aprobado) && item.IdSubasta == idInt)
               productosDeLaSubasta.Add(item);
         }
         FrmProductosPorSubasta frmProductosPorSubasta = new FrmProductosPorSubasta();
         frmProductosPorSubasta.productos = productosDeLaSubasta;
         frmProductosPorSubasta.lblCantResultados.Text = productosDeLaSubasta.Count().ToString();
         //frmProductosPorSubasta.lblTituloVentana.Text = "Productos sin oferta de la subasta seleccionada";
         frmProductosPorSubasta.vendidos = false;
         frmProductosPorSubasta.todos = true;
         frmProductosPorSubasta.Show();
         frmProductosPorSubasta.dgvProductos.DataSource = productosDeLaSubasta;
         frmProductosPorSubasta.dgvProductos.Refresh();
      }
   }
}
