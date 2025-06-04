using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        public List<Usuario> listaUsuarios { get; set; }

        public List<Maquinaria> listaMaquinarias {  get; set; }
        public List<Caracteristica> listaCaracteristicas { get; set; }
        public List<Direccion> listaDirecciones { get; set; }
        public List<Publicacion> listaPublicaciones { get; set; }
        public List<Compra> listaCompras { get; set; }

        //inicializo las listas vacias
        private Sistema() 
        {
            listaUsuarios = new List<Usuario>();
            listaMaquinarias = new List<Maquinaria>();
            listaCaracteristicas = new List<Caracteristica>();
            listaDirecciones = new List<Direccion>();
            listaPublicaciones = new List<Publicacion>();
            listaCompras = new List<Compra>();
        
        }

        #region Seccion de altas y Get
        public void AltaUsuario(Usuario usuario)
        {
            usuario.Validar();
            ExisteUsuario(usuario);
            listaUsuarios.Add(usuario);
        }
        public List<Usuario> GetUsuarios()
        { 
            return listaUsuarios; 
        }

        public void AltaMaquinaria(Maquinaria maquinaria)
        {
            maquinaria.Validar();
            listaMaquinarias.Add(maquinaria);
        }
        public List<Maquinaria> GetMaquinarias()
        {
            return listaMaquinarias;
        }

        public void AltaCaracteristica(Caracteristica caracteristica)
        {
            caracteristica.Validar();
            listaCaracteristicas.Add(caracteristica);
        }
        public List<Caracteristica> GetCaracteristicas()
        {
            return listaCaracteristicas;
        }

        public void AltaDireccion(Direccion direccion)
        {
            direccion.Validar();
            listaDirecciones.Add(direccion);
        }

        public void AltaPublicacion(Publicacion publicacion)
        {
            publicacion.Validar();
            listaPublicaciones.Add(publicacion);
        }
        public List<Publicacion> GetPublicacions()
        {
            return listaPublicaciones;
        }

        public void AltaCompra(Compra compra)
        {
            listaCompras.Add(compra);
        }
        public List<Compra> GetCompras()
        {
            return listaCompras;
        }
        #endregion



        public void ExisteUsuario(Usuario usuario)
        {
            if(listaUsuarios.Contains(usuario))
            {
                throw new Exception("Ya existe un usuario con ese Email");
            }
        }

        public void PreCargaDatos()
        {
            PreCargaDatosCaracteristicas();
            PreCargaDatosDirecciones();
            PreCargaDatosMaquianrias();

            PreCargaDatosUsuarios();

            PreCargaDatosPublicaciones();
            
           
            PreCargaDatosCompras();
        }

        #region Seccion de Precargas
        private void PreCargaDatosDirecciones()
        {
            throw new NotImplementedException();
        }

        private void PreCargaDatosCaracteristicas()
        {
            throw new NotImplementedException();
        }

        private void PreCargaDatosMaquianrias()
        {
            throw new NotImplementedException();
        }     
        private void PreCargaDatosUsuarios()
        {
            throw new NotImplementedException();
        }
        private void PreCargaDatosPublicaciones()
        {
            throw new NotImplementedException();
        }

        private void PreCargaDatosCompras()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
