using CasosDeUsos.DTOs.CaracteristicaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCasosDeUso.ICaracteristicaCasoDeUso
{
    public interface ICUAltaCaracteristica
    {
        void Ejecutar(CaracteristicaDTO caracteristicaDTO);
    }
}
