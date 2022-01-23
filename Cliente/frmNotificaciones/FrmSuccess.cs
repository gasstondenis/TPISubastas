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
   public partial class FrmSuccess : Form
   {
      public FrmSuccess(string mensaje)
      {
         InitializeComponent();
         this.lblMensaje.Text = mensaje;
         Invalidate();
      }

      private void FrmSuccess_Load(object sender, EventArgs e)
      {
         FadeTransition.ShowAsyc(this);
      }
      public static void confirmacionForm(string mensaje)
      {
         FrmSuccess frm = new FrmSuccess(mensaje);
         frm.ShowDialog();
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void FrmSuccess_Paint(object sender, PaintEventArgs e)
      {
         Rectangle r = this.ClientRectangle;
         int c = r.Width / 2;
         lblMensaje.Location = new Point(c - lblMensaje.Width / 2, lblMensaje.Location.Y);
      }

      private void FrmSuccess_Resize(object sender, EventArgs e)
      {
         Invalidate();
      }
   }
}
