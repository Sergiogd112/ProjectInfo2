
namespace Flight_Forms
{
    partial class Informaciónvuelo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Xbox = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Ybox = new System.Windows.Forms.Label();
            this.Velocidad = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID vuelo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Posicion actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 280);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Velocidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(418, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y";
            // 
            // Xbox
            // 
            this.Xbox.AutoSize = true;
            this.Xbox.Location = new System.Drawing.Point(270, 195);
            this.Xbox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Xbox.Name = "Xbox";
            this.Xbox.Size = new System.Drawing.Size(61, 25);
            this.Xbox.TabIndex = 4;
            this.Xbox.Text = "Xbox";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(286, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "X";
            // 
            // Ybox
            // 
            this.Ybox.AutoSize = true;
            this.Ybox.Location = new System.Drawing.Point(400, 195);
            this.Ybox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Ybox.Name = "Ybox";
            this.Ybox.Size = new System.Drawing.Size(62, 25);
            this.Ybox.TabIndex = 6;
            this.Ybox.Text = "Ybox";
            // 
            // Velocidad
            // 
            this.Velocidad.AutoSize = true;
            this.Velocidad.Location = new System.Drawing.Point(212, 280);
            this.Velocidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.Size = new System.Drawing.Size(104, 25);
            this.Velocidad.TabIndex = 7;
            this.Velocidad.Text = "velocidad";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(260, 83);
            this.id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(29, 25);
            this.id.TabIndex = 8;
            this.id.Text = "id";
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(162, 455);
            this.Cerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(234, 84);
            this.Cerrar.TabIndex = 9;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Informaciónvuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 610);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.id);
            this.Controls.Add(this.Velocidad);
            this.Controls.Add(this.Ybox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Xbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Informaciónvuelo";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Informaciónvuelo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Xbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Ybox;
        private System.Windows.Forms.Label Velocidad;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Button Cerrar;
    }
}