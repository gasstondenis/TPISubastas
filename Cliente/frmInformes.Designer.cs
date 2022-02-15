
namespace Cliente
{
   partial class frmInformes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformes));
            this.dgvSubastasCerradas = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblGanancias = new System.Windows.Forms.Label();
            this.lblCaudalTotal = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnObtenerResultados = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastasCerradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubastasCerradas
            // 
            this.dgvSubastasCerradas.AllowUserToResizeColumns = false;
            this.dgvSubastasCerradas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubastasCerradas.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubastasCerradas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubastasCerradas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubastasCerradas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubastasCerradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubastasCerradas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubastasCerradas.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvSubastasCerradas.Location = new System.Drawing.Point(27, 268);
            this.dgvSubastasCerradas.Name = "dgvSubastasCerradas";
            this.dgvSubastasCerradas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSubastasCerradas.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSubastasCerradas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubastasCerradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSubastasCerradas.Size = new System.Drawing.Size(1597, 702);
            this.dgvSubastasCerradas.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(27, 57);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(383, 27);
            this.lblTitulo.TabIndex = 47;
            this.lblTitulo.Text = "CAUDAL DE VENTAS TOTAL DE LA SUBASTA:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 27);
            this.label1.TabIndex = 48;
            this.label1.Text = "GANANCIAS TOTALES PARA LA EMPRESA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(27, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 27);
            this.label2.TabIndex = 49;
            this.label2.Text = "DURACIÓN DE LA SUBASTA:";
            // 
            // lblDuracion
            // 
            this.lblDuracion.BackColor = System.Drawing.Color.Transparent;
            this.lblDuracion.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracion.ForeColor = System.Drawing.Color.Black;
            this.lblDuracion.Location = new System.Drawing.Point(510, 150);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDuracion.Size = new System.Drawing.Size(345, 39);
            this.lblDuracion.TabIndex = 52;
            this.lblDuracion.Text = "0";
            // 
            // lblGanancias
            // 
            this.lblGanancias.BackColor = System.Drawing.Color.Transparent;
            this.lblGanancias.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanancias.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblGanancias.Location = new System.Drawing.Point(545, 99);
            this.lblGanancias.Name = "lblGanancias";
            this.lblGanancias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGanancias.Size = new System.Drawing.Size(310, 42);
            this.lblGanancias.TabIndex = 51;
            this.lblGanancias.Text = "0";
            // 
            // lblCaudalTotal
            // 
            this.lblCaudalTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblCaudalTotal.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaudalTotal.ForeColor = System.Drawing.Color.Red;
            this.lblCaudalTotal.Location = new System.Drawing.Point(527, 44);
            this.lblCaudalTotal.Name = "lblCaudalTotal";
            this.lblCaudalTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCaudalTotal.Size = new System.Drawing.Size(328, 37);
            this.lblCaudalTotal.TabIndex = 50;
            this.lblCaudalTotal.Text = "0";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Silver;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.ForeColor = System.Drawing.Color.Silver;
            this.panel11.Location = new System.Drawing.Point(503, 84);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(350, 2);
            this.panel11.TabIndex = 53;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(503, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 2);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.ForeColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(503, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 2);
            this.panel2.TabIndex = 2;
            // 
            // btnObtenerResultados
            // 
            this.btnObtenerResultados.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(74)))));
            this.btnObtenerResultados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(74)))));
            this.btnObtenerResultados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnObtenerResultados.BorderRadius = 7;
            this.btnObtenerResultados.ButtonText = " Obtener resultados";
            this.btnObtenerResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObtenerResultados.DisabledColor = System.Drawing.Color.Gray;
            this.btnObtenerResultados.Iconcolor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(74)))));
            this.btnObtenerResultados.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnObtenerResultados.Iconimage")));
            this.btnObtenerResultados.Iconimage_right = null;
            this.btnObtenerResultados.Iconimage_right_Selected = null;
            this.btnObtenerResultados.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnObtenerResultados.Iconimage_Selected")));
            this.btnObtenerResultados.IconMarginLeft = 0;
            this.btnObtenerResultados.IconMarginRight = 0;
            this.btnObtenerResultados.IconRightVisible = true;
            this.btnObtenerResultados.IconRightZoom = 0D;
            this.btnObtenerResultados.IconVisible = true;
            this.btnObtenerResultados.IconZoom = 63D;
            this.btnObtenerResultados.IsTab = true;
            this.btnObtenerResultados.Location = new System.Drawing.Point(1366, 201);
            this.btnObtenerResultados.Margin = new System.Windows.Forms.Padding(4);
            this.btnObtenerResultados.Name = "btnObtenerResultados";
            this.btnObtenerResultados.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(74)))));
            this.btnObtenerResultados.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(15)))), ((int)(((byte)(44)))));
            this.btnObtenerResultados.OnHoverTextColor = System.Drawing.Color.White;
            this.btnObtenerResultados.selected = false;
            this.btnObtenerResultados.Size = new System.Drawing.Size(227, 48);
            this.btnObtenerResultados.TabIndex = 54;
            this.btnObtenerResultados.Text = " Obtener resultados";
            this.btnObtenerResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObtenerResultados.Textcolor = System.Drawing.Color.White;
            this.btnObtenerResultados.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenerResultados.Click += new System.EventHandler(this.btnObtenerResultados_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1002, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(503, 44);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(30, 37);
            this.label3.TabIndex = 56;
            this.label3.Text = "$";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(503, 104);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(30, 37);
            this.label4.TabIndex = 57;
            this.label4.Text = "$";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(496, 152);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(76, 37);
            this.label5.TabIndex = 58;
            this.label5.Text = "DIAS";
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1650, 1000);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnObtenerResultados);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblGanancias);
            this.Controls.Add(this.lblCaudalTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvSubastasCerradas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInformes";
            this.Text = "frmInformes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastasCerradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView dgvSubastasCerradas;
      internal System.Windows.Forms.Label lblTitulo;
      internal System.Windows.Forms.Label label1;
      internal System.Windows.Forms.Label label2;
      internal System.Windows.Forms.Label lblDuracion;
      internal System.Windows.Forms.Label lblGanancias;
      internal System.Windows.Forms.Label lblCaudalTotal;
      private System.Windows.Forms.Panel panel11;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private Bunifu.Framework.UI.BunifuFlatButton btnObtenerResultados;
      private System.Windows.Forms.PictureBox pictureBox1;
      internal System.Windows.Forms.Label label3;
      internal System.Windows.Forms.Label label4;
      internal System.Windows.Forms.Label label5;
   }
}