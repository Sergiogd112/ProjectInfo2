namespace Flight_Forms
{
    partial class TablaAviones
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1))
                .BeginInit();
            this.SuspendLayout();

            //

            // dataGridView1
            //

            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                System
                    .Windows
                    .Forms
                    .DataGridViewColumnHeadersHeightSizeMode
                    .AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 48);
            this.dataGridView1.Margin =
                new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(768, 404);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this
                        .dataGridView1_CellContentClick_1);

            //

            // Cerrar
            //

            this.Cerrar.BackColor = System.Drawing.Color.AliceBlue;
            this.Cerrar.Location = new System.Drawing.Point(382, 545);
            this.Cerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(140, 52);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = false;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click_1);

            //

            // TablaAviones
            //

            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(936, 691);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TablaAviones";
            this.Text = "Tabla informativa de planes de vuelo";
            this.Load += new System.EventHandler(this.TablaAviones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1))
                .EndInit();
            this.ResumeLayout(false);
        }


#endregion


        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Button Cerrar;
    }
}
