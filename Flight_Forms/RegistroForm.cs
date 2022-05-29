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
using System.Media;

namespace Flight_Forms
{
    public partial class RegistroForm : Form
    {
        SoundPlayer musica;
        public RegistroForm()
        {
            InitializeComponent();
        }

        //creamos base de datos
        Gestion users = new Gestion();

        //creamos método que devolverá la base de datos
        //el formulario de iniciar sesion podra acceder a ella
        public Gestion DameBaseDatos()
        {
            return this.users;
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {
            //abrimos base de datos
            this.users.Iniciar();
            try 
            {
                musica = new SoundPlayer(@"c:120.wav");
                musica.Play();
            }
            catch
            {

            }
        }

        public void PararMusica()
        {
            musica.Stop();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            string user = Convert.ToString(userBox.Text);

            //Verificamos que no existe ningun usuario con ese nombre
            int i = this.users.ExistsUser(user);
            if (i == 1)
            {
                //se ha encontrado usuario con ese nombre
                MessageBox.Show("Ya existe un usuario con ese nombre.");
                userBox.Clear();
            }
            else
            {
                //no se ha encontrado ningún otro usuario

                //comprobamos que las 2 contraseñas existen
                if (passBox.Text == repPassBox.Text)
                {
                    //añadimos el usuario a la base de datos
                    this.users.fillTable(user, passBox.Text);
                    MessageBox.Show("Ha sido registrad@.");
                    this.Close();
                }
                else
                {
                    MessageBox
                        .Show("Las contraseñas no coinciden.Inténtelo de nuevo.");
                    passBox.Clear();
                    repPassBox.Clear();
                }
            }
        }

        private void muestraBox_CheckedChanged(object sender, EventArgs e)
        {
            if (muestraBox.Checked == true)
            {
                if (passBox.PasswordChar == '*')
                {
                    passBox.PasswordChar = '\0';
                }
                else
                {
                    passBox.PasswordChar = '*';
                }
            }
        }
        private void userBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                passBox.Focus();
            }
        }

        //Pasar de un textbox al siguiente al clicar Enter en el teclado
        private void passBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                repPassBox.Focus();
            }
        }
    }
}
