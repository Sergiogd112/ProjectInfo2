using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionUsuarios;

namespace Flight_Forms
{
    public partial class CambiarContrseñaForm : Form
    {
        Gestion gestion;

        public CambiarContrseñaForm(Gestion gestion)
        {
            this.gestion = gestion;
            InitializeComponent();
        }


        private void cambiarButton_Click(object sender, EventArgs e)
        {
            string username = userBox.Text;
            string password = Convert.ToString(passBx.Text);
            string passwordRep = Convert.ToString(repPass.Text);
            if (username == "" || password == "" || passwordRep == "")
            {
                MessageBox.Show("No se ha actualizado la contraseña porque hay campos vacíos.");
                userBox.Text = "";
                passBx.Text = "";
                repPass.Text = "";

            }
            else
            {
                int result = this.gestion.ExistsUser(username);
                if (result == 1)
                {
                    //usuario existe
                    if (password != passwordRep)
                    {
                        MessageBox.Show("Las contraseñas no coinciden.");
                        passBx.Text = "";
                        repPass.Text = "";
                    }
                    else
                    {
                        int update = this.gestion.updateUser(username, password);
                        if (update == 1)
                        {
                            MessageBox.Show("La contraseña ha sido actualizada, {0}.", username);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido actualizar la contraseña. Pruebe de nuevo.");
                            passBx.Text = "";
                            repPass.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existe el usuario {0}", username);
                    userBox.Text = "";
                    passBx.Text = "";
                    repPass.Text = "";
                }
            }
        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked == true)
            {
                if (passBx.PasswordChar == '*')
                {
                    passBx.PasswordChar = '\0';
                }
                else
                {
                    passBx.PasswordChar = '*';
                }
            }
        }

        private void checkRepPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRepPass.Checked == true)
            {
                if (repPass.PasswordChar == '*')
                {
                    repPass.PasswordChar = '\0';
                }
                else
                {
                    repPass.PasswordChar = '*';
                }
            }
        }

        //enviamos base de datos actualizada al formulario superior de inicio de sesion
        public Gestion GetDB()
        {
            return this.gestion;
        }
    }
}
