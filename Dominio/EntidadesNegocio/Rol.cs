using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Rol
    {
        public int Id { get; set; }
        public string TipoDeRol {  get; set; }

        public Rol() { }
        public Rol(string tipoDeRol) 
        {
                TipoDeRol = tipoDeRol;
        }
    }
}
