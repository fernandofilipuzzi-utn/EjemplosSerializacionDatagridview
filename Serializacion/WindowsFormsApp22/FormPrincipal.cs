using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjemploSerializacion.Controllers;
using EjemploSerializacion.Models;

namespace EjemploSerializacion
{
    public partial class FormPrincipal : Form
    {
        string path = "historial.dat";
        Sistema controlador;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

                if (fs.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    controlador = bf.Deserialize(fs) as Sistema;
                }
            }
            catch
            {
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            if (controlador == null)
            {
                controlador = new Sistema();
            }

            ActualizarGrillar();
            ActualizarGrillarConDasource();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, controlador);

            }
            catch
            {
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            int matricula = Convert.ToInt32(tbMatricula.Text);

            controlador.Medicos.Add(new Models.Medico { Nombre = nombre, Matricula = matricula });

            tbNombre.Clear();
            tbMatricula.Clear();

            ActualizarGrillar();
            ActualizarGrillarConDasource();
        }

        void ActualizarGrillar()
        {
            dataGridView1.Rows.Clear();
            foreach (Medico m in controlador.Medicos)
            {
                dataGridView1.Rows.Add(new string[] { m.Nombre });
            }
        }

        void ActualizarGrillarConDasource()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.DataSource=null;
            dataGridView2.DataSource = controlador.Medicos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
            saveFileDialog1.Filter = "fichero excel|*.csv";

            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                path= saveFileDialog1.FileName; 

                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    foreach (Medico medico in controlador.Medicos)
                    {
                        sw.WriteLine($"{medico.Nombre};{medico.Matricula}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("explotó!" + ex.Message);
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            }
        }
    }
}
