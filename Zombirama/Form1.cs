using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using LiteDB;

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
            EditarVerPersonajes ep = new EditarVerPersonajes();
            ep.Show();
        }

        private void agregarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarVerPersonajes db = new EditarVerPersonajes();
            db.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(Path.GetTempPath() + "zombies.db"))
            {
                var per = db.GetCollection<Personaje>("Personajes");
                var mu = per.FindAll().ToList();
                MessageBox.Show(mu[0].Nombre);
            }
        }
    }
}
