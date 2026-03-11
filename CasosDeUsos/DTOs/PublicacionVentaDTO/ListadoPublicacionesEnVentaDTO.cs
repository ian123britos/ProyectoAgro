using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.PublicacionVentaDTO
{

        public class ListadoPublicacionesEnVentaDTO
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Foto {  get; set; }
            public double Precio { get; set; }

            public int CaracteristicaId { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int Anio { get; set; }
            
            public int DireccionId { get; set; }
            public string Ciudad { get; set; }
            public string Pais { get; set; }
         
        }
    

}
