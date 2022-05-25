
namespace Flight_Forms
{
    partial class GuardarComo
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
            this.label1 = new System.Windows.Forms.Label();
            this.Aceptar = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre que desee para guardar el fichero";
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(116, 198);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(140, 55);
            this.Aceptar.TabIndex = 2;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(76, 123);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(220, 22);
            this.Nombre.TabIndex = 3;
            // 
            // GuardarComo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(378, 327);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.label1);
            this.Name = "GuardarComo";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.TextBox Nombre;
    }
}