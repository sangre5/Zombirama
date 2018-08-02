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
            
            Personajes.Add(new Personaje("Arantza", Personaje.RelevanciaE.Principal));
            Personajes.Add(new Personaje("Paulina", Personaje.RelevanciaE.Incidental));
            Personajes.Add(new Personaje("Julio", Personaje.RelevanciaE.Secundario));
            Personajes.Add(new Personaje("Sara", Personaje.RelevanciaE.Secundario));
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
    }
}
