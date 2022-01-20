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
   public partial class FrmLogin : Form
   {
      private string dominio = "https://localhost:44347/";
      private string controlador = "Account";
      private string nombreUsuario;
      private string password;

      public FrmLogin()
      {
         InitializeComponent();
      }

      private void btnIniciarSesion_Click(object sender, EventArgs e)
      {
         if (txtBoxUsuario.Text != "" && txtBoxContraseña.Text != "")
         {

            User.Usuario = txtBoxUsuario.Text;
            User.Contraseña = txtBoxContraseña.Text;


            ClienteAPI<TPISubastas.Dominio.Usuario> clienteAPI = new ClienteAPI<TPISubastas.Dominio.Usuario>(dominio, "Usuario", User.Usuario, User.Contraseña);
            var respuesta = clienteAPI.Login();
            if (!respuesta)
            {
               DialogResult resultado = new DialogResult();
               Form mensaje = new FrmInformation("Credenciales invalidas");
               resultado = mensaje.ShowDialog();

               if (resultado == DialogResult.OK)
               {
                  mensaje.Close();
               }
               txtBoxContraseña.Text = "";
               txtBoxUsuario.Text = "";
               return;
            }
            Hide();
            new FrmPrincipal().Show();
            return;
         }
         DialogResult resultado2 = new DialogResult();
         Form mensaje2 = new FrmInformation("Debe rellenar ambos campos");
         resultado2 = mensaje2.ShowDialog();

         if (resultado2 == DialogResult.OK)
         {
            mensaje2.Close();
         }
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }
   }
}
