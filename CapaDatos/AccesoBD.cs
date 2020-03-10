using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class AccesoBD
    {
        private SqlConnection Conexion = new SqlConnection("Server=(local);DataBase=Practica2;Integrated Security=true");

            public SqlConnection AbrirConexion()
            {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;

            }

            public SqlConnection CerrarConexion()
            {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
            }
                
    }
}
