namespace Administracion_ETRAY
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bebidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bebidaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comidaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bebidaToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.comidaToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.fotoGrafiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bebidaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.comidaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bebidaToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.comidaToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarDatosDeConexiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCuentaMenu = new System.Windows.Forms.Button();
            this.btnMesasMenu = new System.Windows.Forms.Button();
            this.pictureBoxPDF = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenuCierre = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.nuevoProductoToolStripMenuItem,
            this.editarProductoToolStripMenuItem,
            this.eToolStripMenuItem,
            this.editarDatosDeConexiToolStripMenuItem,
            this.mesasToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cuentasToolStripMenuItem
            // 
            this.cuentasToolStripMenuItem.Name = "cuentasToolStripMenuItem";
            this.cuentasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.cuentasToolStripMenuItem.Text = "Cuentas";
            this.cuentasToolStripMenuItem.Click += new System.EventHandler(this.cuentasToolStripMenuItem_Click);
            // 
            // nuevoProductoToolStripMenuItem
            // 
            this.nuevoProductoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bebidaToolStripMenuItem,
            this.comidaToolStripMenuItem});
            this.nuevoProductoToolStripMenuItem.Name = "nuevoProductoToolStripMenuItem";
            this.nuevoProductoToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.nuevoProductoToolStripMenuItem.Text = "Nuevo Producto";
            // 
            // bebidaToolStripMenuItem
            // 
            this.bebidaToolStripMenuItem.Name = "bebidaToolStripMenuItem";
            this.bebidaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.bebidaToolStripMenuItem.Text = "Bebida";
            this.bebidaToolStripMenuItem.Click += new System.EventHandler(this.bebidaToolStripMenuItem_Click);
            // 
            // comidaToolStripMenuItem
            // 
            this.comidaToolStripMenuItem.Name = "comidaToolStripMenuItem";
            this.comidaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.comidaToolStripMenuItem.Text = "Comida";
            this.comidaToolStripMenuItem.Click += new System.EventHandler(this.comidaToolStripMenuItem_Click);
            // 
            // editarProductoToolStripMenuItem
            // 
            this.editarProductoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.precioToolStripMenuItem,
            this.nombreToolStripMenuItem,
            this.fotoGrafiaToolStripMenuItem,
            this.ocultarProductoToolStripMenuItem});
            this.editarProductoToolStripMenuItem.Name = "editarProductoToolStripMenuItem";
            this.editarProductoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.editarProductoToolStripMenuItem.Text = "Editar Producto";
            // 
            // precioToolStripMenuItem
            // 
            this.precioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bebidaToolStripMenuItem1,
            this.comidaToolStripMenuItem1});
            this.precioToolStripMenuItem.Name = "precioToolStripMenuItem";
            this.precioToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.precioToolStripMenuItem.Text = "Precio";
            // 
            // bebidaToolStripMenuItem1
            // 
            this.bebidaToolStripMenuItem1.Name = "bebidaToolStripMenuItem1";
            this.bebidaToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.bebidaToolStripMenuItem1.Text = "Bebida";
            this.bebidaToolStripMenuItem1.Click += new System.EventHandler(this.bebidaToolStripMenuItem1_Click);
            // 
            // comidaToolStripMenuItem1
            // 
            this.comidaToolStripMenuItem1.Name = "comidaToolStripMenuItem1";
            this.comidaToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.comidaToolStripMenuItem1.Text = "Comida";
            this.comidaToolStripMenuItem1.Click += new System.EventHandler(this.comidaToolStripMenuItem1_Click);
            // 
            // nombreToolStripMenuItem
            // 
            this.nombreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bebidaToolStripMenuItem3,
            this.comidaToolStripMenuItem3});
            this.nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            this.nombreToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.nombreToolStripMenuItem.Text = "Nombre";
            // 
            // bebidaToolStripMenuItem3
            // 
            this.bebidaToolStripMenuItem3.Name = "bebidaToolStripMenuItem3";
            this.bebidaToolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.bebidaToolStripMenuItem3.Text = "Bebida";
            this.bebidaToolStripMenuItem3.Click += new System.EventHandler(this.bebidaToolStripMenuItem3_Click);
            // 
            // comidaToolStripMenuItem3
            // 
            this.comidaToolStripMenuItem3.Name = "comidaToolStripMenuItem3";
            this.comidaToolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.comidaToolStripMenuItem3.Text = "Comida";
            this.comidaToolStripMenuItem3.Click += new System.EventHandler(this.comidaToolStripMenuItem3_Click);
            // 
            // fotoGrafiaToolStripMenuItem
            // 
            this.fotoGrafiaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bebidaToolStripMenuItem2,
            this.comidaToolStripMenuItem2});
            this.fotoGrafiaToolStripMenuItem.Name = "fotoGrafiaToolStripMenuItem";
            this.fotoGrafiaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.fotoGrafiaToolStripMenuItem.Text = "Fotografia";
            this.fotoGrafiaToolStripMenuItem.Click += new System.EventHandler(this.fotoGrafiaToolStripMenuItem_Click);
            // 
            // bebidaToolStripMenuItem2
            // 
            this.bebidaToolStripMenuItem2.Name = "bebidaToolStripMenuItem2";
            this.bebidaToolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.bebidaToolStripMenuItem2.Text = "Bebida";
            this.bebidaToolStripMenuItem2.Click += new System.EventHandler(this.bebidaToolStripMenuItem2_Click);
            // 
            // comidaToolStripMenuItem2
            // 
            this.comidaToolStripMenuItem2.Name = "comidaToolStripMenuItem2";
            this.comidaToolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.comidaToolStripMenuItem2.Text = "Comida";
            this.comidaToolStripMenuItem2.Click += new System.EventHandler(this.comidaToolStripMenuItem2_Click);
            // 
            // ocultarProductoToolStripMenuItem
            // 
            this.ocultarProductoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bebidaToolStripMenuItem4,
            this.comidaToolStripMenuItem4});
            this.ocultarProductoToolStripMenuItem.Name = "ocultarProductoToolStripMenuItem";
            this.ocultarProductoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ocultarProductoToolStripMenuItem.Text = "Ocultar Producto";
            // 
            // bebidaToolStripMenuItem4
            // 
            this.bebidaToolStripMenuItem4.Name = "bebidaToolStripMenuItem4";
            this.bebidaToolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.bebidaToolStripMenuItem4.Text = "Bebida";
            this.bebidaToolStripMenuItem4.Click += new System.EventHandler(this.bebidaToolStripMenuItem4_Click);
            // 
            // comidaToolStripMenuItem4
            // 
            this.comidaToolStripMenuItem4.Name = "comidaToolStripMenuItem4";
            this.comidaToolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.comidaToolStripMenuItem4.Text = "Comida";
            this.comidaToolStripMenuItem4.Click += new System.EventHandler(this.comidaToolStripMenuItem4_Click);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.eToolStripMenuItem.Text = "Nueva Tablet";
            this.eToolStripMenuItem.Click += new System.EventHandler(this.NuevaTabletToolStripMenuItem_Click);
            // 
            // editarDatosDeConexiToolStripMenuItem
            // 
            this.editarDatosDeConexiToolStripMenuItem.Name = "editarDatosDeConexiToolStripMenuItem";
            this.editarDatosDeConexiToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.editarDatosDeConexiToolStripMenuItem.Text = "Datos Conexion";
            this.editarDatosDeConexiToolStripMenuItem.Click += new System.EventHandler(this.editarDatosDeConexiToolStripMenuItem_Click);
            // 
            // mesasToolStripMenuItem
            // 
            this.mesasToolStripMenuItem.Name = "mesasToolStripMenuItem";
            this.mesasToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.mesasToolStripMenuItem.Text = "Mesas";
            this.mesasToolStripMenuItem.Click += new System.EventHandler(this.mesasToolStripMenuItem_Click);
            // 
            // btnCuentaMenu
            // 
            this.btnCuentaMenu.BackColor = System.Drawing.Color.White;
            this.btnCuentaMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCuentaMenu.Font = new System.Drawing.Font("Lucida Sans Unicode", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnCuentaMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCuentaMenu.Location = new System.Drawing.Point(30, 81);
            this.btnCuentaMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnCuentaMenu.Name = "btnCuentaMenu";
            this.btnCuentaMenu.Size = new System.Drawing.Size(166, 50);
            this.btnCuentaMenu.TabIndex = 23;
            this.btnCuentaMenu.Text = "Cuentas";
            this.btnCuentaMenu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCuentaMenu.UseVisualStyleBackColor = false;
            this.btnCuentaMenu.Click += new System.EventHandler(this.btnCuentaMenu_Click);
            // 
            // btnMesasMenu
            // 
            this.btnMesasMenu.BackColor = System.Drawing.Color.White;
            this.btnMesasMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMesasMenu.Font = new System.Drawing.Font("Lucida Sans Unicode", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnMesasMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMesasMenu.Location = new System.Drawing.Point(30, 169);
            this.btnMesasMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnMesasMenu.Name = "btnMesasMenu";
            this.btnMesasMenu.Size = new System.Drawing.Size(166, 50);
            this.btnMesasMenu.TabIndex = 24;
            this.btnMesasMenu.Text = "Mesas";
            this.btnMesasMenu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMesasMenu.UseVisualStyleBackColor = false;
            this.btnMesasMenu.Click += new System.EventHandler(this.btnMesasMenu_Click);
            // 
            // pictureBoxPDF
            // 
            this.pictureBoxPDF.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPDF.Image")));
            this.pictureBoxPDF.Location = new System.Drawing.Point(715, 321);
            this.pictureBoxPDF.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPDF.Name = "pictureBoxPDF";
            this.pictureBoxPDF.Size = new System.Drawing.Size(34, 39);
            this.pictureBoxPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPDF.TabIndex = 2;
            this.pictureBoxPDF.TabStop = false;
            this.pictureBoxPDF.Click += new System.EventHandler(this.pictureBoxPDF_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, -193);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(709, 800);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnMenuCierre
            // 
            this.btnMenuCierre.BackColor = System.Drawing.Color.White;
            this.btnMenuCierre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenuCierre.Font = new System.Drawing.Font("Lucida Sans Unicode", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnMenuCierre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMenuCierre.Location = new System.Drawing.Point(546, 68);
            this.btnMenuCierre.Margin = new System.Windows.Forms.Padding(2);
            this.btnMenuCierre.Name = "btnMenuCierre";
            this.btnMenuCierre.Size = new System.Drawing.Size(166, 50);
            this.btnMenuCierre.TabIndex = 25;
            this.btnMenuCierre.Text = "Cierre Dia";
            this.btnMenuCierre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuCierre.UseVisualStyleBackColor = false;
            this.btnMenuCierre.Click += new System.EventHandler(this.btnMenuCierre_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 377);
            this.Controls.Add(this.btnMenuCierre);
            this.Controls.Add(this.btnMesasMenu);
            this.Controls.Add(this.btnCuentaMenu);
            this.Controls.Add(this.pictureBoxPDF);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-TRAY ADMINISTRADOR";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bebidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bebidaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem comidaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fotoGrafiaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem bebidaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem comidaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem comidaToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem bebidaToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem editarDatosDeConexiToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxPDF;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem;
        private System.Windows.Forms.Button btnCuentaMenu;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesasToolStripMenuItem;
        private System.Windows.Forms.Button btnMesasMenu;
        private System.Windows.Forms.ToolStripMenuItem ocultarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bebidaToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem comidaToolStripMenuItem4;
        private System.Windows.Forms.Button btnMenuCierre;
    }
}

