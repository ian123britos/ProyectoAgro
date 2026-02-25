using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorio.IRepositorioUsuario
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        Usuario FindByEmailAndPassword(string email, string password);
        bool FindByTelefonoYaExistente(string telefono);
        Cliente FindByIdCliente(int id);
    }
}
