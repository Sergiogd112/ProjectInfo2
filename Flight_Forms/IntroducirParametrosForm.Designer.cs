namespace Flight_Forms
{
    partial class IntroducirParametrosForm
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
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cicloLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.distanciaSeguridadBox = new System.Windows.Forms.NumericUpDown();
            this.cicloBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.distanciaSeguridadBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cicloBox)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptarButton
            // 
            this.aceptarButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aceptarButton.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.aceptarButton.FlatAppearance.BorderSize = 3;
            this.aceptarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButton.Location = new System.Drawing.Point(337, 210);
            this.aceptarButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(103, 33);
            this.aceptarButton.TabIndex = 9;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = false;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cicloLabel
            // 
            this.cicloLabel.AutoSize = true;
            this.cicloLabel.BackColor = System.Drawing.Color.Transparent;
            this.cicloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cicloLabel.ForeColor = System.Drawing.Color.Black;
            this.cicloLabel.Location = new System.Drawing.Point(67, 132);
            this.cicloLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cicloLabel.Name = "cicloLabel";
            this.cicloLabel.Size = new System.Drawing.Size(128, 18);
            this.cicloLabel.TabIndex = 6;
            this.cicloLabel.Text = "Tiempo de ciclo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(67, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Distancia de Seguridad";
            // 
            // distanciaSeguridadBox
            // 
            this.distanciaSeguridadBox.DecimalPlaces = 1;
            this.distanciaSeguridadBox.Location = new System.Drawing.Point(337, 54);
            this.distanciaSeguridadBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.distanciaSeguridadBox.Name = "distanciaSeguridadBox";
            this.distanciaSeguridadBox.Size = new System.Drawing.Size(120, 22);
            this.distanciaSeguridadBox.TabIndex = 22;
            this.distanciaSeguridadBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cicloBox
            // 
            this.cicloBox.Location = new System.Drawing.Point(337, 132);
            this.cicloBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cicloBox.Name = "cicloBox";
            this.cicloBox.Size = new System.Drawing.Size(120, 22);
            this.cicloBox.TabIndex = 23;
            this.cicloBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // IntroducirParametrosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::Flight_Forms.Properties.Resources.imagen3;
            this.ClientSize = new System.Drawing.Size(533, 288);
            this.Controls.Add(this.cicloBox);
            this.Controls.Add(this.distanciaSeguridadBox);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.cicloLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "IntroducirParametrosForm";
            this.Text = "Introducir Parámetros de Simulación";
            this.Load += new System.EventHandler(this.IntroducirParametrosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.distanciaSeguridadBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cicloBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


#endregion


        private System.Windows.Forms.Button aceptarButton;

        private System.Windows.Forms.Label cicloLabel;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown distanciaSeguridadBox;
        private System.Windows.Forms.NumericUpDown cicloBox;
    }
}
