using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.frmNotificaciones
{
   public partial class FrmInformation : Form
   {
      public FrmInformation(string mensaje)
      {
         InitializeComponent();
         lblMensaje.Text = mensaje;
         Invalidate();
      }

      private void FrmInformation_Load(object sender, EventArgs e)
      {
         FadeTransition.ShowAsyc(this);
      }
      
      
      private void btnOk_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }

      private void FrmInformation_Paint(object sender, PaintEventArgs e)
      {
         Rectangle r = this.ClientRectangle;
         int c = r.Width / 2;
         lblMensaje.Location = new Point(c - lblMensaje.Width / 2, lblMensaje.Location.Y);         
      }
      
      private void FrmInformation_Resize(object sender, EventArgs e)
      {
         Invalidate();
      }
   }
}
