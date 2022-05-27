namespace Flight_Forms
{
    partial class CambiarContrseñaForm
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
            this.passBx = new System.Windows.Forms.MaskedTextBox();
            this.cambiarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.checkRepPass = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkPass = new System.Windows.Forms.CheckBox();
            this.repPass = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // passBx
            // 
            this.passBx.BeepOnError = true;
            this.passBx.Culture = new System.Globalization.CultureInfo("");
            this.passBx.Location = new System.Drawing.Point(416, 156);
            this.passBx.Name = "passBx";
            this.passBx.PasswordChar = '*';
            this.passBx.RejectInputOnFirstFailure = true;
            this.passBx.Size = new System.Drawing.Size(212, 31);
            this.passBx.SkipLiterals = false;
            this.passBx.TabIndex = 4;
            // 
            // cambiarButton
            // 
            this.cambiarButton.BackColor = System.Drawing.Color.AliceBlue;
            this.cambiarButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.cambiarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cambiarButton.Location = new System.Drawing.Point(443, 288);
            this.cambiarButton.Name = "cambiarButton";
            this.cambiarButton.Size = new System.Drawing.Size(143, 39);
            this.cambiarButton.TabIndex = 9;
            this.cambiarButton.Text = "Actualizar";
            this.cambiarButton.UseVisualStyleBackColor = false;
            this.cambiarButton.Click += new System.EventHandler(this.cambiarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(261, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuario";
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(416, 59);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(212, 31);
            this.userBox.TabIndex = 11;
            // 
            // checkRepPass
            // 
            this.checkRepPass.AutoSize = true;
            this.checkRepPass.BackColor = System.Drawing.Color.Transparent;
            this.checkRepPass.ForeColor = System.Drawing.Color.AliceBlue;
            this.checkRepPass.Location = new System.Drawing.Point(665, 218);
            this.checkRepPass.Name = "checkRepPass";
            this.checkRepPass.Size = new System.Drawing.Size(150, 29);
            this.checkRepPass.TabIndex = 13;
            this.checkRepPass.Text = "checkBox2";
            this.checkRepPass.UseVisualStyleBackColor = false;
            this.checkRepPass.CheckedChanged += new System.EventHandler(this.checkRepPass_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.AliceBlue;
            this.label4.Location = new System.Drawing.Point(151, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nueva contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(98, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Verifique la contraseña";
            // 
            // checkPass
            // 
            this.checkPass.AutoSize = true;
            this.checkPass.BackColor = System.Drawing.Color.Transparent;
            this.checkPass.ForeColor = System.Drawing.Color.AliceBlue;
            this.checkPass.Location = new System.Drawing.Point(665, 159);
            this.checkPass.Name = "checkPass";
            this.checkPass.Size = new System.Drawing.Size(150, 29);
            this.checkPass.TabIndex = 16;
            this.checkPass.Text = "checkBox1";
            this.checkPass.UseVisualStyleBackColor = false;
            this.checkPass.CheckedChanged += new System.EventHandler(this.checkPass_CheckedChanged);
            // 
            // repPass
            // 
            this.repPass.BeepOnError = true;
            this.repPass.Culture = new System.Globalization.CultureInfo("");
            this.repPass.Location = new System.Drawing.Point(416, 216);
            this.repPass.Name = "repPass";
            this.repPass.PasswordChar = '*';
            this.repPass.RejectInputOnFirstFailure = true;
            this.repPass.Size = new System.Drawing.Size(212, 31);
            this.repPass.SkipLiterals = false;
            this.repPass.TabIndex = 17;
            // 
            // CambiarContrseñaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = global::Flight_Forms.Properties.Resources.inicioCIELO;
            this.ClientSize = new System.Drawing.Size(878, 394);
            this.Controls.Add(this.repPass);
            this.Controls.Add(this.checkPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkRepPass);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cambiarButton);
            this.Controls.Add(this.passBx);
            this.Name = "CambiarContrseñaForm";
            this.Text = "Cambiar Contraseña";
            this.Load += new System.EventHandler(this.CambiarContrseñaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


#endregion


        private System.Windows.Forms.MaskedTextBox passBx;

        private System.Windows.Forms.Button cambiarButton;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox userBox;

        private System.Windows.Forms.CheckBox checkRepPass;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.CheckBox checkPass;

        private System.Windows.Forms.MaskedTextBox repPass;
    }
}
