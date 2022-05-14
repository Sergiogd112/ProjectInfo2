namespace Flight_Forms
{
    partial class GenerarVuelos
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
            this.NumeroLab = new System.Windows.Forms.Label();
            this.NumeroIn = new System.Windows.Forms.NumericUpDown();
            this.ReintentosIn = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.VelocidadMaxIn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.VelocidadMinIn = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.DistMaxIn = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.DistMinIn = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.GenerarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReintentosIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelocidadMaxIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelocidadMinIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistMaxIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistMinIn)).BeginInit();
            this.SuspendLayout();
            // 
            // NumeroLab
            // 
            this.NumeroLab.AutoSize = true;
            this.NumeroLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.NumeroLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumeroLab.Location = new System.Drawing.Point(85, 75);
            this.NumeroLab.Name = "NumeroLab";
            this.NumeroLab.Size = new System.Drawing.Size(209, 20);
            this.NumeroLab.TabIndex = 0;
            this.NumeroLab.Text = "Numero de vuelos a añadir";
            // 
            // NumeroIn
            // 
            this.NumeroIn.Location = new System.Drawing.Point(89, 118);
            this.NumeroIn.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumeroIn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumeroIn.Name = "NumeroIn";
            this.NumeroIn.Size = new System.Drawing.Size(205, 22);
            this.NumeroIn.TabIndex = 2;
            this.NumeroIn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ReintentosIn
            // 
            this.ReintentosIn.Location = new System.Drawing.Point(89, 206);
            this.ReintentosIn.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ReintentosIn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ReintentosIn.Name = "ReintentosIn";
            this.ReintentosIn.Size = new System.Drawing.Size(205, 22);
            this.ReintentosIn.TabIndex = 4;
            this.ReintentosIn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero de intentos por vuelo";
            // 
            // VelocidadMaxIn
            // 
            this.VelocidadMaxIn.DecimalPlaces = 1;
            this.VelocidadMaxIn.Location = new System.Drawing.Point(89, 382);
            this.VelocidadMaxIn.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.VelocidadMaxIn.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.VelocidadMaxIn.Name = "VelocidadMaxIn";
            this.VelocidadMaxIn.Size = new System.Drawing.Size(205, 22);
            this.VelocidadMaxIn.TabIndex = 8;
            this.VelocidadMaxIn.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Velocidad máxima";
            // 
            // VelocidadMinIn
            // 
            this.VelocidadMinIn.DecimalPlaces = 1;
            this.VelocidadMinIn.Location = new System.Drawing.Point(89, 294);
            this.VelocidadMinIn.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.VelocidadMinIn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VelocidadMinIn.Name = "VelocidadMinIn";
            this.VelocidadMinIn.Size = new System.Drawing.Size(205, 22);
            this.VelocidadMinIn.TabIndex = 6;
            this.VelocidadMinIn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Velocidad mínima";
            // 
            // DistMaxIn
            // 
            this.DistMaxIn.DecimalPlaces = 1;
            this.DistMaxIn.Location = new System.Drawing.Point(480, 206);
            this.DistMaxIn.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.DistMaxIn.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.DistMaxIn.Name = "DistMaxIn";
            this.DistMaxIn.Size = new System.Drawing.Size(205, 22);
            this.DistMaxIn.TabIndex = 12;
            this.DistMaxIn.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Distancia máxima";
            // 
            // DistMinIn
            // 
            this.DistMinIn.DecimalPlaces = 1;
            this.DistMinIn.Location = new System.Drawing.Point(480, 118);
            this.DistMinIn.Maximum = new decimal(new int[] {
            499,
            0,
            0,
            0});
            this.DistMinIn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DistMinIn.Name = "DistMinIn";
            this.DistMinIn.Size = new System.Drawing.Size(205, 22);
            this.DistMinIn.TabIndex = 10;
            this.DistMinIn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(476, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Distancia mínima";
            // 
            // GenerarButton
            // 
            this.GenerarButton.Location = new System.Drawing.Point(480, 339);
            this.GenerarButton.Name = "GenerarButton";
            this.GenerarButton.Size = new System.Drawing.Size(205, 32);
            this.GenerarButton.TabIndex = 13;
            this.GenerarButton.Text = "Generar";
            this.GenerarButton.UseVisualStyleBackColor = true;
            this.GenerarButton.Click += new System.EventHandler(this.GenerarButton_Click);
            // 
            // GenerarVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Flight_Forms.Properties.Resources.plane_4972663;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GenerarButton);
            this.Controls.Add(this.DistMaxIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DistMinIn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VelocidadMaxIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VelocidadMinIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ReintentosIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumeroIn);
            this.Controls.Add(this.NumeroLab);
            this.DoubleBuffered = true;
            this.Name = "GenerarVuelos";
            this.Text = "Generar planes de vuelo";
            ((System.ComponentModel.ISupportInitialize)(this.NumeroIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReintentosIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelocidadMaxIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelocidadMinIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistMaxIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistMinIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumeroLab;
        private System.Windows.Forms.NumericUpDown NumeroIn;
        private System.Windows.Forms.NumericUpDown ReintentosIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown VelocidadMaxIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown VelocidadMinIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown DistMaxIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DistMinIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button GenerarButton;
    }
}