using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombirama
{
    class Personaje
    {
        public int PersonajeID { get; set; }
        public string Nombre { get; set; }    
        public string Comentarios {get; set;}

        public enum EstatusE { Vivo, Muerto };
        public enum RelevanciaE { Principal, Secundario, Incidental };

        private EstatusE _estatus;

        public EstatusE Estatus
        {
            get
            {
                return this._estatus;
            }
            set
            {
                this._estatus = value;
            }
            
        }

        private RelevanciaE _relevancia;

        public RelevanciaE Relevancia
        {
            get
            {
                return this._relevancia;
            }
            set
            {
                this._relevancia = value;
            }
        }

        public Personaje (string nombre, RelevanciaE relevancia)
        {
            this.Nombre = nombre;
            this.Relevancia = relevancia;
            this.Estatus = EstatusE.Vivo;
        }

        public Personaje()
        {

        }


    }
}
