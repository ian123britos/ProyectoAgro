using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CasosDeUsos.DTOs.CaracteristicaDTOs
{
    public class CaracteristicaDTO
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public bool EsUsado { get; set; }
        public bool UnicoDuenio { get; set; }
        public string TipoDeCombustible { get; set; }
        public string TipoDeDireccion { get; set; }
    }
}
