using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaView
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private String idProducto = null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView2.DataSource = objeto.MostrarProd();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editar == false) {
                try
                {
                    objetoCN.Insertar(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se inserto correctamente");
                    MostrarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);

                }

            }
            if(Editar == true)
            {
                try
                {
                    objetoCN.Editar(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se inserto correctamente");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                } catch(Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView2.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView2.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView2.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView2.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView2.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto= dataGridView2.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila, por favor");
        }

        private void limpiarForm()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count > 0)
            {
                idProducto = dataGridView2.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.Eliminar(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProductos();
            }
        }
    }
}
