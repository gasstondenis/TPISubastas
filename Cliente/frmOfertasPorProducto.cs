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
   public partial class frmOfertasPorProducto : Form
   {
      public frmOfertasPorProducto()
      {
         InitializeComponent();         
      }

      public void DimensionarColumnas()
      {
         dgvOfertas.Columns[0].Width = 150; //IdOferta
         dgvOfertas.Columns[1].Width = 150; //IdSubasta
         dgvOfertas.Columns[2].Width = 150; //SubastaProducto
         dgvOfertas.Columns[3].Width = 150; //IdUsuario
         dgvOfertas.Columns[4].Width = 300; //Fecha
         dgvOfertas.Columns[5].Width = 200; //Monto

         dgvOfertas.Columns[0].HeaderText = "Id Oferta"; //IdOferta
         dgvOfertas.Columns[1].HeaderText = "Id Subasta"; //IdSubasta
         dgvOfertas.Columns[2].HeaderText = "Id Producto"; //SubastaProducto
         dgvOfertas.Columns[3].HeaderText = "Id Oferente"; //IdUsuario
         dgvOfertas.Columns[4].HeaderText = "Fecha y hora"; //Fecha
        

      }

      private void btnExportarExcel_Click(object sender, EventArgs e)
      {
         exportarExcel(dgvOfertas);
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

      private void btnSalir_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      
   }
}
