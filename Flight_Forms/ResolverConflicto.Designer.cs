
namespace Flight_Forms
{
    partial class ResolverConflicto
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
            this.Si = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.emailIn = new System.Windows.Forms.TextBox();
            this.emailerr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conflicto. Desea resolverlo?";
            // 
            // Si
            // 
            this.Si.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Si.Location = new System.Drawing.Point(158, 230);
            this.Si.Name = "Si";
            this.Si.Size = new System.Drawing.Size(165, 74);
            this.Si.TabIndex = 2;
            this.Si.Text = "Si";
            this.Si.UseVisualStyleBackColor = true;
            this.Si.Click += new System.EventHandler(this.Si_Click);
            // 
            // No
            // 
            this.No.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.No.Location = new System.Drawing.Point(483, 230);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(165, 74);
            this.No.TabIndex = 3;
            this.No.Text = "No";
            this.No.UseVisualStyleBackColor = true;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // emailIn
            // 
            this.emailIn.Location = new System.Drawing.Point(169, 170);
            this.emailIn.Name = "emailIn";
            this.emailIn.Size = new System.Drawing.Size(478, 22);
            this.emailIn.TabIndex = 1;
            // 
            // emailerr
            // 
            this.emailerr.AutoSize = true;
            this.emailerr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailerr.ForeColor = System.Drawing.Color.IndianRed;
            this.emailerr.Location = new System.Drawing.Point(344, 136);
            this.emailerr.Name = "emailerr";
            this.emailerr.Size = new System.Drawing.Size(101, 20);
            this.emailerr.TabIndex = 4;
            this.emailerr.Text = "Check email";
            this.emailerr.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "EMail";
            // 
            // ResolverConflicto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.emailerr);
            this.Controls.Add(this.emailIn);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Si);
            this.Controls.Add(this.label1);
            this.Name = "ResolverConflicto";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ResolverConflicto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Si;
        private System.Windows.Forms.Button No;
        private System.Windows.Forms.TextBox emailIn;
        private System.Windows.Forms.Label emailerr;
        private System.Windows.Forms.Label label2;
    }
}