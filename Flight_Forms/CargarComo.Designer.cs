
namespace Flight_Forms
{
    partial class CargarComo
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
            this.NombreFichero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cargarfichero = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NombreFichero
            // 
            this.NombreFichero.Location = new System.Drawing.Point(90, 107);
            this.NombreFichero.Name = "NombreFichero";
            this.NombreFichero.Size = new System.Drawing.Size(187, 22);
            this.NombreFichero.TabIndex = 0;
            this.NombreFichero.TextChanged += new System.EventHandler(this.NombreFichero_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Introduzca el nombre del fichero";
            // 
            // Cargarfichero
            // 
            this.Cargarfichero.Location = new System.Drawing.Point(103, 185);
            this.Cargarfichero.Name = "Cargarfichero";
            this.Cargarfichero.Size = new System.Drawing.Size(158, 49);
            this.Cargarfichero.TabIndex = 2;
            this.Cargarfichero.Text = "Cargar fichero";
            this.Cargarfichero.UseVisualStyleBackColor = true;
            this.Cargarfichero.Click += new System.EventHandler(this.Cargarfichero_Click);
            // 
            // CargarComo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(367, 328);
            this.Controls.Add(this.Cargarfichero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NombreFichero);
            this.Name = "CargarComo";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NombreFichero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cargarfichero;
    }
}