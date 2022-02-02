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

      DialogResult resultado = new DialogResult();
      Form mensaje;
      public FrmCrearSubasta()
      {         
         InitializeComponent();
         LimpiarCampos();
         Listar();
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

      private void btnInsertar_Click(object sender, EventArgs e)
      {
         var subastasPendientes = new TPISubastas.Dominio.Subasta();
         subastasPendientes.Descripcion = txtBoxDescripcion.Text;
         subastasPendientes.Duracion = (int) nudDuracion.Value;
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
         foreach (var item in subastas)
         {
            if (item.FechaCreacion == DateTime.Today.Date)
            {
               subastasActuales.Add(item);
            }
         }
         dgvCrearSubasta.DataSource = subastasActuales;
         //dgvCrearSubasta.Refresh();
         dgvCrearSubasta.Show();
      }

      private void btnGuardarCambios_Click(object sender, EventArgs e)
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
               actualizada.Duracion = item.Duracion;
               
               
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

      private void btnEliminarSubasta_Click(object sender, EventArgs e)
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
               cliente.Eliminar(int.Parse(id));

               mensaje = new FrmSuccess("¡La subasta seleccionada se ha eliminado correctamente!");
               resultado = mensaje.ShowDialog();
               if (resultado == DialogResult.OK)
               {
                  mensaje.Close();
               }
               Listar();
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
         catch(Exception ex)
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
