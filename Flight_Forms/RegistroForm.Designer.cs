namespace Flight_Forms
{
    partial class RegistroForm
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
            this.passBox = new System.Windows.Forms.MaskedTextBox();
            this.muestraBox = new System.Windows.Forms.CheckBox();
            this.regButton = new System.Windows.Forms.Button();
            this.userBox = new System.Windows.Forms.TextBox();
            this.repPassBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "*Escriba de nuevo la contraseña";
            // 
            // passBox
            // 
            this.passBox.BeepOnError = true;
            this.passBox.Culture = new System.Globalization.CultureInfo("");
            this.passBox.Location = new System.Drawing.Point(425, 218);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.RejectInputOnFirstFailure = true;
            this.passBox.Size = new System.Drawing.Size(212, 31);
            this.passBox.SkipLiterals = false;
            this.passBox.TabIndex = 3;
            // 
            // muestraBox
            // 
            this.muestraBox.AutoSize = true;
            this.muestraBox.BackColor = System.Drawing.Color.Transparent;
            this.muestraBox.Location = new System.Drawing.Point(475, 336);
            this.muestraBox.Name = "muestraBox";
            this.muestraBox.Size = new System.Drawing.Size(117, 29);
            this.muestraBox.TabIndex = 5;
            this.muestraBox.Text = "Mostrar";
            this.muestraBox.UseVisualStyleBackColor = false;
            this.muestraBox.CheckedChanged += new System.EventHandler(this.muestraBox_CheckedChanged);
            // 
            // regButton
            // 
            this.regButton.BackColor = System.Drawing.Color.AliceBlue;
            this.regButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.regButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regButton.Location = new System.Drawing.Point(185, 420);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(147, 43);
            this.regButton.TabIndex = 6;
            this.regButton.Text = "Registrar";
            this.regButton.UseVisualStyleBackColor = false;
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(425, 112);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(212, 31);
            this.userBox.TabIndex = 7;
            // 
            // repPassBox
            // 
            this.repPassBox.BeepOnError = true;
            this.repPassBox.Culture = new System.Globalization.CultureInfo("");
            this.repPassBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.repPassBox.Location = new System.Drawing.Point(425, 279);
            this.repPassBox.Name = "repPassBox";
            this.repPassBox.PasswordChar = '*';
            this.repPassBox.RejectInputOnFirstFailure = true;
            this.repPassBox.Size = new System.Drawing.Size(212, 31);
            this.repPassBox.SkipLiterals = false;
            this.repPassBox.TabIndex = 8;
            // 
            // RegistroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Flight_Forms.Properties.Resources.sky;
            this.ClientSize = new System.Drawing.Size(730, 552);
            this.Controls.Add(this.repPassBox);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.muestraBox);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistroForm";
            this.Text = "Nuevo Usuario";
            this.Load += new System.EventHandler(this.RegistroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox passBox;
        private System.Windows.Forms.CheckBox muestraBox;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.MaskedTextBox repPassBox;
    }
}