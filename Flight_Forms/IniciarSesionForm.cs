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
    public partial class IniciarSesionForm : Form
    {
        public IniciarSesionForm()
        {
            InitializeComponent();
        }

        //generamos base de datos
        Gestion users = new Gestion();

        private void IniciarSesionForm_Load(object sender, EventArgs e)
        {
            //abrimos base de datos
            this.users.Iniciar();
        }

        private void iniciarButton_Click(object sender, EventArgs e)
        {
            //debemos verificar que los datos introducidos son correctos:
            //el usuario existe y,además, la contraseña corresponde al nombre de usuario
            int resultado = this.users.findUser(userBox.Text, passBox.Text);
            if (resultado == 1)
            {
                //se ha encontrado: operacion exito
                MessageBox
                    .Show("Bienvenid@ " + Convert.ToString(userBox.Text) + ", disfrute de su experiencia en Flight Simulator");

                //abrimos el siguiente formulario de opciones
                this.Visible = false;
                PrincipalForm form = new PrincipalForm();
                form.ShowDialog();

                form.Visible = true;

                //cerramos este formulario
                this.Close();
            }

            if (resultado == 0)
            {
                //se ha encontrado el usuario pero no la contraseña
                //no se ha introducido correctamente la contraseña
                MessageBox
                    .Show("Contraseña incorrecta, por favor, intente de nuevo.");

                //limpiamos contenido
                passBox.Clear();
            }

            if (resultado == -1)
            {
                //no se ha encontrado ni usuario ni contraseña
                MessageBox
                    .Show("No se ha encontrado ni usuario ni contraseña. Si no tiene cuenta, puede registrarse.");
                passBox.Clear();
                userBox.Clear();
            }
        }

        private void chechBox_CheckedChanged(object sender, EventArgs e)
        {
            //mostramos el valor de la contraseña en caso de estar marcada la casilla (checked)
            if (
                chechBox.Checked == true //marcada
            )
            {
                if (passBox.PasswordChar == '*')
                {
                    //pasamos de incógnito a mostrar su valor
                    passBox.PasswordChar = '\0';
                }
                else
                {
                    passBox.PasswordChar = '*'; //de otro modo, mantenemos estado
                }
            }
        }

        private void regístrateToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            RegistroForm reg = new RegistroForm();
            reg.ShowDialog();
            reg.Visible = true;
            this.users = reg.DameBaseDatos();
        }

        private void constraseñaOlvidadaToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            CambiarContrseñaForm cambio = new CambiarContrseñaForm(this.users);
            cambio.ShowDialog();
            cambio.Visible = true;
            this.users = cambio.GetDB();
        }

        private void passBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                this.iniciarButton_Click(sender, e);
            }
        }
    }
}
