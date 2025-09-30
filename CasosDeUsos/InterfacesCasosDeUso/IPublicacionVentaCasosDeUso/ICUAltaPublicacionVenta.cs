using CasosDeUsos.DTOs.PublicacionVentaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCasosDeUso.IPublicacionVenta
{
    public interface ICUAltaPublicacionVenta
    {
        void Ejecutar(VentaDTO ventaDTO);
    }
}
