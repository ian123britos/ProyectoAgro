using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias.ExeptionDireccion
{
    public class DireccionException : Exception
    {

        public DireccionException() { }

        public DireccionException(string message) : base(message) { }

        public DireccionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
