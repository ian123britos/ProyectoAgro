using CasosDeUsos.DTOs.ClienteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso
{
    public interface ICUAltaUsuarioCliente
    {
        int Ejecutar(AltaClienteDTO altaClienteDTO);
    }
}
