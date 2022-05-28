namespace Flight_Forms
{
    partial class Espacioaerio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Espacioaerio));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.coordenadas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.manualButton = new System.Windows.Forms.Button();
            this.autoButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.reiniciarButton = new System.Windows.Forms.Button();
            this.retroButt = new System.Windows.Forms.Button();
            this.resolverLab = new System.Windows.Forms.Label();
            this.timerconflictos = new System.Windows.Forms.Timer(this.components);
            this.AVISO = new System.Windows.Forms.Button();
            this.LabelConflicto = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoAvionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeVuelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosDelVueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarVuelosToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Parar = new System.Windows.Forms.Button();
            this.Conflicto = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.planeImg = new System.Windows.Forms.PictureBox();
            this.cargar = new System.Windows.Forms.OpenFileDialog();
            this.guardar = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1102, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "799";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(296, 901);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "699";
            // 
            // coordenadas
            // 
            this.coordenadas.BackColor = System.Drawing.Color.LavenderBlush;
            this.coordenadas.Location = new System.Drawing.Point(629, 109);
            this.coordenadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.coordenadas.Name = "coordenadas";
            this.coordenadas.Size = new System.Drawing.Size(219, 25);
            this.coordenadas.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(684, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Coordenadas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(675, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "(cursor en el panel)";
            // 
            // manualButton
            // 
            this.manualButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.manualButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.manualButton.FlatAppearance.BorderSize = 3;
            this.manualButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualButton.Location = new System.Drawing.Point(103, 138);
            this.manualButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(116, 37);
            this.manualButton.TabIndex = 10;
            this.manualButton.Text = "Manual";
            this.manualButton.UseVisualStyleBackColor = false;
            this.manualButton.Click += new System.EventHandler(this.manualButton_Click);
            // 
            // autoButton
            // 
            this.autoButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.autoButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.autoButton.FlatAppearance.BorderSize = 3;
            this.autoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoButton.Location = new System.Drawing.Point(103, 268);
            this.autoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(116, 38);
            this.autoButton.TabIndex = 11;
            this.autoButton.Text = "Automático";
            this.autoButton.UseVisualStyleBackColor = false;
            this.autoButton.Click += new System.EventHandler(this.autoButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mover manualmente los vuelos 1 ciclo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mover automáticamente los vuelos:";
            // 
            // reloj
            // 
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(291, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Comprovar si los vuelos entraran en conflicto:";
            // 
            // reiniciarButton
            // 
            this.reiniciarButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.reiniciarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reiniciarButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reiniciarButton.Location = new System.Drawing.Point(103, 376);
            this.reiniciarButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reiniciarButton.Name = "reiniciarButton";
            this.reiniciarButton.Size = new System.Drawing.Size(116, 40);
            this.reiniciarButton.TabIndex = 17;
            this.reiniciarButton.Text = "Reiniciar";
            this.reiniciarButton.UseVisualStyleBackColor = false;
            this.reiniciarButton.Click += new System.EventHandler(this.reiniciarButton_Click);
            // 
            // retroButt
            // 
            this.retroButt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.retroButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroButt.Location = new System.Drawing.Point(103, 189);
            this.retroButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.retroButt.Name = "retroButt";
            this.retroButt.Size = new System.Drawing.Size(116, 36);
            this.retroButt.TabIndex = 18;
            this.retroButt.Text = "Retroceder";
            this.retroButt.UseVisualStyleBackColor = false;
            this.retroButt.Click += new System.EventHandler(this.retroButt_Click);
            // 
            // resolverLab
            // 
            this.resolverLab.AutoSize = true;
            this.resolverLab.Location = new System.Drawing.Point(25, 449);
            this.resolverLab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resolverLab.Name = "resolverLab";
            this.resolverLab.Size = new System.Drawing.Size(0, 19);
            this.resolverLab.TabIndex = 20;
            // 
            // timerconflictos
            // 
            this.timerconflictos.Tick += new System.EventHandler(this.timerconflictos_Tick);
            // 
            // AVISO
            // 
            this.AVISO.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AVISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AVISO.Location = new System.Drawing.Point(103, 693);
            this.AVISO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AVISO.Name = "AVISO";
            this.AVISO.Size = new System.Drawing.Size(116, 40);
            this.AVISO.TabIndex = 22;
            this.AVISO.Text = "AVISO";
            this.AVISO.UseVisualStyleBackColor = false;
            // 
            // LabelConflicto
            // 
            this.LabelConflicto.AutoSize = true;
            this.LabelConflicto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelConflicto.Location = new System.Drawing.Point(699, 984);
            this.LabelConflicto.Name = "LabelConflicto";
            this.LabelConflicto.Size = new System.Drawing.Size(20, 29);
            this.LabelConflicto.TabIndex = 23;
            this.LabelConflicto.Text = ".";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem,
            this.archivosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1243, 28);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoAvionToolStripMenuItem,
            this.listaDeVuelosToolStripMenuItem,
            this.parametrosDelVueloToolStripMenuItem,
            this.generarVuelosToolStrip});
            this.opcionesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // nuevoAvionToolStripMenuItem
            // 
            this.nuevoAvionToolStripMenuItem.Name = "nuevoAvionToolStripMenuItem";
            this.nuevoAvionToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.nuevoAvionToolStripMenuItem.Text = "Nuevo Avion";
            this.nuevoAvionToolStripMenuItem.Click += new System.EventHandler(this.nuevoAvionToolStripMenuItem_Click);
            // 
            // listaDeVuelosToolStripMenuItem
            // 
            this.listaDeVuelosToolStripMenuItem.Name = "listaDeVuelosToolStripMenuItem";
            this.listaDeVuelosToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.listaDeVuelosToolStripMenuItem.Text = "Lista de vuelos";
            this.listaDeVuelosToolStripMenuItem.Click += new System.EventHandler(this.listaDeVuelosToolStripMenuItem_Click);
            // 
            // parametrosDelVueloToolStripMenuItem
            // 
            this.parametrosDelVueloToolStripMenuItem.Name = "parametrosDelVueloToolStripMenuItem";
            this.parametrosDelVueloToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.parametrosDelVueloToolStripMenuItem.Text = "Parametros del vuelo";
            this.parametrosDelVueloToolStripMenuItem.Click += new System.EventHandler(this.parametrosDelVueloToolStripMenuItem_Click);
            // 
            // generarVuelosToolStrip
            // 
            this.generarVuelosToolStrip.Name = "generarVuelosToolStrip";
            this.generarVuelosToolStrip.Size = new System.Drawing.Size(246, 26);
            this.generarVuelosToolStrip.Text = "Generar Vuelos";
            this.generarVuelosToolStrip.Click += new System.EventHandler(this.generarVuelosToolStrip_Click);
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cargarToolStripMenuItem.Text = "Cargar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // Parar
            // 
            this.Parar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Parar.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parar.Location = new System.Drawing.Point(103, 323);
            this.Parar.Name = "Parar";
            this.Parar.Size = new System.Drawing.Size(116, 38);
            this.Parar.TabIndex = 25;
            this.Parar.Text = "Parar";
            this.Parar.UseVisualStyleBackColor = false;
            this.Parar.Click += new System.EventHandler(this.Parar_Click);
            // 
            // Conflicto
            // 
            this.Conflicto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Conflicto.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conflicto.Location = new System.Drawing.Point(103, 481);
            this.Conflicto.Name = "Conflicto";
            this.Conflicto.Size = new System.Drawing.Size(116, 32);
            this.Conflicto.TabIndex = 26;
            this.Conflicto.Text = "Conflicto?";
            this.Conflicto.UseVisualStyleBackColor = false;
            this.Conflicto.Click += new System.EventHandler(this.Conflicto_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.planeImg);
            this.panel2.Location = new System.Drawing.Point(337, 169);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 753);
            this.panel2.TabIndex = 1;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // planeImg
            // 
            this.planeImg.BackColor = System.Drawing.Color.Transparent;
            this.planeImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("planeImg.BackgroundImage")));
            this.planeImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.planeImg.Image = ((System.Drawing.Image)(resources.GetObject("planeImg.Image")));
            this.planeImg.Location = new System.Drawing.Point(72, 84);
            this.planeImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.planeImg.Name = "planeImg";
            this.planeImg.Size = new System.Drawing.Size(79, 39);
            this.planeImg.TabIndex = 0;
            this.planeImg.TabStop = false;
            this.planeImg.Visible = false;
            // 
            // cargar
            // 
            this.cargar.FileName = "openFileDialog1";
            this.cargar.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Espacioaerio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1243, 936);
            this.Controls.Add(this.Conflicto);
            this.Controls.Add(this.Parar);
            this.Controls.Add(this.LabelConflicto);
            this.Controls.Add(this.AVISO);
            this.Controls.Add(this.resolverLab);
            this.Controls.Add(this.retroButt);
            this.Controls.Add(this.reiniciarButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.autoButton);
            this.Controls.Add(this.manualButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.coordenadas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Espacioaerio";
            this.Load += new System.EventHandler(this.Espacioaerio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.planeImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion


        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox coordenadas;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Button manualButton;

        private System.Windows.Forms.Button autoButton;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Timer reloj;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Button reiniciarButton;

        private System.Windows.Forms.Button retroButt;
        private System.Windows.Forms.PictureBox planeImg;
        private System.Windows.Forms.Label resolverLab;
        private System.Windows.Forms.Timer timerconflictos;
        private System.Windows.Forms.Button AVISO;
        private System.Windows.Forms.Label LabelConflicto;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoAvionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeVuelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosDelVueloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarVuelosToolStrip;
        private System.Windows.Forms.Button Parar;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.Button Conflicto;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog cargar;
        private System.Windows.Forms.SaveFileDialog guardar;
    }
}
