using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using LiteDB;

namespace Zombirama
{


    public partial class Matar : Form
    {

        List<Personaje> Personajes = new List<Personaje>();

        public Matar()
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
            BaseDeDatos db = new BaseDeDatos();
            db.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(Path.GetTempPath() + "MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Personaje>("personajes");

                // Create your new customer instance
                var p = new Personaje("arriu", Personaje.RelevanciaE.Principal);
               

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(p);

                // Update a document inside a collection
                p.Nombre = "Arantza";

                col.Update(p);

                // Index document using document Name property
                col.EnsureIndex(x => x.Nombre);

                // Use LINQ to query documents
                var results = col.Find(x => x.Nombre.StartsWith("Ar")).ToList();

                MessageBox.Show(results[0].Nombre);
            }


        }
    }
}
