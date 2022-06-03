using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BD_Proyecto
{
    class Conexion1
    {
        MySqlConnection nuevaConexion = new MySqlConnection();

        string host = "localhost";
        string usuario = "root";
        string contraseña = "''";
        string database = "baseestudiantes";

        public Conexion1()
        {
            this.Connect();
        }

        public void Connect()
        {
            if (nuevaConexion.State == ConnectionState.Closed)
            {
                nuevaConexion.ConnectionString = String.Format(@"Server={0}; DataBase={1}; user ID={2};
                Password={3}; Pooling=false;", host, database, usuario, contraseña);

            }
        }
        
        public int Query(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, nuevaConexion);
            return cmd.ExecuteNonQuery();
        }

        public DataTable getData(string sql)
        {
            this.Connect();
            DataTable tabla = new DataTable();
            MySqlDataAdapter ada = new MySqlDataAdapter(sql, nuevaConexion);
            ada.Fill(tabla);
            return tabla;
        }

        public DataRow getRow(string sql)
        {
            DataRow row = null;
            if (this.getData(sql).Rows.Count == 0)
            {
                return null;
            }
            row = this.getData(sql).Rows[0];
            return row;
        }
    }
}
