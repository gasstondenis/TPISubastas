using Cliente.frmNotificaciones;
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

namespace Cliente
{
   public partial class FrmPrincipal : Form
   {


      public FrmPrincipal()
      {
         InitializeComponent();
         setNombreUsuario();         
      }

      private void FrmPrincipal_Load(object sender, EventArgs e)
      {
         PantallaOk();
      }

      public void PantallaOk()
      {
         this.Size = Screen.PrimaryScreen.WorkingArea.Size;
         this.Location = Screen.PrimaryScreen.WorkingArea.Location;
      }
      private void setNombreUsuario()
      {
         lblNombreUsuario.Text = User.Usuario;
      }


      private void Wrapper_Paint(object sender, PaintEventArgs e)
      {

      }

      private void Salir_Click(object sender, EventArgs e)
      {
         DialogResult resultado = new DialogResult();
         Form mensaje = new FrmInformation("¿Desea cerrar la sesión actual?");
         resultado = mensaje.ShowDialog();

         if (resultado == DialogResult.OK)
         {
            Hide();
            new FrmLogin().Show();
         }

      }

      private void SeleccionandoBotones(Bunifu.Framework.UI.BunifuFlatButton sender)
      {
         btnDashboard.Textcolor = Color.White;
         btnSubastasCerradas.Textcolor = Color.White;
         btnSubastasAbiertas.Textcolor = Color.White;
         btnProductosVendidos.Textcolor = Color.White;
         btnFuturasSubastas.Textcolor = Color.White;
         btnProductosSinOfertas.Textcolor = Color.White;
         btnCrearSubasta.Textcolor = Color.White;         
         btnInformes.Textcolor = Color.White;

         sender.selected = true;

         if (sender.selected)
         {
            sender.Textcolor = Color.FromArgb(98, 195, 140);
         }
      }

      private void SeguirBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
      {
         Flecha.Top = sender.Top;
      }



      private void btnDashboard_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new FrmPublicacionesSolicitadas());
      }
      private void btnCrearSubasta_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new FrmCrearSubasta());
      }
      private void btnSubastasAbiertas_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new FrmSubastasAbiertas());

      }
      private void btnSubastasCerradas_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new FrmSubastasCerradas());
      }

      private void btnProductosVendidos_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new FrmProductosVendidos());
      }
      private void btnProductosSinOfertas_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new FrmProdSinOfertas());

      }
      private void btnFuturasSubastas_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new FrmFuturasSubastas());
      }


      

      private void btnInformes_Click(object sender, EventArgs e)
      {
         SeleccionandoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
         SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
         AbrirFormulariosEnWrapper(new frmInformes());
      }

      private Form formActivado = null;
      private void AbrirFormulariosEnWrapper(Form formHijo)
      {
         if (formActivado != null)
         {
            formActivado.Close();
         }
         formActivado = formHijo;
         formHijo.TopLevel = false;
         formHijo.Dock = DockStyle.Fill;
         Wrapper.Controls.Add(formHijo);
         Wrapper.Tag = formHijo;
         formHijo.BringToFront();
         formHijo.Show();
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         DialogResult resultado = new DialogResult();
         Form mensaje2 = new FrmInformation("¿Desea cerrar la sesión actual?");

         resultado = mensaje2.ShowDialog();

         if (resultado == DialogResult.OK)
         {
            mensaje2.Close();
            Close();
            new FrmLogin().Show();
         }
      }

      
   }
}
