using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.IO;

namespace PracticaDosP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //obtener los datos de los textbox
            string nombres = textBox1.Text;
            string apellido = textBox2.Text;
            string telefono = textBox3.Text;
            string estatura = textBox4.Text;
            string edad = textBox5.Text;

            //Obtener el genero seleccionado
            string genero = "";
            if (radioButton1.Checked)
            {
                genero = "Mujer";
            }
            else if (radioButton2.Checked) 
            {
                genero = "Hombre";
            }

            //Crear una cadena con los datos
            string datos = $"Nombres:{nombres}\r\nApellido: {apellido}\r\nTelefono: {telefono} \r\nEstatura: {estatura} cm\r\nEdad: {edad} años\r\nGenero: {genero}";

            //Guardar los datos en un archivo de texto
            string rutaArchivo = "C:\\Users\\danpa\\OneDrive\\Escritorio\\Semestre 3\\Ruta\\Archivooneida.txt";
            //File.WriteAllText(rutaArchivo, datos);
            //Verificar si el archivo ya existe
            bool archivoExiste= File.Exists(rutaArchivo);

            if (archivoExiste == false)
            {
                File.WriteAllText(rutaArchivo, datos);
            }
            else {
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                      if (archivoExiste)
                      {
                 //          si el archivo existe, añadir un separador antes del nuevo registro
                             writer.WriteLine();
                      }
                             writer.WriteLine(datos);
                }
            }

            //Mostrar un mensaje con los datos capturados
            MessageBox.Show("Datos guardados con éxito:\n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Limpiar los controles despues de guardar
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1 .Checked = false;
            radioButton2.Checked = false;
        }
    }
}
