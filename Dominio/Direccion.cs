using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public string Pais {  get; set; }
        public string Ciudad {  get; set; }
        public string Barrio { get; set; }

        public Direccion() { }

        public Direccion(string pais, string ciudad, string barrio)
        {
            Pais = pais;
            Ciudad = ciudad;
            Barrio = barrio;
        }

        public void Validar() 
        {
            ValidarPais();
            ValidarCiudad();
            ValidarBarrio();

        }

        private void ValidarBarrio()
        {
            if(string.IsNullOrEmpty(Barrio))
            {
                throw new Exception("El campo barrio no puede ser vacio");
            }
        }

        private void ValidarCiudad()
        {
            if (string.IsNullOrEmpty(Ciudad))
            {
                throw new Exception("El campo ciudad no puede ser vacio");
            }
        }

        private void ValidarPais()
        {
            if (string.IsNullOrEmpty(Pais))
            {
                throw new Exception("El campo pais no puede ser vacio");
            }
        }
    }
}
