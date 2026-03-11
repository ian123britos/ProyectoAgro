using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.PublicacionVentaDTO
{
    public class DetallePublicacionEnVentaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Foto { get; set; }
        public double Precio { get; set; }

        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public bool EsUsado { get; set; }
        public bool UnicoDuenio { get; set; }
        public string TipoDeCombustible { get; set; }
        public string TipoDeDireccion { get; set; }

        //DETALLES DE CADA ATRIBUTO SEGUN QUE MAQUINARIA SEA:

        //tipo de maquinaria
        public string TipoMaquinaria { get; set; }

        //atributos específicos

        //tractor:
        public bool? TieneCabina { get; set; }
        //-------------------------------

        //sembradora:
        public string TipoSembradora { get; set; }
        //---------------------------------------

        //fertilizadora:
        public string MarcaMotor { get; set; }
        public int? Potencia { get; set; }
        public bool? DobleTraccion { get; set; }
        //-------------------------------

        //cosechadora:
        public string TipoCosechadora { get; set; }
        public int? CapacidadDeCarga { get; set; }
        public bool? EsRuedaDual { get; set; }
        //--------------------------------------

        //cargadoraPala:
        public int? Cilindro { get; set; }
        public string MarcaMotorCP { get; set; }
        //-------------------------

        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public DateTime FechaPublicacionVenta { get; set; }

        public string CaracteristicasFaltantes { get; set; }


        public string NombreVendedor { get; set; }
        public string EmailVendedor { get; set; }
        public string TelefonoVendedor { get; set; }
    }
}
