using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;

namespace Cliente
{
   public partial class FrmProductosPorSubasta : Form
   {
      public List<TPISubastas.Dominio.SubastaProducto> productos = new List<TPISubastas.Dominio.SubastaProducto>();
      List<string> productosMarcas = new List<string>();

      public bool vendidos;

      public FrmProductosPorSubasta()
      {
         InitializeComponent();         
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void BuscarMarcas()
      {
         rellenarMarcas();
         string sPattern = txtBoxBusqueda.Text;
         List<TPISubastas.Dominio.SubastaProducto> prodToDgv = new List<TPISubastas.Dominio.SubastaProducto>();
         IEnumerable<TPISubastas.Dominio.SubastaProducto> prod = null;
         foreach (var item in productosMarcas)
         {
            if (System.Text.RegularExpressions.Regex.IsMatch(item, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
               if (vendidos)
               {
                  prod = productos.Where(x => x.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Vendido) && x.MarcaProducto.ToUpper().Trim() == item);
               }
               else if (!vendidos)
               {
                  prod = productos.Where(x => x.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.NoVendido) && x.MarcaProducto.ToUpper().Trim() == item);
               }
               prodToDgv.AddRange(prod);
              
            }
         }
         dgvProductos.DataSource = prodToDgv.Distinct().ToArray();
         lblCantResultados.Text = prodToDgv.Distinct().ToArray().Count().ToString();
         dgvProductos.Refresh();
      }

      private void rellenarMarcas()
      {

         foreach (var item in productos)
         {
            productosMarcas.Add(item.MarcaProducto.ToUpper().Trim());
         }


      }

      private void txtBoxBusqueda_TextChanged(object sender, EventArgs e)
      {
         if (txtBoxBusqueda.Text != "")
         {
            BuscarMarcas();
            return;
         }

         dgvProductos.DataSource = productos;
         lblCantResultados.Text = productos.Count().ToString();
      }

      private void btnExportarExcel_Click(object sender, EventArgs e)
      {
         exportarExcel(dgvProductos);
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
