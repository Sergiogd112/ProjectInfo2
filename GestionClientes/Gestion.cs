using System;
using System.Collections.Generic;
//para trabajar con la base de datos
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace GestionUsuarios
{
    public class Gestion
    {
        //conector para acceder a la base de datos
        private SQLiteConnection cnx;

        public void Iniciar()
        {
            //abrimos la base de datos
            string dataSource = "Data Source=proyecto.db";
            this.cnx = new SQLiteConnection(dataSource);
            this.cnx.Open();
        }

        //método para obtener todos los datos de la base de datos
        //retorna objeto de la clase DataTable
        //nos retrona todos los datos almacenados en la tabla
        //se guardan en 'dt'
        public DataTable ShowUsers()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM  usuarios";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill (dt);
            return dt;
        }

        public DataTable ShowUser(string name)
        {
            DataTable dt = new DataTable();
            string sql =
                "SELECT * FROM  usuarios WHERE username='" + name + "';";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill (dt);
            return dt;
        }

        public void fillTable(string name, string pass)
        {
            //rellenamos tabla con los datos de los usuarios
            string s =
                "INSERT INTO usuarios values ('" +
                name +
                "','" +
                FlightLib.Utils.sha256_hash(pass) +
                "');";
            SQLiteCommand cmd = new SQLiteCommand(s, cnx);
            cmd.ExecuteNonQuery();
        }

        //método para verificar la existencia de usuario con username introducido por parametro
        public int ExistsUser(string name)
        {
            DataTable dt = new DataTable();
            string user =
                "SELECT * FROM usuarios WHERE username='" + name + "';";
            SQLiteDataAdapter command = new SQLiteDataAdapter(user, this.cnx);
            command.Fill (dt);
            if (dt.Rows.Count == 1)
            {
                //si se ha encontrado el usuario
                return 1;
            }
            else
            {
                //usuario no encontrado
                return 0;
            }
        }

        //método para encontrar usuario con cierto nombre y contraseña
        public int findUser(string name, string pass)
        {
            //tabla que contiene el nombre de usuario, si encontrado
            DataTable dt1 = new DataTable();

            //tabla que contiene contraseña y nombre de usuario ingresados, si encontrados
            DataTable dt2 = new DataTable();

            string user =
                "SELECT * FROM usuarios WHERE username='" + name + "';";
            string ok =
                "SELECT * FROM usuarios WHERE password='" +
                FlightLib.Utils.sha256_hash(pass) +
                "'AND username='" +
                name +
                "';";

            SQLiteDataAdapter command1 = new SQLiteDataAdapter(user, cnx);
            SQLiteDataAdapter command2 = new SQLiteDataAdapter(ok, cnx);

            //rellenamos
            command1.Fill (dt1);
            command2.Fill (dt2);

            //comprobamos
            if (dt1.Rows.Count == 1 && dt2.Rows.Count == 1)
            {
                //si se ha encontrado no solo el usuario, sino que tambien su contraseña que es la introducida por parametro
                return 1;
                //exito
            }
            else
            {
                if (dt1.Rows.Count == 1)
                {
                    //si tan solo se ha encontrado el nombre de usuario, pero no su contraseña
                    return 0;
                }
                else
                {
                    //en este caso, no se ha encontrado ni usuario ni contraseña
                    return -1;
                }
            }
        }

        //método para actualizar los datos de un usuario
        public int updateUser(string name, string pass)
        {
            //nueva contraseña
            try
            {
                string sql =
                    "UPDATE usuarios SET password ='" +
                    FlightLib.Utils.sha256_hash(pass) +
                    "'WHERE username='" +
                    name +
                    "';";
                SQLiteCommand command = new SQLiteCommand(sql, cnx);
                int changes = command.ExecuteNonQuery();
                if (changes == 1)
                {
                    //exito
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //método para cerrar la base de datos
        public void Cerrar()
        {
            this.cnx.Close();
        }
    }
}
