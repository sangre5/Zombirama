using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

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
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            // We use these three SQLite objects:

            SQLiteConnection sqlite_conn;

            SQLiteCommand sqlite_cmd;

            SQLiteDataReader sqlite_datareader;



            // create a new database connection:

            sqlite_conn =
                new SQLiteConnection("Data Source=MyDatabase.db;Version=3;New=True;Compress=True;");

            // open the connection:

            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";


            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'Test Text 1');";


            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

            // First lets build a SQL-Query again:

            sqlite_cmd.CommandText = "SELECT * FROM test";



            // Now the SQLiteCommand object can give us a DataReader-Object:

            sqlite_datareader = sqlite_cmd.ExecuteReader();



            // The SQLiteDataReader allows us to run through the result lines:

            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read

            {

                // Print out the content of the text field:

                //System.Console.WriteLine( sqlite_datareader["text"] );



                string myreader = sqlite_datareader.GetString(1);

                MessageBox.Show(myreader);

            }

            // We are ready, now lets cleanup and close our connection:

            sqlite_conn.Close();

        }
    }
}
