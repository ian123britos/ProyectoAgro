using CasosDeUsos.DTOs.MaquinariaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCasosDeUso.IMaquinariaCasosDeUso
{
    public interface ICUAltaMaquinariaFertilizadora
    {
        void Ejecutar(FertilizadoraDTO fertilizadoraDTO);
    }
}
