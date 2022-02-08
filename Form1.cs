using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ESTUDIANTES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Conectar();

            //MessageBox.Show("Conexion exitosa");

            dataGridView1.DataSource = LlenarGrid();
        }

        public DataTable LlenarGrid()
        {
            conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM alumno";
            SqlCommand cmd = new SqlCommand(consulta, conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
                /*decimos que desde la fila de la tabla de datos el elemento que 
                seleccionamos se pase al text box correspondiente*/
                textCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch{

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string insertar = "INSERT INTO alumno (CodigoAlumno,Nombres,Apellidos,Direccion) VALUES (@CodigoAlumno,@Nombres,@Apellidos,@Direccion)";
            SqlCommand cmd1 = new SqlCommand(insertar, conexion.Conectar());
            
            /*Insertamos los datos agregados en los textbox*/
            cmd1.Parameters.AddWithValue("@CodigoAlumno", textCodigo.Text);
            cmd1.Parameters.AddWithValue("@Nombres", textNombre.Text);
            cmd1.Parameters.AddWithValue("@Apellidos", textApellidos.Text);
            cmd1.Parameters.AddWithValue("@Direccion", textDireccion.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Datos Agregados con exito");

            //para llenar automaticamente el grid al agregar el estudiante
            dataGridView1.DataSource = LlenarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string actualizar = "UPDATE alumno SET Nombres=@Nombres,Apellidos=@Apellidos,Direccion=@Direccion WHERE CodigoAlumno=@CodigoAlumno";
            SqlCommand cmd2 = new SqlCommand(actualizar, conexion.Conectar());

            cmd2.Parameters.AddWithValue("@CodigoAlumno", textCodigo.Text);
            cmd2.Parameters.AddWithValue("@Nombres", textNombre.Text);
            cmd2.Parameters.AddWithValue("@Apellidos", textApellidos.Text);
            cmd2.Parameters.AddWithValue("@Direccion", textDireccion.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Datos actualizados con exito");

            dataGridView1.DataSource = LlenarGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string eliminar = "DELETE FROM alumno WHERE CodigoAlumno=@CodigoAlumno";
            SqlCommand cmd3 = new SqlCommand(eliminar, conexion.Conectar());

            cmd3.Parameters.AddWithValue("@CodigoAlumno", textCodigo.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Datos eliminados con exito");

            dataGridView1.DataSource = LlenarGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textCodigo.Clear();
            textNombre.Clear();
            textApellidos.Clear();
            textDireccion.Clear();
            textCodigo.Focus();
        }
    }
}
