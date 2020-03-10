using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    //Controller del Proyecto
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void Insertar(String nombre, string desc, string marca, string precio, string stock)
        {
            objetoCD.Insertar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));

        }

        public void Editar(String nombre, string desc, string marca, string precio, string stock, string id)
        {
            objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void Eliminar(String id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
