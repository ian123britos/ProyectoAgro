using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T item);
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Delete(T item);
        void Update(int id, T item);
    }
}
