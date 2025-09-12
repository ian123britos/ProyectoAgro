using CasosDeUsos.DTOs.DireccionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCasosDeUso.IDireccionCasoDeUso
{
    public interface ICUAltaDireccion
    {
        void Ejecutar(DireccionDTO direccionDTO);
    }
}
