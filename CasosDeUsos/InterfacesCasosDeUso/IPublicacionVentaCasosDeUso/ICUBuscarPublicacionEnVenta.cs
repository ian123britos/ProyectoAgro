using CasosDeUsos.DTOs.PublicacionVentaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCasosDeUso.IPublicacionVentaCasosDeUso
{
    public interface ICUBuscarPublicacionEnVenta
    {
        DetallePublicacionEnVentaDTO Ejecutar(int id);
    }
}
