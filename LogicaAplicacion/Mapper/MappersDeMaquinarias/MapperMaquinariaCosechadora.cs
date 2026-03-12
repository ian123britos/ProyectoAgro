using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MappersDeMaquinarias
{
    public static class MapperMaquinariaCosechadora
    {
        public static Cosechadora MaquinariaCosechadoraDTOaEntidad(CosechadoraDTO cosechadoraDTO,Caracteristica caracteristica,Direccion direccion)
        {
            if(cosechadoraDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");

            }
            return new Cosechadora(cosechadoraDTO.TipoCosechadora, cosechadoraDTO.CapacidadDeCarga, cosechadoraDTO.EsRuedaDual,
                direccion, caracteristica, cosechadoraDTO.OtrasCaracteristicas);
        }
    }
}
