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
   public partial class FrmProductosVendidos : Form
   {
      private ClienteAPI<TPISubastas.Dominio.SubastaProducto> cliente = new ClienteAPI<TPISubastas.Dominio.SubastaProducto>("https://localhost:44347/", "SubastaProducto", User.Usuario, User.Contraseña);
      List<string> productosMarcas = new List<string>();
      List<TPISubastas.Dominio.SubastaProducto> productos = new List<TPISubastas.Dominio.SubastaProducto>();
      List<string> lblMarcasNoVendidas = new List<string>();
      List<string> lblMarcasVendidas = new List<string>();


      public FrmProductosVendidos()
      {
         InitializeComponent();
         Marcas();
         ListarProductos();
         DimensionarColumnas();
      }
      public void ListarProductos()
      {
         try
         {
            List<TPISubastas.Dominio.SubastaProducto> productosVendidos = new List<TPISubastas.Dominio.SubastaProducto>();
            List<TPISubastas.Dominio.SubastaProducto> productosSinOferta = new List<TPISubastas.Dominio.SubastaProducto>();
            productos = cliente.Listar();
            foreach (var item in productos)
            {
               if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.NoVendido))
               {
                  productosSinOferta.Add(item);
               }
               else if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Vendido))
                  productosVendidos.Add(item);
            }
            tablaProductosVendidos.DataSource = productosVendidos;
            lblMarcas.Text = lblMarcasVendidas.Count().ToString();
            lblTotalVendidos.Text = productosVendidos.Count().ToString();
            lblProductosSinOfertas.Text = productosSinOferta.Count().ToString();
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
      private void BuscarMarcas()
      {
         string sPattern = txtBoxBusqueda.Text;
         List<TPISubastas.Dominio.SubastaProducto> prodToDgv = new List<TPISubastas.Dominio.SubastaProducto>();
         IEnumerable<TPISubastas.Dominio.SubastaProducto> prod = null;
         foreach (var item in productosMarcas)
         {
            if (System.Text.RegularExpressions.Regex.IsMatch(item, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
               prod = productos.Where(x => x.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Vendido) && x.MarcaProducto.ToUpper().Trim() == item);
               prodToDgv.AddRange(prod);
            }                      
         }
         tablaProductosVendidos.DataSource = prodToDgv.Distinct().ToArray();      
         tablaProductosVendidos.Refresh();
      }



      private void Marcas()
      {
         var productos = cliente.Listar();
         List<string> marcasLbl = new List<string>();
         //List<string> marcasProd = new List<string>();
         foreach (var item in productos)
         {
            var marca = item.MarcaProducto.ToUpper().Trim();
            if (!lblMarcasVendidas.Contains(marca) && item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.Vendido))
               lblMarcasVendidas.Add(marca);

            if (item.IdEstadoSubasta == ((int)TPISubastas.Dominio.Estados.NoVendido) && !lblMarcasNoVendidas.Contains(marca))
               lblMarcasNoVendidas.Add(marca);

            productosMarcas.Add(marca);
         } 
      }

      public void DimensionarColumnas()
      {
         tablaProductosVendidos.Columns[0].Width = 100; //IdSubastaProducto
         tablaProductosVendidos.Columns[1].Width = 80; //IdSubasta
         tablaProductosVendidos.Columns[2].Width = 400; //NombreProducto
         tablaProductosVendidos.Columns[3].Width = 200; //MarcaProducto
         tablaProductosVendidos.Columns[4].Width = 450; //DescripciónProducto
         tablaProductosVendidos.Columns[5].Width = 100; //ImagenProducto
         tablaProductosVendidos.Columns[6].Width = 100; //FormaPago 
         tablaProductosVendidos.Columns[7].Width = 150; // MontoInicial
         tablaProductosVendidos.Columns[8].Width = 100;  //IdUsuarioVendedor
         tablaProductosVendidos.Columns[9].Width = 100; //IdUsuarioComprador
         tablaProductosVendidos.Columns[11].Width = 100; //IdEstadoSubasta
         tablaProductosVendidos.Columns[12].Width = 100;
         tablaProductosVendidos.Columns[13].Width = 150;

         tablaProductosVendidos.Columns[8].HeaderText = "IdUsuarioVendedor";
         tablaProductosVendidos.Columns[10].Visible = false;

      }


      //La busqueda de productos por marca no funciona

      private void txtBoxBusqueda_TextChanged(object sender, EventArgs e)
      {
         if (txtBoxBusqueda.Text != "")
         {
            BuscarMarcas();
            return;
         }

         ListarProductos();
      }

      private void btnExportarExcel_Click(object sender, EventArgs e)
      {
         exportarExcel(tablaProductosVendidos);
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
