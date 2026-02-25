using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias.ExceptionMaquinarias
{
    public class MaquinariaFertilizadoraException : Exception
    {
        public MaquinariaFertilizadoraException() { }

        public MaquinariaFertilizadoraException(string message) : base(message) { }

        public MaquinariaFertilizadoraException(string message, Exception innerException) : base(message, innerException) { }
    }
}
