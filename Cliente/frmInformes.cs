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
   public partial class frmInformes : Form
   {

      private ClienteAPI<TPISubastas.Dominio.SubastaProducto> cliente = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.Oferta> clienteOferta = new ClienteAPI<TPISubastas.Dominio.Oferta>("https://localhost:44347/", "Oferta", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.Subasta> clienteSubasta = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", User.Usuario, User.Contraseña);


      public frmInformes()
      {
         InitializeComponent();
         Listar();
         DimensionarColumnas();
      }

      public void Listar()
      {
         try
         {
            List<TPISubastas.Dominio.Subasta> subastasCerradas = new List<TPISubastas.Dominio.Subasta>();
            var subastas = clienteSubasta.Listar();
            foreach (var item in subastas)
            {
               if (!item.Habilitada)
               {
                  subastasCerradas.Add(item);
               }
            }
            dgvSubastasCerradas.DataSource = subastasCerradas;
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
         dgvSubastasCerradas.Columns[0].Width = 80;
         dgvSubastasCerradas.Columns[0].ReadOnly = true;
         dgvSubastasCerradas.Columns[1].Width = 150;
         dgvSubastasCerradas.Columns[1].ReadOnly = true;
         dgvSubastasCerradas.Columns[2].Width = 150;
         dgvSubastasCerradas.Columns[2].ReadOnly = true;
         dgvSubastasCerradas.Columns[3].Width = 150;
         dgvSubastasCerradas.Columns[3].ReadOnly = true;
         dgvSubastasCerradas.Columns[4].Width = 100;
         dgvSubastasCerradas.Columns[4].ReadOnly = true;
         dgvSubastasCerradas.Columns[5].Width = 300;
         dgvSubastasCerradas.Columns[5].ReadOnly = true;
         dgvSubastasCerradas.Columns[6].Width = 500;
         dgvSubastasCerradas.Columns[6].ReadOnly = true;
         dgvSubastasCerradas.Columns[7].Width = 100;
         dgvSubastasCerradas.Columns[7].ReadOnly = true;
      }

      private void btnObtenerResultados_Click(object sender, EventArgs e)
      {
         if (dgvSubastasCerradas.CurrentCell != null)
         {
            int fila = dgvSubastasCerradas.CurrentCell.RowIndex;
            var idString = dgvSubastasCerradas.Rows[fila].Cells[0].Value.ToString();
            var idInt = int.Parse(idString);

            var productos = cliente.Listar();
            var subasta = clienteSubasta.Obtener(idInt);
            var productosDeLaSubasta = productos.Where(x => x.IdSubasta == idInt);

            decimal sumaDeMontos = 0;
            foreach (var item in productosDeLaSubasta)
            {
               if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Vendido))
                  sumaDeMontos += (decimal)item.OfertaFinal;
            }
            lblCaudalTotal.Text = sumaDeMontos.ToString();
            lblGanancias.Text = ((10 * sumaDeMontos) / 100).ToString();
            lblDuracion.Text = subasta.Duracion.ToString();
         }
         else
         {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FrmInformation("No se ha seleccionado ninguna subasta.");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
               mensaje.Close();

            }
         }

      }
   }
}
