using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class MaquinariaSembradoraException:Exception
    {
        public MaquinariaSembradoraException() { }

        public MaquinariaSembradoraException(string message) : base(message) { }

        public MaquinariaSembradoraException(string message, Exception innerException) : base(message, innerException) { }
    }
}
