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
   public partial class FrmSubastasCerradas : Form
   {

      private ClienteAPI<TPISubastas.Dominio.Subasta> cliente = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.SubastaProducto> clienteProductos = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", User.Usuario, User.Contraseña);

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
               if (!item.Habilitada)
               {
                  subastasCerradas.Add(item);
               }
            }
            
            lblCantElementos.Text = subastasCerradas.Count().ToString();
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

      private void btnProductosVendidos_Click(object sender, EventArgs e)
      {
         int fila = tablaSubastasCerradas.CurrentCell.RowIndex;
         var idString = tablaSubastasCerradas.Rows[fila].Cells[0].Value.ToString();
         var idInt = int.Parse(idString);

         List<TPISubastas.Dominio.SubastaProducto> productosVendidos = new List<TPISubastas.Dominio.SubastaProducto>();        
         var productos = clienteProductos.Listar();
         foreach (var item in productos)
         {
            if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Vendido) && item.IdSubasta == idInt)
            {
               productosVendidos.Add(item);
            }

         }
         FrmProductosPorSubasta frmProductosPorSubasta = new FrmProductosPorSubasta();
         frmProductosPorSubasta.productos = productosVendidos;
         frmProductosPorSubasta.lblCantResultados.Text = productosVendidos.Count().ToString();
         //frmProductosPorSubasta.lblTituloVentana.Text = "Productos vendidos de la subasta seleccionada";
         frmProductosPorSubasta.vendidos = true;
         frmProductosPorSubasta.Show();
         frmProductosPorSubasta.dgvProductos.DataSource = productosVendidos;
         frmProductosPorSubasta.dgvProductos.Refresh();
      }

      private void btnProdSinOfertas_Click(object sender, EventArgs e)
      {
         int fila = tablaSubastasCerradas.CurrentCell.RowIndex;
         var idString = tablaSubastasCerradas.Rows[fila].Cells[0].Value.ToString();
         var idInt = int.Parse(idString);

         List<TPISubastas.Dominio.SubastaProducto> prodNoVendidos = new List<TPISubastas.Dominio.SubastaProducto>();        
         var productos = clienteProductos.Listar();
         foreach (var item in productos)
         {
            if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.NoVendido) && item.IdSubasta == idInt)
               prodNoVendidos.Add(item);
         }
         FrmProductosPorSubasta frmProductosPorSubasta = new FrmProductosPorSubasta();
         frmProductosPorSubasta.productos = prodNoVendidos;
         frmProductosPorSubasta.lblCantResultados.Text = prodNoVendidos.Count().ToString();
         //frmProductosPorSubasta.lblTituloVentana.Text = "Productos sin oferta de la subasta seleccionada";
         frmProductosPorSubasta.vendidos = false;
         frmProductosPorSubasta.Show();
         frmProductosPorSubasta.dgvProductos.DataSource = prodNoVendidos;
         frmProductosPorSubasta.dgvProductos.Refresh();
      }

      private void btnExportarExcel_Click(object sender, EventArgs e)
      {
         exportarExcel(tablaSubastasCerradas);
      }
      public void exportarExcel(DataGridView tabla)
      {
         Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
         excel.Application.Workbooks.Add(true);
         int IndiceColumna = 0;
         foreach (DataGridViewColumn col in tabla.Columns)
         {
            IndiceColumna++;
            excel.Cells[1, IndiceColumna] = col.Name;
         }
         int IndeceFila = 0;
         foreach (DataGridViewRow row in tabla.Rows)
         {
            IndeceFila++;
            IndiceColumna = 0;
            foreach (DataGridViewColumn col in tabla.Columns)
            {
               IndiceColumna++;
               excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
            }
         }
         excel.Visible = true;
      }
   }
}


