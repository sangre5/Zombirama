using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombirama
{
    

    public partial class Form1 : Form
    {

        List<Personaje> Personajes = new List<Personaje>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Personajes.Count() > 0)
            {
                Random ran = new Random();
                int index = ran.Next(0, Personajes.Count() - 1);
                MessageBox.Show($"{Personajes[index].Nombre} morirá al presionar OK :D");
                Personajes.Remove(Personajes[index]);
            }
            else
            {
                MessageBox.Show("Todos están muertos");
            }           
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Herramienta para escoger que personaje en Zombirama ha de morir \n" +
                "Versión: 1.0 \n" +
                "Creado por: Paulina Jurado Solís");
        }

        private void personajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarPersonajes ep = new EditarPersonajes();
            ep.Show();
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseDeDatos db = new BaseDeDatos();
            db.Show();
        }
    }
}
