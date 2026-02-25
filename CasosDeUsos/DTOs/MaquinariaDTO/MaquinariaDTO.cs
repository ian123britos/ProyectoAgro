
using CasosDeUsos.DTOs.DireccionDTO;
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

        public int Id { get; set; }

        public int DireccionId { get; set; }
        public int CaracteristicaId { get; set; }

        public string OtrasCaracteristicas { get; set; }
    }
}