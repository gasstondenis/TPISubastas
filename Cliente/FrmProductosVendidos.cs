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
      private ClienteAPI<TPISubastas.Dominio.Oferta> clienteOferta = new ClienteAPI<TPISubastas.Dominio.Oferta>("https://localhost:44347/", "Oferta", User.Usuario, User.Contraseña);
      private ClienteAPI<TPISubastas.Dominio.Subasta> clienteSubasta = new ClienteAPI<TPISubastas.Dominio.Subasta>("https://localhost:44347/", "Subasta", User.Usuario, User.Contraseña);

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
         tablaProductosVendidos.Columns[0].Width = 150; //IdSubastaProducto
         tablaProductosVendidos.Columns[1].Width = 120; //IdSubasta
         tablaProductosVendidos.Columns[2].Width = 400; //NombreProducto
         tablaProductosVendidos.Columns[3].Width = 240; //MarcaProducto
         tablaProductosVendidos.Columns[4].Width = 450; //DescripciónProducto
         tablaProductosVendidos.Columns[5].Width = 140; //ImagenProducto
         tablaProductosVendidos.Columns[6].Width = 140; //FormaPago 
         tablaProductosVendidos.Columns[7].Width = 190; // MontoInicial
         tablaProductosVendidos.Columns[8].Width = 140;  //IdUsuarioVendedor
         tablaProductosVendidos.Columns[9].Width = 160; //IdUsuarioComprador
         tablaProductosVendidos.Columns[11].Width = 140; //IdEstadoSubasta
         tablaProductosVendidos.Columns[12].Width = 140;
         tablaProductosVendidos.Columns[13].Width = 180;

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

      private void btnOfertasProducto_Click(object sender, EventArgs e)
      {
         if(tablaProductosVendidos.CurrentCell != null)
         {
            int fila = tablaProductosVendidos.CurrentCell.RowIndex;
            var idString = tablaProductosVendidos.Rows[fila].Cells[0].Value.ToString();
            var idInt = int.Parse(idString);

            var producto = cliente.Obtener(idInt);

            var todasLasOfertas = clienteOferta.Listar();

            List<TPISubastas.Dominio.Oferta> ofertasPorProducto = new List<TPISubastas.Dominio.Oferta>();

            foreach (var item in todasLasOfertas)
            {
               if (item.IdSubastaProducto == producto.IdSubastaProducto)
               {
                  ofertasPorProducto.Add(item);
               }

            }
            frmOfertasPorProducto frmOfertasPorProducto = new frmOfertasPorProducto();
            frmOfertasPorProducto.dgvOfertas.DataSource = ofertasPorProducto;
            frmOfertasPorProducto.DimensionarColumnas();
            frmOfertasPorProducto.lblCantResultados.Text = ofertasPorProducto.Count().ToString();
            frmOfertasPorProducto.lblOfertaAlta.Text = "$" + ofertasPorProducto.OrderByDescending(x => x.Monto).FirstOrDefault().Monto.ToString().Trim();
            frmOfertasPorProducto.lblOfertaBaja.Text = "$" + ofertasPorProducto.OrderBy(x => x.Monto).FirstOrDefault().Monto.ToString().Trim();
            frmOfertasPorProducto.lblTitulo.Text = frmOfertasPorProducto.lblTitulo.Text + producto.NombreProducto;
            frmOfertasPorProducto.Show();
            frmOfertasPorProducto.dgvOfertas.Refresh();
         }
         else
         {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FrmInformation("No se ha seleccionado ningún producto");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
               mensaje.Close();

            }
         }
         
      }
   }
}
