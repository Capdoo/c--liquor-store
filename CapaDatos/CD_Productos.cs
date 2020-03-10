using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    //ServiceDelProyecto
    public class CD_Productos
    {
        private AccesoBD conexion = new AccesoBD();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            //TRANSACCION SQL
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "MostrarProductos";
            //Se especifica que el comando es de tipo procedimiento
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();

            return tabla;

        }

        public void Insertar(String nombre, string desc, string marca, double precio, int stock)
        {
            //PROCEDIMIENTO (CAMBIAR PASO DE INFORMACION)
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",nombre);
            comando.Parameters.AddWithValue("@descripcion",desc);
            comando.Parameters.AddWithValue("@marca",marca);
            comando.Parameters.AddWithValue("@precio",precio);
            comando.Parameters.AddWithValue("@stock",stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar(String nombre, string desc, string marca, double precio, int stock, int id)
        {
            //PROCEDIMIENTO (CAMBIAR PASO DE INFORMACION)
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

     }
}
