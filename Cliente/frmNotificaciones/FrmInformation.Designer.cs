
namespace Cliente.frmNotificaciones
{
    partial class FrmInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformation));
            this.FadeTransition = new Bunifu.Framework.UI.BunifuFormFadeTransition(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOk = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FadeTransition
            // 
            this.FadeTransition.Delay = 0;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 255);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(194)))), ((int)(((byte)(133)))));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.BorderRadius = 7;
            this.btnOk.ButtonText = "Aceptar";
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DisabledColor = System.Drawing.Color.Gray;
            this.btnOk.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOk.Iconimage = null;
            this.btnOk.Iconimage_right = null;
            this.btnOk.Iconimage_right_Selected = null;
            this.btnOk.Iconimage_Selected = null;
            this.btnOk.IconMarginLeft = 0;
            this.btnOk.IconMarginRight = 0;
            this.btnOk.IconRightVisible = true;
            this.btnOk.IconRightZoom = 0D;
            this.btnOk.IconVisible = true;
            this.btnOk.IconZoom = 90D;
            this.btnOk.IsTab = false;
            this.btnOk.Location = new System.Drawing.Point(27, 428);
            this.btnOk.Name = "btnOk";
            this.btnOk.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(194)))), ((int)(((byte)(133)))));
            this.btnOk.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(184)))), ((int)(((byte)(123)))));
            this.btnOk.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOk.selected = false;
            this.btnOk.Size = new System.Drawing.Size(126, 48);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Textcolor = System.Drawing.Color.White;
            this.btnOk.TextFont = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.Color.White;
            this.lblMensaje.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(59, 324);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(94, 23);
            this.lblMensaje.TabIndex = 7;
            this.lblMensaje.Text = "MENSAJE";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 7;
            this.btnCancel.ButtonText = "Cancelar";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancel.Iconimage = null;
            this.btnCancel.Iconimage_right = null;
            this.btnCancel.Iconimage_right_Selected = null;
            this.btnCancel.Iconimage_Selected = null;
            this.btnCancel.IconMarginLeft = 0;
            this.btnCancel.IconMarginRight = 0;
            this.btnCancel.IconRightVisible = true;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = true;
            this.btnCancel.IconZoom = 90D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(217, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnCancel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(126, 48);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.White;
            this.btnCancel.TextFont = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(370, 500);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblMensaje);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInformation";
            this.Load += new System.EventHandler(this.FrmInformation_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmInformation_Paint);
            this.Resize += new System.EventHandler(this.FrmInformation_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFormFadeTransition FadeTransition;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnOk;
        private System.Windows.Forms.Label lblMensaje;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}