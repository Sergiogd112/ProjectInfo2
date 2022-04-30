namespace Flight_Forms
{
    partial class PrincipalForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oPCIONESToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.leerDeFicheroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirDatosDeVueloToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirParametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSimulacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeVuelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirDatosDeVueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirParámetrosDeSimulaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarFicheroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardar = new System.Windows.Forms.SaveFileDialog();
            this.cargar = new System.Windows.Forms.OpenFileDialog();
            this.guardarFicheroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPCIONESToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(650, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oPCIONESToolStripMenuItem1
            // 
            this.oPCIONESToolStripMenuItem1.BackColor = System.Drawing.Color.Thistle;
            this.oPCIONESToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leerDeFicheroToolStripMenuItem,
            this.introducirDatosDeVueloToolStripMenuItem1,
            this.introducirParametrosToolStripMenuItem,
            this.iniciarSimulacionToolStripMenuItem,
            this.listaDeVuelosToolStripMenuItem,
            this.cargarFicheroToolStripMenuItem,
            this.guardarFicheroToolStripMenuItem});
            this.oPCIONESToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oPCIONESToolStripMenuItem1.Name = "oPCIONESToolStripMenuItem1";
            this.oPCIONESToolStripMenuItem1.Size = new System.Drawing.Size(153, 38);
            this.oPCIONESToolStripMenuItem1.Text = "OPCIONES";
            this.oPCIONESToolStripMenuItem1.Click += new System.EventHandler(this.oPCIONESToolStripMenuItem1_Click);
            // 
            // leerDeFicheroToolStripMenuItem
            // 
            this.leerDeFicheroToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.leerDeFicheroToolStripMenuItem.Name = "leerDeFicheroToolStripMenuItem";
            this.leerDeFicheroToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.leerDeFicheroToolStripMenuItem.Text = "leer de fichero";
            this.leerDeFicheroToolStripMenuItem.Click += new System.EventHandler(this.leerDeFicheroToolStripMenuItem_Click);
            // 
            // introducirDatosDeVueloToolStripMenuItem1
            // 
            this.introducirDatosDeVueloToolStripMenuItem1.BackColor = System.Drawing.Color.Lavender;
            this.introducirDatosDeVueloToolStripMenuItem1.Name = "introducirDatosDeVueloToolStripMenuItem1";
            this.introducirDatosDeVueloToolStripMenuItem1.Size = new System.Drawing.Size(567, 44);
            this.introducirDatosDeVueloToolStripMenuItem1.Text = "Introducir datos de vuelo";
            this.introducirDatosDeVueloToolStripMenuItem1.Click += new System.EventHandler(this.introducirDatosDeVueloToolStripMenuItem1_Click);
            // 
            // introducirParametrosToolStripMenuItem
            // 
            this.introducirParametrosToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.introducirParametrosToolStripMenuItem.Name = "introducirParametrosToolStripMenuItem";
            this.introducirParametrosToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.introducirParametrosToolStripMenuItem.Text = "Introducir parámetros de simulación";
            this.introducirParametrosToolStripMenuItem.Click += new System.EventHandler(this.introducirParametrosToolStripMenuItem_Click);
            // 
            // iniciarSimulacionToolStripMenuItem
            // 
            this.iniciarSimulacionToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.iniciarSimulacionToolStripMenuItem.Name = "iniciarSimulacionToolStripMenuItem";
            this.iniciarSimulacionToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.iniciarSimulacionToolStripMenuItem.Text = "Iniciar Simulacion";
            this.iniciarSimulacionToolStripMenuItem.Click += new System.EventHandler(this.iniciarSimulacionToolStripMenuItem_Click);
            // 
            // listaDeVuelosToolStripMenuItem
            // 
            this.listaDeVuelosToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.listaDeVuelosToolStripMenuItem.Name = "listaDeVuelosToolStripMenuItem";
            this.listaDeVuelosToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.listaDeVuelosToolStripMenuItem.Text = "Lista de vuelos";
            this.listaDeVuelosToolStripMenuItem.Click += new System.EventHandler(this.listaDeVuelosToolStripMenuItem_Click_1);
            // 
            // OpcionesToolStripMenuItem
            // 
            this.OpcionesToolStripMenuItem.BackColor = System.Drawing.Color.Thistle;
            this.OpcionesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem";
            this.OpcionesToolStripMenuItem.Size = new System.Drawing.Size(153, 36);
            this.OpcionesToolStripMenuItem.Text = "OPCIONES";
            // 
            // introducirDatosDeVueloToolStripMenuItem
            // 
            this.introducirDatosDeVueloToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.introducirDatosDeVueloToolStripMenuItem.Name = "introducirDatosDeVueloToolStripMenuItem";
            this.introducirDatosDeVueloToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.introducirDatosDeVueloToolStripMenuItem.Text = "Introducir datos de vuelo";
            // 
            // introducirParámetrosDeSimulaciónToolStripMenuItem
            // 
            this.introducirParámetrosDeSimulaciónToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.introducirParámetrosDeSimulaciónToolStripMenuItem.Name = "introducirParámetrosDeSimulaciónToolStripMenuItem";
            this.introducirParámetrosDeSimulaciónToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.introducirParámetrosDeSimulaciónToolStripMenuItem.Text = "Introducir parámetros de simulación";
            // 
            // cargarFicheroToolStripMenuItem
            // 
            this.cargarFicheroToolStripMenuItem.Name = "cargarFicheroToolStripMenuItem";
            this.cargarFicheroToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.cargarFicheroToolStripMenuItem.Text = "Cargar fichero";
            this.cargarFicheroToolStripMenuItem.Click += new System.EventHandler(this.cargarFicheroToolStripMenuItem_Click);
            // 
            // cargar
            // 
            this.cargar.FileName = "openFileDialog1";
            // 
            // guardarFicheroToolStripMenuItem
            // 
            this.guardarFicheroToolStripMenuItem.Name = "guardarFicheroToolStripMenuItem";
            this.guardarFicheroToolStripMenuItem.Size = new System.Drawing.Size(567, 44);
            this.guardarFicheroToolStripMenuItem.Text = "Guardar fichero";
            this.guardarFicheroToolStripMenuItem.Click += new System.EventHandler(this.guardarFicheroToolStripMenuItem_Click);
            // 
            // PrincipalForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImage = global::Flight_Forms.Properties.Resources.sky;
            this.ClientSize = new System.Drawing.Size(650, 515);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrincipalForm";
            this.Text = "Opciones";
            this.Load += new System.EventHandler(this.PrincipalForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducirDatosDeVueloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducirParámetrosDeSimulaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPCIONESToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem introducirDatosDeVueloToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem introducirParametrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSimulaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leerDeFicheroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSimulacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeVuelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarFicheroToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog guardar;
        private System.Windows.Forms.OpenFileDialog cargar;
        private System.Windows.Forms.ToolStripMenuItem guardarFicheroToolStripMenuItem;
    }
}

