using Dominio.Interfaces;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Direccion:IValidable
    {
        public int Id { get; private set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }

        private Direccion()
        {

        }

        public Direccion(string pais, string ciudad, string barrio)
        {
            Pais = pais;
            Ciudad = ciudad;
            Barrio = barrio;
            Validar();
        }

        public void Validar()
        {
            ValidarPais();
            ValidarCiudad();
            ValidarBarrio();

        }

        private void ValidarBarrio()
        {
            if (string.IsNullOrEmpty(Barrio))
            {
                throw new DireccionException("El campo barrio no puede ser vacio");
            }
        }

        private void ValidarCiudad()
        {
            if (string.IsNullOrEmpty(Ciudad))
            {
                throw new DireccionException("El campo ciudad no puede ser vacio");
            }
        }

        private void ValidarPais()
        {
            if (string.IsNullOrEmpty(Pais))
            {
                throw new DireccionException("El campo pais no puede ser vacio");
            }
        }
    }
}
