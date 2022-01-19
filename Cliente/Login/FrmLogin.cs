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
    public partial class FrmLogin : Form
    {        
        private string dominio = "https://localhost:44347/";
        private string controlador = "Account";
        private string nombreUsuario;
        private string password;
        private LoginAPI cliente = null;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtBoxUsuario != null && txtBoxContraseña != null)
            {
                nombreUsuario = txtBoxUsuario.Text;
                password = txtBoxContraseña.Text;
                
            }

            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
