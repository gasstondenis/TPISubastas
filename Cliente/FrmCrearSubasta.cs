using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliente.LoginModel;
using Cliente.frmNotificaciones;

namespace Cliente
{
   public partial class FrmCrearSubasta : Form
   {
      private ClienteAPI<TPISubastas.Dominio.Subasta> cliente = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.SubastaProducto> clienteProductos = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", User.Usuario, User.Contraseña);

      DialogResult resultado = new DialogResult();
      Form mensaje;
      public FrmCrearSubasta()
      {
         InitializeComponent();
         LimpiarCampos();
         Listar();
         DimensionarColumnas();
      }




      private void dgvCrearSubasta_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
      {

      }

      private void btnLimpiarCampos_Click(object sender, EventArgs e)
      {
         LimpiarCampos();
      }
      private void LimpiarCampos()
      {
         txtBoxDescripcion.Text = "";
         dtpFechaInicio.Value = DateTime.Now.Date;
         dtpFechaCierre.Value = DateTime.Now.Date.AddDays(1);
         nudDuracion.Value = 1;
         txtBoxNombre.Text = "";
      }

      public void DimensionarColumnas()
      {
         dgvCrearSubasta.Columns[0].Width = 120;
         dgvCrearSubasta.Columns[0].ReadOnly = true;
         dgvCrearSubasta.Columns[1].Width = 180;
         dgvCrearSubasta.Columns[1].ReadOnly = true;
         dgvCrearSubasta.Columns[2].Width = 180;
         //dgvCrearSubasta.Columns[2].ReadOnly = true;
         dgvCrearSubasta.Columns[3].Width = 180;
         dgvCrearSubasta.Columns[4].Width = 130;
         dgvCrearSubasta.Columns[4].ReadOnly = true;

         dgvCrearSubasta.Columns[5].Width = 300;
         dgvCrearSubasta.Columns[6].Width = 500;
         dgvCrearSubasta.Columns[7].Width = 140;
      }

      private void btnInsertar_Click(object sender, EventArgs e)
      {
         var subastasPendientes = new TPISubastas.Dominio.Subasta();
         subastasPendientes.Descripcion = txtBoxDescripcion.Text;
         subastasPendientes.Duracion = (int)nudDuracion.Value;
         subastasPendientes.Nombre = txtBoxNombre.Text;
         subastasPendientes.FechaInicio = dtpFechaInicio.Value.Date;
         subastasPendientes.FechaCreacion = DateTime.Now.Date;
         subastasPendientes.FechaCierre = dtpFechaCierre.Value.Date;
         subastasPendientes.Habilitada = true;

         if (subastasPendientes.FechaInicio.Value != null && subastasPendientes.FechaCierre.Value != DateTime.Now && subastasPendientes.Nombre != "" && subastasPendientes.Descripcion != "" && subastasPendientes.Duracion != 0)
         {
            try
            {
               cliente.Agregar(subastasPendientes);
            }
            catch (Exception ex)
            {
               mensaje = new FrmInformation("Error al crear la subasta.");
               resultado = mensaje.ShowDialog();
               if (resultado == DialogResult.OK)
               {
                  mensaje.Close();
               }
            }

         }
         else
         {
            mensaje = new FrmInformation("Debe rellenar todos los campos para crear la/s subastas");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
            return;
         }
         mensaje = new FrmSuccess("¡La subasta ha sido creada de manera exitosa!");
         resultado = mensaje.ShowDialog();
         if (resultado == DialogResult.OK)
         {
            mensaje.Close();
         }
         LimpiarCampos();
         Listar();

      }
      private void Listar()
      {
         var subastas = cliente.Listar();
         List<TPISubastas.Dominio.Subasta> subastasActuales = new List<TPISubastas.Dominio.Subasta>();
         List<TPISubastas.Dominio.Subasta> subastasAbiertas = new List<TPISubastas.Dominio.Subasta>();
         List<TPISubastas.Dominio.Subasta> futurasSuabastas = new List<TPISubastas.Dominio.Subasta>();
         foreach (var item in subastas)
         {
            if (item.FechaCreacion == DateTime.Today.Date)
            {
               subastasActuales.Add(item);
            }
            if (item.FechaInicio <= DateTime.Today.Date && item.FechaCierre > DateTime.Today.Date && item.Habilitada)
            {
               subastasAbiertas.Add(item);
            }
            if (item.FechaInicio > DateTime.Today.Date && item.Habilitada)
            {
               futurasSuabastas.Add(item);
            }
         }
         lblFuturasSubastas.Text = futurasSuabastas.Count().ToString();
         lblSubastasAbiertas.Text = subastasAbiertas.Count().ToString();
         dgvCrearSubasta.DataSource = subastasActuales;
         //dgvCrearSubasta.Refresh();
         dgvCrearSubasta.Show();
      }

      private void btnGuardarCambios_Click(object sender, EventArgs e)
      {
         if (dgvCrearSubasta.CurrentCell != null)
         {
            List<TPISubastas.Dominio.Subasta> subastas = (List<TPISubastas.Dominio.Subasta>)dgvCrearSubasta.DataSource;
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
               Listar();
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
         else
         {
            mensaje = new FrmInformation("No se ha seleccionado ninguna subasta");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
         }
      }

      private void btnEliminarSubasta_Click(object sender, EventArgs e)
      {
         
         //No se pueden eliminar subastas con fecha de inicio igual o menor a la fecha actual
         //A fines prácticos de explicación, la modificación de fecha de inicio de una subasta estará PERMITIDA. No obstante, esto no es lo ideal en un entorno de producción
         //
         //Antes de eliminar una subasta se comprobará que no existan solicitudes de publicación de productos a la misma, en caso de existir alguna/s se eliminaran...
         //...Para posteriormente eliminar la subasta. NO se dará aviso a los solicitantes de la eliminación de su producto ni de su solicitud
         //
         if (dgvCrearSubasta.CurrentCell != null)
         {
            mensaje = new FrmInformation("¿Eliminar la subasta?");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
               try
               {                  
                  int fila = dgvCrearSubasta.CurrentCell.RowIndex;
                  var id = dgvCrearSubasta.Rows[fila].Cells[0].Value.ToString();
                  var subastaAbierta = cliente.Obtener(int.Parse(id));
                  if(subastaAbierta == null || subastaAbierta.FechaInicio > DateTime.Now.Date) {
                     var productos = clienteProductos.Listar();
                     var solicitudes = productos.Where(x => x.IdSubasta == (int.Parse(id)));
                     if (solicitudes != null)
                     {
                        foreach (var item in solicitudes)
                        {
                           clienteProductos.Eliminar(item.IdSubastaProducto);
                        }
                     }
                     cliente.Eliminar(int.Parse(id));
                     mensaje = new FrmSuccess("¡La subasta seleccionada se ha eliminado correctamente!");
                     resultado = mensaje.ShowDialog();
                     if (resultado == DialogResult.OK)
                     {
                        mensaje.Close();
                     }
                     Listar();

                  }
                  else
                  {
                     mensaje = new FrmInformation("No puede eliminar una subasta abierta, sólo puede desactivarla.");
                     resultado = mensaje.ShowDialog();
                     if (resultado == DialogResult.OK)
                     {
                        mensaje.Close();
                     }
                     Listar();
                  }


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
         else
         {
            mensaje = new FrmInformation("No se ha seleccionado ninguna subasta");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
            }
         }
      }

      private void dgvCrearSubasta_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {

         dgvCrearSubasta.Rows[e.RowIndex].Selected = false;
      }

      private void dtpFechaCierre_ValueChanged(object sender, EventArgs e)
      {
         nudDuracion.Maximum = 31;
         nudDuracion.Minimum = 1;
         try
         {
            nudDuracion.Value = int.Parse((dtpFechaCierre.Value.Date - dtpFechaInicio.Value.Date).Days.ToString());
         }
         catch (Exception ex)
         {
            mensaje = new FrmInformation("La fecha de cierre de la subasta debe ser mayor a la fecha de inicio y la diferencia entre ambas no debe ser mayor a 31 dias.");
            resultado = mensaje.ShowDialog();
            if (resultado == DialogResult.OK)
            {
               mensaje.Close();
               dtpFechaCierre.Value = DateTime.Now.Date.AddDays(1);
               nudDuracion.Value = 1;
               LimpiarCampos();
            }
         }
      }


   }
}
