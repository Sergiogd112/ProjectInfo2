using System;
using System.Collections.Generic;
//para trabajar con la base de datos
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace GestionUsuarios
{
    public class Companys
    {
        //conector para acceder a la base de datos
        private SQLiteConnection cnx;

        public void Iniciar()
        {
            //abrimos la base de datos
            string dataSource = "Data Source=proyecto.db";
            this.cnx = new SQLiteConnection(dataSource);
            this.cnx.Open();
            if (ShowCompanys().Rows.Count == 0)
            {
                GenerarTabla("airlines.csv");
            }
        }

        //método para obtener todos los datos de la base de datos
        //retorna objeto de la clase DataTable
        //nos retrona todos los datos almacenados en la tabla
        //se guardan en 'dt'
        public DataTable ShowCompanys()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM  company";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }

        public DataTable ShowCompanyByName(string name)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM  company WHERE nombre='" + name + "';";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }

        public DataTable ShowCompanyByICAO(string ICAO)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM  company WHERE ICAO='" + ICAO + "';";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }

        public void fillTable(string name, string ICAO, string email, int phone)
        {
            //rellenamos tabla con los datos de los company
            string s =
                "INSERT INTO company values ('" +
                name +
                "','" +
                email +
                "','" +
                ICAO +
                "'," +
                Convert.ToString(phone) +
                ");";
            SQLiteCommand cmd = new SQLiteCommand(s, cnx);
            cmd.ExecuteNonQuery();
        }

        /*public void fillTable(Company company)
        {
            //rellenamos tabla con los datos de los company
            string s =
                "INSERT INTO company values ('" +
                company.Nombre() +
                "','" +
                company.Email +
                "','" +
                company.Icao +
                "'," +
                Convert.ToString(company.Telefono) +
                ");";
            SQLiteCommand cmd = new SQLiteCommand(s, cnx);
            cmd.ExecuteNonQuery();
        }*/

        //método para verificar la existencia de usuario con username introducido por parametro
        public int ExistsICAO(string name)
        {
            DataTable dt = new DataTable();
            string user = "SELECT * FROM company WHERE ICAO='" + name + "';";
            SQLiteDataAdapter command = new SQLiteDataAdapter(user, this.cnx);
            command.Fill(dt);
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

        //método para actualizar los datos de un usuario
        /*public int updateCompany(string icao, Company company)
        {
            //nueva contraseña
            try
            {
                string sql =
                    "UPDATE company SET name ='" +
                    company.Nombre +
                    "' SET email ='" +
                    company.Email +
                    "' SET telefono =" +
                    Convert.ToString(company.Telefono) +
                    "WHERE icao='" +
                    icao +
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
        }*/

        public int GenerarTabla(string filename)
        {
            try
            {
                StreamReader R = new StreamReader(filename);
                string text = R.ReadToEnd();
                string[] data = text.Split('\n');

                for (int i = 1; i < data.Length; i++)
                {
                    string row = data[i];
                    string[] cell = row.Split(',');
                    fillTable(cell[1],
                    cell[0],
                    cell[2],
                    Convert.ToInt32(cell[3]));
                }
            }
            catch
            {
                return 1;
            }

            return 0;
        }

        //método para cerrar la base de datos
        public void Cerrar()
        {
            this.cnx.Close();
        }
    }
}
