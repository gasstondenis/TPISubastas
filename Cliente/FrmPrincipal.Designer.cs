﻿
namespace Cliente
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.Header = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.Salir = new System.Windows.Forms.PictureBox();
            this.Wrapper = new System.Windows.Forms.Panel();
            this.Sidebar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LineShapeSidebar = new System.Windows.Forms.Panel();
            this.Flecha = new System.Windows.Forms.PictureBox();
            this.btnProductosSinOfertas = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnInformes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnUsuariosDelSitio = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnGanancias = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProductosVendidos = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSubastasCerradas = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSubastasAbiertas = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
            this.Sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Flecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.Header.Controls.Add(this.lblDashboard);
            this.Header.Controls.Add(this.Salir);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(270, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1170, 60);
            this.Header.TabIndex = 0;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.lblDashboard.Location = new System.Drawing.Point(22, 18);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(128, 24);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "DASHBOARD";
            // 
            // Salir
            // 
            this.Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Salir.Image = ((System.Drawing.Image)(resources.GetObject("Salir.Image")));
            this.Salir.Location = new System.Drawing.Point(1110, 6);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(48, 48);
            this.Salir.TabIndex = 0;
            this.Salir.TabStop = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Wrapper
            // 
            this.Wrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wrapper.Location = new System.Drawing.Point(270, 60);
            this.Wrapper.Name = "Wrapper";
            this.Wrapper.Size = new System.Drawing.Size(1170, 824);
            this.Wrapper.TabIndex = 1;
            this.Wrapper.Paint += new System.Windows.Forms.PaintEventHandler(this.Wrapper_Paint);
            // 
            // Sidebar
            // 
            this.Sidebar.BackColor = System.Drawing.Color.Transparent;
            this.Sidebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sidebar.BackgroundImage")));
            this.Sidebar.Controls.Add(this.panel1);
            this.Sidebar.Controls.Add(this.LineShapeSidebar);
            this.Sidebar.Controls.Add(this.Flecha);
            this.Sidebar.Controls.Add(this.btnProductosSinOfertas);
            this.Sidebar.Controls.Add(this.btnInformes);
            this.Sidebar.Controls.Add(this.btnUsuariosDelSitio);
            this.Sidebar.Controls.Add(this.btnGanancias);
            this.Sidebar.Controls.Add(this.btnDashboard);
            this.Sidebar.Controls.Add(this.btnProductosVendidos);
            this.Sidebar.Controls.Add(this.btnSubastasCerradas);
            this.Sidebar.Controls.Add(this.btnSubastasAbiertas);
            this.Sidebar.Controls.Add(this.lblNombreUsuario);
            this.Sidebar.Controls.Add(this.pictureBox1);
            this.Sidebar.Controls.Add(this.label1);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.Location = new System.Drawing.Point(0, 0);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Size = new System.Drawing.Size(270, 884);
            this.Sidebar.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(31, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 2);
            this.panel1.TabIndex = 1;
            // 
            // LineShapeSidebar
            // 
            this.LineShapeSidebar.BackColor = System.Drawing.Color.White;
            this.LineShapeSidebar.ForeColor = System.Drawing.Color.White;
            this.LineShapeSidebar.Location = new System.Drawing.Point(31, 60);
            this.LineShapeSidebar.Name = "LineShapeSidebar";
            this.LineShapeSidebar.Size = new System.Drawing.Size(200, 2);
            this.LineShapeSidebar.TabIndex = 0;
            // 
            // Flecha
            // 
            this.Flecha.Image = ((System.Drawing.Image)(resources.GetObject("Flecha.Image")));
            this.Flecha.Location = new System.Drawing.Point(237, 298);
            this.Flecha.Name = "Flecha";
            this.Flecha.Size = new System.Drawing.Size(33, 40);
            this.Flecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Flecha.TabIndex = 13;
            this.Flecha.TabStop = false;
            // 
            // btnProductosSinOfertas
            // 
            this.btnProductosSinOfertas.Activecolor = System.Drawing.Color.Transparent;
            this.btnProductosSinOfertas.BackColor = System.Drawing.Color.Transparent;
            this.btnProductosSinOfertas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductosSinOfertas.BorderRadius = 0;
            this.btnProductosSinOfertas.ButtonText = "   PRODUCTOS SIN OFERTAS";
            this.btnProductosSinOfertas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductosSinOfertas.DisabledColor = System.Drawing.Color.Gray;
            this.btnProductosSinOfertas.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProductosSinOfertas.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnProductosSinOfertas.Iconimage")));
            this.btnProductosSinOfertas.Iconimage_right = null;
            this.btnProductosSinOfertas.Iconimage_right_Selected = null;
            this.btnProductosSinOfertas.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnProductosSinOfertas.Iconimage_Selected")));
            this.btnProductosSinOfertas.IconMarginLeft = 0;
            this.btnProductosSinOfertas.IconMarginRight = 0;
            this.btnProductosSinOfertas.IconRightVisible = true;
            this.btnProductosSinOfertas.IconRightZoom = 0D;
            this.btnProductosSinOfertas.IconVisible = true;
            this.btnProductosSinOfertas.IconZoom = 70D;
            this.btnProductosSinOfertas.IsTab = true;
            this.btnProductosSinOfertas.Location = new System.Drawing.Point(12, 554);
            this.btnProductosSinOfertas.Name = "btnProductosSinOfertas";
            this.btnProductosSinOfertas.Normalcolor = System.Drawing.Color.Transparent;
            this.btnProductosSinOfertas.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnProductosSinOfertas.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnProductosSinOfertas.selected = false;
            this.btnProductosSinOfertas.Size = new System.Drawing.Size(236, 40);
            this.btnProductosSinOfertas.TabIndex = 14;
            this.btnProductosSinOfertas.Text = "   PRODUCTOS SIN OFERTAS";
            this.btnProductosSinOfertas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductosSinOfertas.Textcolor = System.Drawing.Color.White;
            this.btnProductosSinOfertas.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnProductosSinOfertas.Click += new System.EventHandler(this.btnProductosSinOfertas_Click);
            // 
            // btnInformes
            // 
            this.btnInformes.Activecolor = System.Drawing.Color.Transparent;
            this.btnInformes.BackColor = System.Drawing.Color.Transparent;
            this.btnInformes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInformes.BorderRadius = 0;
            this.btnInformes.ButtonText = "   INFORMES";
            this.btnInformes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformes.DisabledColor = System.Drawing.Color.Gray;
            this.btnInformes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnInformes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnInformes.Iconimage")));
            this.btnInformes.Iconimage_right = null;
            this.btnInformes.Iconimage_right_Selected = null;
            this.btnInformes.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnInformes.Iconimage_Selected")));
            this.btnInformes.IconMarginLeft = 0;
            this.btnInformes.IconMarginRight = 0;
            this.btnInformes.IconRightVisible = true;
            this.btnInformes.IconRightZoom = 0D;
            this.btnInformes.IconVisible = true;
            this.btnInformes.IconZoom = 70D;
            this.btnInformes.IsTab = true;
            this.btnInformes.Location = new System.Drawing.Point(12, 746);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Normalcolor = System.Drawing.Color.Transparent;
            this.btnInformes.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnInformes.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnInformes.selected = false;
            this.btnInformes.Size = new System.Drawing.Size(236, 40);
            this.btnInformes.TabIndex = 12;
            this.btnInformes.Text = "   INFORMES";
            this.btnInformes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.Textcolor = System.Drawing.Color.White;
            this.btnInformes.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
            // 
            // btnUsuariosDelSitio
            // 
            this.btnUsuariosDelSitio.Activecolor = System.Drawing.Color.Transparent;
            this.btnUsuariosDelSitio.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuariosDelSitio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuariosDelSitio.BorderRadius = 0;
            this.btnUsuariosDelSitio.ButtonText = "   USUARIOS DEL SITIO";
            this.btnUsuariosDelSitio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuariosDelSitio.DisabledColor = System.Drawing.Color.Gray;
            this.btnUsuariosDelSitio.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUsuariosDelSitio.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnUsuariosDelSitio.Iconimage")));
            this.btnUsuariosDelSitio.Iconimage_right = null;
            this.btnUsuariosDelSitio.Iconimage_right_Selected = null;
            this.btnUsuariosDelSitio.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnUsuariosDelSitio.Iconimage_Selected")));
            this.btnUsuariosDelSitio.IconMarginLeft = 0;
            this.btnUsuariosDelSitio.IconMarginRight = 0;
            this.btnUsuariosDelSitio.IconRightVisible = true;
            this.btnUsuariosDelSitio.IconRightZoom = 0D;
            this.btnUsuariosDelSitio.IconVisible = true;
            this.btnUsuariosDelSitio.IconZoom = 70D;
            this.btnUsuariosDelSitio.IsTab = true;
            this.btnUsuariosDelSitio.Location = new System.Drawing.Point(12, 680);
            this.btnUsuariosDelSitio.Name = "btnUsuariosDelSitio";
            this.btnUsuariosDelSitio.Normalcolor = System.Drawing.Color.Transparent;
            this.btnUsuariosDelSitio.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnUsuariosDelSitio.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnUsuariosDelSitio.selected = false;
            this.btnUsuariosDelSitio.Size = new System.Drawing.Size(236, 40);
            this.btnUsuariosDelSitio.TabIndex = 11;
            this.btnUsuariosDelSitio.Text = "   USUARIOS DEL SITIO";
            this.btnUsuariosDelSitio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuariosDelSitio.Textcolor = System.Drawing.Color.White;
            this.btnUsuariosDelSitio.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnUsuariosDelSitio.Click += new System.EventHandler(this.btnUsuariosDelSitio_Click);
            // 
            // btnGanancias
            // 
            this.btnGanancias.Activecolor = System.Drawing.Color.Transparent;
            this.btnGanancias.BackColor = System.Drawing.Color.Transparent;
            this.btnGanancias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGanancias.BorderRadius = 0;
            this.btnGanancias.ButtonText = "   GANANCIAS";
            this.btnGanancias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGanancias.DisabledColor = System.Drawing.Color.Gray;
            this.btnGanancias.Iconcolor = System.Drawing.Color.Transparent;
            this.btnGanancias.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnGanancias.Iconimage")));
            this.btnGanancias.Iconimage_right = null;
            this.btnGanancias.Iconimage_right_Selected = null;
            this.btnGanancias.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnGanancias.Iconimage_Selected")));
            this.btnGanancias.IconMarginLeft = 0;
            this.btnGanancias.IconMarginRight = 0;
            this.btnGanancias.IconRightVisible = true;
            this.btnGanancias.IconRightZoom = 0D;
            this.btnGanancias.IconVisible = true;
            this.btnGanancias.IconZoom = 70D;
            this.btnGanancias.IsTab = true;
            this.btnGanancias.Location = new System.Drawing.Point(12, 621);
            this.btnGanancias.Name = "btnGanancias";
            this.btnGanancias.Normalcolor = System.Drawing.Color.Transparent;
            this.btnGanancias.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnGanancias.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnGanancias.selected = false;
            this.btnGanancias.Size = new System.Drawing.Size(236, 40);
            this.btnGanancias.TabIndex = 10;
            this.btnGanancias.Text = "   GANANCIAS";
            this.btnGanancias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGanancias.Textcolor = System.Drawing.Color.White;
            this.btnGanancias.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnGanancias.Click += new System.EventHandler(this.btnGanancias_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Activecolor = System.Drawing.Color.Transparent;
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashboard.BorderRadius = 0;
            this.btnDashboard.ButtonText = "   DASHBOARD";
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.DisabledColor = System.Drawing.Color.Gray;
            this.btnDashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Iconimage")));
            this.btnDashboard.Iconimage_right = null;
            this.btnDashboard.Iconimage_right_Selected = null;
            this.btnDashboard.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Iconimage_Selected")));
            this.btnDashboard.IconMarginLeft = 0;
            this.btnDashboard.IconMarginRight = 0;
            this.btnDashboard.IconRightVisible = true;
            this.btnDashboard.IconRightZoom = 0D;
            this.btnDashboard.IconVisible = true;
            this.btnDashboard.IconZoom = 70D;
            this.btnDashboard.IsTab = true;
            this.btnDashboard.Location = new System.Drawing.Point(12, 298);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnDashboard.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnDashboard.selected = false;
            this.btnDashboard.Size = new System.Drawing.Size(236, 40);
            this.btnDashboard.TabIndex = 9;
            this.btnDashboard.Text = "   DASHBOARD";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Textcolor = System.Drawing.Color.White;
            this.btnDashboard.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnProductosVendidos
            // 
            this.btnProductosVendidos.Activecolor = System.Drawing.Color.Transparent;
            this.btnProductosVendidos.BackColor = System.Drawing.Color.Transparent;
            this.btnProductosVendidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductosVendidos.BorderRadius = 0;
            this.btnProductosVendidos.ButtonText = "   PRODUCTOS VENDIDOS";
            this.btnProductosVendidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductosVendidos.DisabledColor = System.Drawing.Color.Gray;
            this.btnProductosVendidos.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProductosVendidos.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnProductosVendidos.Iconimage")));
            this.btnProductosVendidos.Iconimage_right = null;
            this.btnProductosVendidos.Iconimage_right_Selected = null;
            this.btnProductosVendidos.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnProductosVendidos.Iconimage_Selected")));
            this.btnProductosVendidos.IconMarginLeft = 0;
            this.btnProductosVendidos.IconMarginRight = 0;
            this.btnProductosVendidos.IconRightVisible = true;
            this.btnProductosVendidos.IconRightZoom = 0D;
            this.btnProductosVendidos.IconVisible = true;
            this.btnProductosVendidos.IconZoom = 70D;
            this.btnProductosVendidos.IsTab = true;
            this.btnProductosVendidos.Location = new System.Drawing.Point(12, 490);
            this.btnProductosVendidos.Name = "btnProductosVendidos";
            this.btnProductosVendidos.Normalcolor = System.Drawing.Color.Transparent;
            this.btnProductosVendidos.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnProductosVendidos.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnProductosVendidos.selected = false;
            this.btnProductosVendidos.Size = new System.Drawing.Size(236, 40);
            this.btnProductosVendidos.TabIndex = 8;
            this.btnProductosVendidos.Text = "   PRODUCTOS VENDIDOS";
            this.btnProductosVendidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductosVendidos.Textcolor = System.Drawing.Color.White;
            this.btnProductosVendidos.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnProductosVendidos.Click += new System.EventHandler(this.btnProductosVendidos_Click);
            // 
            // btnSubastasCerradas
            // 
            this.btnSubastasCerradas.Activecolor = System.Drawing.Color.Transparent;
            this.btnSubastasCerradas.BackColor = System.Drawing.Color.Transparent;
            this.btnSubastasCerradas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubastasCerradas.BorderRadius = 0;
            this.btnSubastasCerradas.ButtonText = "   SUBASTAS CERRADAS";
            this.btnSubastasCerradas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubastasCerradas.DisabledColor = System.Drawing.Color.Gray;
            this.btnSubastasCerradas.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSubastasCerradas.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSubastasCerradas.Iconimage")));
            this.btnSubastasCerradas.Iconimage_right = null;
            this.btnSubastasCerradas.Iconimage_right_Selected = null;
            this.btnSubastasCerradas.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnSubastasCerradas.Iconimage_Selected")));
            this.btnSubastasCerradas.IconMarginLeft = 0;
            this.btnSubastasCerradas.IconMarginRight = 0;
            this.btnSubastasCerradas.IconRightVisible = true;
            this.btnSubastasCerradas.IconRightZoom = 0D;
            this.btnSubastasCerradas.IconVisible = true;
            this.btnSubastasCerradas.IconZoom = 70D;
            this.btnSubastasCerradas.IsTab = true;
            this.btnSubastasCerradas.Location = new System.Drawing.Point(12, 361);
            this.btnSubastasCerradas.Name = "btnSubastasCerradas";
            this.btnSubastasCerradas.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSubastasCerradas.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnSubastasCerradas.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnSubastasCerradas.selected = false;
            this.btnSubastasCerradas.Size = new System.Drawing.Size(252, 40);
            this.btnSubastasCerradas.TabIndex = 7;
            this.btnSubastasCerradas.Text = "   SUBASTAS CERRADAS";
            this.btnSubastasCerradas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubastasCerradas.Textcolor = System.Drawing.Color.White;
            this.btnSubastasCerradas.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnSubastasCerradas.Click += new System.EventHandler(this.btnSubastasCerradas_Click);
            // 
            // btnSubastasAbiertas
            // 
            this.btnSubastasAbiertas.Activecolor = System.Drawing.Color.Transparent;
            this.btnSubastasAbiertas.BackColor = System.Drawing.Color.Transparent;
            this.btnSubastasAbiertas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubastasAbiertas.BorderRadius = 0;
            this.btnSubastasAbiertas.ButtonText = "   SUBASTAS ABIERTAS";
            this.btnSubastasAbiertas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubastasAbiertas.DisabledColor = System.Drawing.Color.Gray;
            this.btnSubastasAbiertas.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSubastasAbiertas.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSubastasAbiertas.Iconimage")));
            this.btnSubastasAbiertas.Iconimage_right = null;
            this.btnSubastasAbiertas.Iconimage_right_Selected = null;
            this.btnSubastasAbiertas.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnSubastasAbiertas.Iconimage_Selected")));
            this.btnSubastasAbiertas.IconMarginLeft = 0;
            this.btnSubastasAbiertas.IconMarginRight = 0;
            this.btnSubastasAbiertas.IconRightVisible = true;
            this.btnSubastasAbiertas.IconRightZoom = 0D;
            this.btnSubastasAbiertas.IconVisible = true;
            this.btnSubastasAbiertas.IconZoom = 70D;
            this.btnSubastasAbiertas.IsTab = true;
            this.btnSubastasAbiertas.Location = new System.Drawing.Point(12, 424);
            this.btnSubastasAbiertas.Name = "btnSubastasAbiertas";
            this.btnSubastasAbiertas.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSubastasAbiertas.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnSubastasAbiertas.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnSubastasAbiertas.selected = false;
            this.btnSubastasAbiertas.Size = new System.Drawing.Size(236, 40);
            this.btnSubastasAbiertas.TabIndex = 6;
            this.btnSubastasAbiertas.Text = "   SUBASTAS ABIERTAS";
            this.btnSubastasAbiertas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubastasAbiertas.Textcolor = System.Drawing.Color.White;
            this.btnSubastasAbiertas.TextFont = new System.Drawing.Font("Dubai", 10F);
            this.btnSubastasAbiertas.Click += new System.EventHandler(this.btnSubastasAbiertas_Click);
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(94, 228);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(78, 23);
            this.lblNombreUsuario.TabIndex = 3;
            this.lblNombreUsuario.Text = "Usuario";
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "TUPsubastas";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 884);
            this.Controls.Add(this.Wrapper);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.Sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
            this.Sidebar.ResumeLayout(false);
            this.Sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Flecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.PictureBox Salir;
        private System.Windows.Forms.Panel Wrapper;
        private System.Windows.Forms.Panel Sidebar;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnUsuariosDelSitio;
        private Bunifu.Framework.UI.BunifuFlatButton btnGanancias;
        private Bunifu.Framework.UI.BunifuFlatButton btnDashboard;
        private Bunifu.Framework.UI.BunifuFlatButton btnProductosVendidos;
        private Bunifu.Framework.UI.BunifuFlatButton btnSubastasCerradas;
        private Bunifu.Framework.UI.BunifuFlatButton btnSubastasAbiertas;
        private System.Windows.Forms.Label lblNombreUsuario;
        private Bunifu.Framework.UI.BunifuFlatButton btnInformes;
        private System.Windows.Forms.PictureBox Flecha;
        private Bunifu.Framework.UI.BunifuFlatButton btnProductosSinOfertas;
        private System.Windows.Forms.Panel LineShapeSidebar;
        private System.Windows.Forms.Panel panel1;
    }
}