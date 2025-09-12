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
        public int IdCaracteristica { get; private set; }
        public static int UltimoIdCaracteristica;
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public bool EsUsado { get; set; }
        public bool UnicoDuenio { get; set; }
        public TipoCombustible TipoDeCombustible { get; set; }
        public TipoDireccion TipoDeDireccion { get; set; }
    }
}
