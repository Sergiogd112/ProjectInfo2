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
            this.cicloBox = new System.Windows.Forms.TextBox();
            this.distanciaSeguridadBox = new System.Windows.Forms.TextBox();
            this.cicloLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aceptarButton
            // 
            this.aceptarButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aceptarButton.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.aceptarButton.FlatAppearance.BorderSize = 3;
            this.aceptarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButton.Location = new System.Drawing.Point(506, 328);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(155, 51);
            this.aceptarButton.TabIndex = 9;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = false;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cicloBox
            // 
            this.cicloBox.BackColor = System.Drawing.Color.AliceBlue;
            this.cicloBox.Location = new System.Drawing.Point(476, 205);
            this.cicloBox.Name = "cicloBox";
            this.cicloBox.Size = new System.Drawing.Size(224, 31);
            this.cicloBox.TabIndex = 8;
            // 
            // distanciaSeguridadBox
            // 
            this.distanciaSeguridadBox.BackColor = System.Drawing.Color.AliceBlue;
            this.distanciaSeguridadBox.Location = new System.Drawing.Point(476, 84);
            this.distanciaSeguridadBox.Name = "distanciaSeguridadBox";
            this.distanciaSeguridadBox.Size = new System.Drawing.Size(224, 31);
            this.distanciaSeguridadBox.TabIndex = 7;
            // 
            // cicloLabel
            // 
            this.cicloLabel.AutoSize = true;
            this.cicloLabel.BackColor = System.Drawing.Color.Transparent;
            this.cicloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cicloLabel.ForeColor = System.Drawing.Color.Black;
            this.cicloLabel.Location = new System.Drawing.Point(100, 207);
            this.cicloLabel.Name = "cicloLabel";
            this.cicloLabel.Size = new System.Drawing.Size(202, 29);
            this.cicloLabel.TabIndex = 6;
            this.cicloLabel.Text = "Tiempo de ciclo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(100, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Distancia de Seguridad";
            // 
            // IntroducirParametrosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::Flight_Forms.Properties.Resources.imagen3;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.cicloBox);
            this.Controls.Add(this.distanciaSeguridadBox);
            this.Controls.Add(this.cicloLabel);
            this.Controls.Add(this.label1);
            this.Name = "IntroducirParametrosForm";
            this.Text = "Introducir Parámetros de Simulación";
            this.Load += new System.EventHandler(this.IntroducirParametrosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.TextBox cicloBox;
        private System.Windows.Forms.TextBox distanciaSeguridadBox;
        private System.Windows.Forms.Label cicloLabel;
        private System.Windows.Forms.Label label1;
    }
}