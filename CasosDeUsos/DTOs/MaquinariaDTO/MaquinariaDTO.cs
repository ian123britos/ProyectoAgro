using Dominio.EntidadesNegocio;
using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.MaquinariaDTO
{
    public class MaquinariaDTO
    {
        public Direccion Direccion { get; set; }
        public Caracteristica Caracteristica { get; set; }
        public string OtrasCaracteristicas { get; set; }
    }
}
