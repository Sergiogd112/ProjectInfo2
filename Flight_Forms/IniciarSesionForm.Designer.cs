namespace Flight_Forms
{
    partial class IniciarSesionForm
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
            this.components = new System.ComponentModel.Container();
            this.iniciarButton = new System.Windows.Forms.Button();
            this.chechBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuOpciones = new System.Windows.Forms.MenuStrip();
            this.opcionesStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.regístrateToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();
            this.constraseñaOlvidadaToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 =
                new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpciones.SuspendLayout();
            this.SuspendLayout();

            //

            // iniciarButton
            //

            this.iniciarButton.BackColor = System.Drawing.Color.FloralWhite;
            this.iniciarButton.FlatAppearance.BorderColor =
                System.Drawing.Color.PaleGoldenrod;
            this.iniciarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iniciarButton.Font =
                new System.Drawing.Font("Microsoft Sans Serif",
                    7.875F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));
            this.iniciarButton.Location = new System.Drawing.Point(61, 232);
            this.iniciarButton.Name = "iniciarButton";
            this.iniciarButton.Size = new System.Drawing.Size(171, 45);
            this.iniciarButton.TabIndex = 0;
            this.iniciarButton.Text = "Iniciar Sesión";
            this.iniciarButton.UseVisualStyleBackColor = false;
            this.iniciarButton.Click +=
                new System.EventHandler(this.iniciarButton_Click);

            //

            // chechBox
            //

            this.chechBox.AutoSize = true;
            this.chechBox.BackColor = System.Drawing.Color.Transparent;
            this.chechBox.ForeColor = System.Drawing.Color.LightYellow;
            this.chechBox.Location = new System.Drawing.Point(357, 197);
            this.chechBox.Name = "chechBox";
            this.chechBox.Size = new System.Drawing.Size(117, 29);
            this.chechBox.TabIndex = 1;
            this.chechBox.Text = "Mostrar";
            this.chechBox.UseVisualStyleBackColor = false;
            this.chechBox.CheckedChanged +=
                new System.EventHandler(this.chechBox_CheckedChanged);

            //

            // label1
            //

            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font =
                new System.Drawing.Font("Microsoft Sans Serif",
                    9F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightYellow;
            this.label1.Location = new System.Drawing.Point(113, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";

            //

            // userBox
            //

            this.userBox.BackColor = System.Drawing.SystemColors.Info;
            this.userBox.Location = new System.Drawing.Point(61, 160);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(218, 31);
            this.userBox.TabIndex = 3;

            //

            // label2
            //

            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font =
                new System.Drawing.Font("Ink Free",
                    16.125F,
                    (
                    (
                    System.Drawing.FontStyle
                    )((
                    System.Drawing.FontStyle.Bold |
                    System.Drawing.FontStyle.Italic
                    ))
                    ),
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(155, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 53);
            this.label2.TabIndex = 4;
            this.label2.Text = "Flight Simulator";

            //

            // passBox
            //

            this.passBox.BackColor = System.Drawing.SystemColors.Info;
            this.passBox.Location = new System.Drawing.Point(303, 160);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(218, 31);
            this.passBox.TabIndex = 6;

            //

            // label3
            //

            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font =
                new System.Drawing.Font("Microsoft Sans Serif",
                    9F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightYellow;
            this.label3.Location = new System.Drawing.Point(352, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contraseña";

            //

            // menuOpciones
            //

            this.menuOpciones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuOpciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuOpciones.Font =
                new System.Drawing.Font("Microsoft Sans Serif",
                    9F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));
            this.menuOpciones.GripMargin =
                new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuOpciones.GripStyle =
                System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuOpciones.ImageScalingSize =
                new System.Drawing.Size(32, 32);
            this
                .menuOpciones
                .Items
                .AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.opcionesStrip
                });
            this.menuOpciones.Location = new System.Drawing.Point(0, 385);
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(610, 37);
            this.menuOpciones.TabIndex = 8;
            this.menuOpciones.Text = "menuStrip1";

            //

            // opcionesStrip
            //

            this
                .opcionesStrip
                .DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.regístrateToolStripMenuItem,
                    this.constraseñaOlvidadaToolStripMenuItem
                });
            this.opcionesStrip.Name = "opcionesStrip";
            this.opcionesStrip.Size = new System.Drawing.Size(145, 33);
            this.opcionesStrip.Text = "Opciones";

            //

            // regístrateToolStripMenuItem
            //

            this.regístrateToolStripMenuItem.BackColor =
                System.Drawing.Color.SteelBlue;
            this.regístrateToolStripMenuItem.ForeColor =
                System.Drawing.Color.AliceBlue;
            this.regístrateToolStripMenuItem.Name =
                "regístrateToolStripMenuItem";
            this.regístrateToolStripMenuItem.Size =
                new System.Drawing.Size(397, 44);
            this.regístrateToolStripMenuItem.Text = "Regístrate";
            this.regístrateToolStripMenuItem.Click +=
                new System.EventHandler(this.regístrateToolStripMenuItem_Click);

            //

            // constraseñaOlvidadaToolStripMenuItem
            //

            this.constraseñaOlvidadaToolStripMenuItem.BackColor =
                System.Drawing.Color.SteelBlue;
            this.constraseñaOlvidadaToolStripMenuItem.ForeColor =
                System.Drawing.Color.AliceBlue;
            this.constraseñaOlvidadaToolStripMenuItem.Name =
                "constraseñaOlvidadaToolStripMenuItem";
            this.constraseñaOlvidadaToolStripMenuItem.Size =
                new System.Drawing.Size(397, 44);
            this.constraseñaOlvidadaToolStripMenuItem.Text =
                "Constraseña olvidada";
            this.constraseñaOlvidadaToolStripMenuItem.Click +=
                new System.EventHandler(this
                        .constraseñaOlvidadaToolStripMenuItem_Click);

            //

            // contextMenuStrip1
            //

            this.contextMenuStrip1.ImageScalingSize =
                new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);

            //

            // IniciarSesionForm
            //

            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage =
                global::Flight_Forms.Properties.Resources.earth;
            this.ClientSize = new System.Drawing.Size(610, 422);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chechBox);
            this.Controls.Add(this.iniciarButton);
            this.Controls.Add(this.menuOpciones);
            this.MainMenuStrip = this.menuOpciones;
            this.Name = "IniciarSesionForm";
            this.Text = "Bienvenid@";
            this.Load += new System.EventHandler(this.IniciarSesionForm_Load);
            this.menuOpciones.ResumeLayout(false);
            this.menuOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


#endregion


        private System.Windows.Forms.Button iniciarButton;

        private System.Windows.Forms.CheckBox chechBox;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox userBox;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox passBox;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.MenuStrip menuOpciones;

        private System.Windows.Forms.ToolStripMenuItem opcionesStrip;

        private System.Windows.Forms.ToolStripMenuItem
            regístrateToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            constraseñaOlvidadaToolStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
