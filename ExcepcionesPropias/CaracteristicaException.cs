using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class CaracteristicaException:Exception
    {
        public CaracteristicaException() { }

        public CaracteristicaException(string message) : base(message) { }

        public CaracteristicaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
