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
            PreCargaDatosCaracteristicasTractores();
            PreCargaDatosDireccionesTractores();
            PreCargaDatosMaquinariasTractores();

            
            PreCargaCaracteristicasCargadoraPala();
            PreCargaDireccionCargadoraPala();
            PreCargaMaquinariaCargadoraPala();

            PreCargaCaracteristicasCosechadoras();
            PreCargaDireccionCosechadoras();
            PreCargaMaquinariaCosechadora();

            PreCargaCaracteristicasFertilizadora();
            PreCargaDireccionFertilizadora();
            PreCargaMaquinariaFertilizadora();

            PreCargaCaracteristicasSembradora();
            PreCargaDireccionSembradoraa();
            PreCargaMaquinariaSembradorara();




            PreCargaDatosUsuarios();

            PreCargaDatosPublicaciones();
            
           
            PreCargaDatosCompras();
        }

        #region Seccion de Precargas
        #region Pre carga de tractores
        private void PreCargaDatosDireccionesTractores()
        {
            Direccion direccion1 = new Direccion("Uruguay", "Durazno", "Santa Bernardina");
            Direccion direccion2 = new Direccion("Uruguay", "Tacuarembó", "La Palma");
            Direccion direccion3 = new Direccion("Uruguay", "Salto", "Ceibal");
            Direccion direccion4 = new Direccion("Uruguay", "Paysandú", "Colón");
            Direccion direccion5 = new Direccion("Uruguay", "Florida", "25 de Agosto");
            Direccion direccion6 = new Direccion("Uruguay", "San José", "Ciudad del Plata");
            Direccion direccion7 = new Direccion("Uruguay", "Canelones", "Las Piedras");
            Direccion direccion8 = new Direccion("Uruguay", "Colonia", "Tarariras");
            Direccion direccion9 = new Direccion("Uruguay", "Rocha", "Castillos");
            Direccion direccion10 = new Direccion("Uruguay", "Maldonado", "Aiguá");
            Direccion direccion11 = new Direccion("Uruguay", "Rivera", "Tranqueras");
            Direccion direccion12 = new Direccion("Uruguay", "Artigas", "Bella Unión");
            Direccion direccion13 = new Direccion("Uruguay", "Treinta y Tres", "Vergara");
            Direccion direccion14 = new Direccion("Uruguay", "Lavalleja", "José Pedro Varela");
            Direccion direccion15 = new Direccion("Uruguay", "Soriano", "Cardona");
            Direccion direccion16 = new Direccion("Uruguay", "Cerro Largo", "Fraile Muerto");
            Direccion direccion17 = new Direccion("Uruguay", "Flores", "Trinidad");
            Direccion direccion18 = new Direccion("Uruguay", "Montevideo", "Melilla");
            Direccion direccion19 = new Direccion("Uruguay", "Durazno", "Carlos Reyles");
            Direccion direccion20 = new Direccion("Uruguay", "San José", "Ecilda Paullier");
            AltaDireccion(direccion1);
            AltaDireccion(direccion2);
            AltaDireccion(direccion3);
            AltaDireccion(direccion4);
            AltaDireccion(direccion5);
            AltaDireccion(direccion6);
            AltaDireccion(direccion7);
            AltaDireccion(direccion8);
            AltaDireccion(direccion9);
            AltaDireccion(direccion10);
            AltaDireccion(direccion11);
            AltaDireccion(direccion12);
            AltaDireccion(direccion13);
            AltaDireccion(direccion14);
            AltaDireccion(direccion15);
            AltaDireccion(direccion16);
            AltaDireccion(direccion17);
            AltaDireccion(direccion18);
            AltaDireccion(direccion19);
            AltaDireccion(direccion20);


        }

        private void PreCargaDatosCaracteristicasTractores()
        {
            Caracteristica caracteristica1 = new Caracteristica("Agrícola", "John Deere", "5075E", new DateTime(2020, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica2 = new Caracteristica("Agrícola", "Case IH", "Farmall 90", new DateTime(2018, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica3 = new Caracteristica("Agrícola", "Massey Ferguson", "MF 4292", new DateTime(2022, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica4 = new Caracteristica("Forestal", "New Holland", "TD5.90", new DateTime(2017, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica5 = new Caracteristica("Vitícola", "Kubota", "M7040", new DateTime(2019, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica6 = new Caracteristica("Frutícola", "Deutz-Fahr", "Agrolux 75", new DateTime(2021, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica7 = new Caracteristica("Agrícola", "Valtra", "BH120", new DateTime(2016, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica8 = new Caracteristica("Caña de azúcar", "John Deere", "5076E", new DateTime(2020, 1, 1), false, false, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica9 = new Caracteristica("Agrícola", "Zetor", "Proxima 80", new DateTime(2015, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica10 = new Caracteristica("Agrícola", "Fiat", "640", new DateTime(2005, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica11 = new Caracteristica("Agrícola", "SAME", "Explorer 90", new DateTime(2018, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica12 = new Caracteristica("Arrocero", "John Deere", "5075EN", new DateTime(2019, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica13 = new Caracteristica("Frutícola", "Lamborghini", "RF 90", new DateTime(2023, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica14 = new Caracteristica("Ganadero", "Ford", "6610", new DateTime(2010, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica15 = new Caracteristica("Cerealero", "Claas", "Arion 430", new DateTime(2021, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica16 = new Caracteristica("Frutícola", "Valpadana", "9000 Series", new DateTime(2020, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica17 = new Caracteristica("Forestal", "Antonio Carraro", "TTR 7600", new DateTime(2017, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica18 = new Caracteristica("Vitícola", "John Deere", "3036E", new DateTime(2022, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica19 = new Caracteristica("Minero", "CAT", "416E", new DateTime(2016, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica20 = new Caracteristica("Ganadero", "Fendt", "720 Vario", new DateTime(2023, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            AltaCaracteristica(caracteristica1);
            AltaCaracteristica(caracteristica2);
            AltaCaracteristica(caracteristica3);
            AltaCaracteristica(caracteristica4);
            AltaCaracteristica(caracteristica5);
            AltaCaracteristica(caracteristica6);
            AltaCaracteristica(caracteristica7);
            AltaCaracteristica(caracteristica8);
            AltaCaracteristica(caracteristica9);
            AltaCaracteristica(caracteristica10);
            AltaCaracteristica(caracteristica11);
            AltaCaracteristica(caracteristica12);
            AltaCaracteristica(caracteristica13);
            AltaCaracteristica(caracteristica14);
            AltaCaracteristica(caracteristica15);
            AltaCaracteristica(caracteristica16);
            AltaCaracteristica(caracteristica17);
            AltaCaracteristica(caracteristica18);
            AltaCaracteristica(caracteristica19);
            AltaCaracteristica(caracteristica20);

        }

        private void PreCargaDatosMaquinariasTractores()
        {
           
                Tractor tractor1 = new Tractor(true, ObtenerDireccionPorId(1), ObtenerCaracteristicaPorId(1), "Cabina cerrada, buen estado");
                Tractor tractor2 = new Tractor(false, ObtenerDireccionPorId(2), ObtenerCaracteristicaPorId(2), "Sin cabina, motor eficiente");
                Tractor tractor3 = new Tractor(true, ObtenerDireccionPorId(3), ObtenerCaracteristicaPorId(3), "Ideal para terrenos difíciles");
                Tractor tractor4 = new Tractor(false, ObtenerDireccionPorId(4), ObtenerCaracteristicaPorId(4), "Usado, buen mantenimiento");
                Tractor tractor5 = new Tractor(true, ObtenerDireccionPorId(5), ObtenerCaracteristicaPorId(5), "Equipado con luces LED");
                Tractor tractor6 = new Tractor(false, ObtenerDireccionPorId(6), ObtenerCaracteristicaPorId(6), "Compacto y maniobrable");
                Tractor tractor7 = new Tractor(true, ObtenerDireccionPorId(7), ObtenerCaracteristicaPorId(7), "Apto para agricultura intensiva");
                Tractor tractor8 = new Tractor(false, ObtenerDireccionPorId(8), ObtenerCaracteristicaPorId(8), "Sin cabina, ideal para campo abierto");
                Tractor tractor9 = new Tractor(true, ObtenerDireccionPorId(9), ObtenerCaracteristicaPorId(9), "Potente y confiable");
                Tractor tractor10 = new Tractor(false, ObtenerDireccionPorId(10), ObtenerCaracteristicaPorId(10), "Modelo antiguo, restaurado");
                Tractor tractor11 = new Tractor(true, ObtenerDireccionPorId(11), ObtenerCaracteristicaPorId(11), "Con cabina y aire acondicionado");
                Tractor tractor12 = new Tractor(false, ObtenerDireccionPorId(12), ObtenerCaracteristicaPorId(12), "Muy eficiente en consumo");
                Tractor tractor13 = new Tractor(true, ObtenerDireccionPorId(13), ObtenerCaracteristicaPorId(13), "Con cabina reforzada");
                Tractor tractor14 = new Tractor(false, ObtenerDireccionPorId(14), ObtenerCaracteristicaPorId(14), "Uso ganadero");
                Tractor tractor15 = new Tractor(true, ObtenerDireccionPorId(15), ObtenerCaracteristicaPorId(15), "Modelo moderno y versátil");
                Tractor tractor16 = new Tractor(false, ObtenerDireccionPorId(16), ObtenerCaracteristicaPorId(16), "Ideal para cultivos específicos");
                Tractor tractor17 = new Tractor(true, ObtenerDireccionPorId(17), ObtenerCaracteristicaPorId(17), "Mantenimiento al día");
                Tractor tractor18 = new Tractor(false, ObtenerDireccionPorId(18), ObtenerCaracteristicaPorId(18), "Compacto y eficiente");
                Tractor tractor19 = new Tractor(true, ObtenerDireccionPorId(19), ObtenerCaracteristicaPorId(19), "Versátil para varios usos");
                Tractor tractor20 = new Tractor(false, ObtenerDireccionPorId(20), ObtenerCaracteristicaPorId(20), "Con poco uso, excelente estado");

                AltaMaquinaria(tractor1);
                AltaMaquinaria(tractor2);
                AltaMaquinaria(tractor3);
                AltaMaquinaria(tractor4);
                AltaMaquinaria(tractor5);
                AltaMaquinaria(tractor6);
                AltaMaquinaria(tractor7);
                AltaMaquinaria(tractor8);
                AltaMaquinaria(tractor9);
                AltaMaquinaria(tractor10);
                AltaMaquinaria(tractor11);
                AltaMaquinaria(tractor12);
                AltaMaquinaria(tractor13);
                AltaMaquinaria(tractor14);
                AltaMaquinaria(tractor15);
                AltaMaquinaria(tractor16);
                AltaMaquinaria(tractor17);
                AltaMaquinaria(tractor18);
                AltaMaquinaria(tractor19);
                AltaMaquinaria(tractor20);
            

        }
        #endregion

        #region Pre carga Cargadora Pala
        private void PreCargaCaracteristicasCargadoraPala()
        {
            Caracteristica caracteristica21 = new Caracteristica("Construcción", "Caterpillar", "938M", new DateTime(2019, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica22 = new Caracteristica("Construcción", "Volvo", "L90H", new DateTime(2020, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica23 = new Caracteristica("Minería", "Komatsu", "WA320", new DateTime(2018, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica24 = new Caracteristica("Forestal", "John Deere", "444K", new DateTime(2021, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica25 = new Caracteristica("Industrial", "Hyundai", "HL940", new DateTime(2017, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica26 = new Caracteristica("Construcción", "Doosan", "DL250", new DateTime(2022, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica27 = new Caracteristica("Minería", "Liebherr", "L538", new DateTime(2023, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica28 = new Caracteristica("Construcción", "JCB", "427ZX", new DateTime(2016, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica29 = new Caracteristica("Forestal", "Hitachi", "ZW220", new DateTime(2020, 1, 1), false, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica30 = new Caracteristica("Construcción", "CASE", "621G", new DateTime(2021, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);

            AltaCaracteristica(caracteristica21);
            AltaCaracteristica(caracteristica22);
            AltaCaracteristica(caracteristica23);
            AltaCaracteristica(caracteristica24);
            AltaCaracteristica(caracteristica25);
            AltaCaracteristica(caracteristica26);
            AltaCaracteristica(caracteristica27);
            AltaCaracteristica(caracteristica28);
            AltaCaracteristica(caracteristica29);
            AltaCaracteristica(caracteristica30);
        }

        private void PreCargaDireccionCargadoraPala()
        {
            Direccion direccion21 = new Direccion("Uruguay", "Canelones", "Suárez");
            Direccion direccion22 = new Direccion("Uruguay", "Maldonado", "San Carlos");
            Direccion direccion23 = new Direccion("Uruguay", "Montevideo", "La Teja");
            Direccion direccion24 = new Direccion("Uruguay", "Rocha", "Lascano");
            Direccion direccion25 = new Direccion("Uruguay", "Rivera", "Minas de Corrales");
            Direccion direccion26 = new Direccion("Uruguay", "Salto", "Termas del Daymán");
            Direccion direccion27 = new Direccion("Uruguay", "Artigas", "Tomás Gomensoro");
            Direccion direccion28 = new Direccion("Uruguay", "Paysandú", "Guichón");
            Direccion direccion29 = new Direccion("Uruguay", "Colonia", "Nueva Palmira");
            Direccion direccion30 = new Direccion("Uruguay", "Treinta y Tres", "Santa Clara de Olimar");

            AltaDireccion(direccion21);
            AltaDireccion(direccion22);
            AltaDireccion(direccion23);
            AltaDireccion(direccion24);
            AltaDireccion(direccion25);
            AltaDireccion(direccion26);
            AltaDireccion(direccion27);
            AltaDireccion(direccion28);
            AltaDireccion(direccion29);
            AltaDireccion(direccion30);
        }

        private void PreCargaMaquinariaCargadoraPala()
        {
            CargadoraPala cargadora1 = new CargadoraPala(6, "CAT", ObtenerDireccionPorId(21), ObtenerCaracteristicaPorId(21), "Ideal para minería pesada");
            CargadoraPala cargadora2 = new CargadoraPala(4, "Volvo", ObtenerDireccionPorId(22), ObtenerCaracteristicaPorId(22), "Uso frecuente en obras urbanas");
            CargadoraPala cargadora3 = new CargadoraPala(8, "Komatsu", ObtenerDireccionPorId(23), ObtenerCaracteristicaPorId(23), "Alta resistencia en terrenos difíciles");
            CargadoraPala cargadora4 = new CargadoraPala(5, "JD Power", ObtenerDireccionPorId(24), ObtenerCaracteristicaPorId(24), "Buena para zonas forestales");
            CargadoraPala cargadora5 = new CargadoraPala(4, "Hyundai", ObtenerDireccionPorId(25), ObtenerCaracteristicaPorId(25), "Ideal para espacios reducidos");
            CargadoraPala cargadora6 = new CargadoraPala(6, "Doosan", ObtenerDireccionPorId(26), ObtenerCaracteristicaPorId(26), "Potente y compacta");
            CargadoraPala cargadora7 = new CargadoraPala(7, "Liebherr", ObtenerDireccionPorId(27), ObtenerCaracteristicaPorId(27), "Excelente consumo de combustible");
            CargadoraPala cargadora8 = new CargadoraPala(4, "JCB", ObtenerDireccionPorId(28), ObtenerCaracteristicaPorId(28), "Fácil mantenimiento");
            CargadoraPala cargadora9 = new CargadoraPala(5, "Hitachi", ObtenerDireccionPorId(29), ObtenerCaracteristicaPorId(29), "Buena visibilidad desde cabina");
            CargadoraPala cargadora10 = new CargadoraPala(6, "CASE", ObtenerDireccionPorId(30), ObtenerCaracteristicaPorId(30), "Versátil y robusta");

            AltaMaquinaria(cargadora1);
            AltaMaquinaria(cargadora2);
            AltaMaquinaria(cargadora3);
            AltaMaquinaria(cargadora4);
            AltaMaquinaria(cargadora5);
            AltaMaquinaria(cargadora6);
            AltaMaquinaria(cargadora7);
            AltaMaquinaria(cargadora8);
            AltaMaquinaria(cargadora9);
            AltaMaquinaria(cargadora10);
        }
        #endregion

        #region Pre carga de Cosechadora
        private void PreCargaCaracteristicasCosechadoras()
        {
            Caracteristica caracteristica31 = new Caracteristica("Agrícola", "John Deere", "S780", new DateTime(2020, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica32 = new Caracteristica("Cerealera", "Case IH", "Axial-Flow 8250", new DateTime(2021, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica33 = new Caracteristica("Arrocera", "New Holland", "CR10.90", new DateTime(2019, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica34 = new Caracteristica("Maicera", "Claas", "Lexion 8900", new DateTime(2022, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica35 = new Caracteristica("Cerealera", "Massey Ferguson", "9895", new DateTime(2018, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica36 = new Caracteristica("Sojera", "Deutz-Fahr", "C9306", new DateTime(2020, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica37 = new Caracteristica("General", "Gleaner", "S98", new DateTime(2017, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica38 = new Caracteristica("Cerealera", "Fendt", "Ideal 9T", new DateTime(2021, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica39 = new Caracteristica("Multicultivo", "Laverda", "M410", new DateTime(2019, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica40 = new Caracteristica("General", "Sampo Rosenlew", "Comia C12", new DateTime(2022, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);

            AltaCaracteristica(caracteristica31);
            AltaCaracteristica(caracteristica32);
            AltaCaracteristica(caracteristica33);
            AltaCaracteristica(caracteristica34);
            AltaCaracteristica(caracteristica35);
            AltaCaracteristica(caracteristica36);
            AltaCaracteristica(caracteristica37);
            AltaCaracteristica(caracteristica38);
            AltaCaracteristica(caracteristica39);
            AltaCaracteristica(caracteristica40);
        }

        private void PreCargaDireccionCosechadoras()
        {
            Direccion direccion31 = new Direccion("Uruguay", "Canelones", "Toledo");
            Direccion direccion32 = new Direccion("Uruguay", "San José", "Rafael Perazza");
            Direccion direccion33 = new Direccion("Uruguay", "Florida", "Independencia");
            Direccion direccion34 = new Direccion("Uruguay", "Paysandú", "Guichón");
            Direccion direccion35 = new Direccion("Uruguay", "Colonia", "Florencio Sánchez");
            Direccion direccion36 = new Direccion("Uruguay", "Soriano", "José Enrique Rodó");
            Direccion direccion37 = new Direccion("Uruguay", "Lavalleja", "Mariscala");
            Direccion direccion38 = new Direccion("Uruguay", "Durazno", "Sarandí del Yí");
            Direccion direccion39 = new Direccion("Uruguay", "Rocha", "Lascano");
            Direccion direccion40 = new Direccion("Uruguay", "Maldonado", "Pan de Azúcar");

            AltaDireccion(direccion31);
            AltaDireccion(direccion32);
            AltaDireccion(direccion33);
            AltaDireccion(direccion34);
            AltaDireccion(direccion35);
            AltaDireccion(direccion36);
            AltaDireccion(direccion37);
            AltaDireccion(direccion38);
            AltaDireccion(direccion39);
            AltaDireccion(direccion40);
        }

        private void PreCargaMaquinariaCosechadora()
        {
            Cosechadora c1 = new Cosechadora("Maicera", 12000, true, ObtenerDireccionPorId(31), ObtenerCaracteristicaPorId(31), "Cosechadora rápida");
            Cosechadora c2 = new Cosechadora("Arrocera", 10000, false, ObtenerDireccionPorId(32), ObtenerCaracteristicaPorId(32), "Modelo reforzado");
            Cosechadora c3 = new Cosechadora("General", 9500, true, ObtenerDireccionPorId(33), ObtenerCaracteristicaPorId(33), "Sistema GPS incluido");
            Cosechadora c4 = new Cosechadora("Sojera", 11000, false, ObtenerDireccionPorId(34), ObtenerCaracteristicaPorId(34), "Nuevo sistema hidráulico");
            Cosechadora c5 = new Cosechadora("Multicultivo", 13000, true, ObtenerDireccionPorId(35), ObtenerCaracteristicaPorId(35), "Poco uso");
            Cosechadora c6 = new Cosechadora("Cerealera", 9000, false, ObtenerDireccionPorId(36), ObtenerCaracteristicaPorId(36), "Eficiencia optimizada");
            Cosechadora c7 = new Cosechadora("Maicera", 10500, true, ObtenerDireccionPorId(37), ObtenerCaracteristicaPorId(37), "Con cabina climatizada");
            Cosechadora c8 = new Cosechadora("Sojera", 9500, false, ObtenerDireccionPorId(38), ObtenerCaracteristicaPorId(38), "Lista para trabajar");
            Cosechadora c9 = new Cosechadora("Arrocera", 11500, true, ObtenerDireccionPorId(39), ObtenerCaracteristicaPorId(39), "Muy cuidada");
            Cosechadora c10 = new Cosechadora("General", 12500, true, ObtenerDireccionPorId(40), ObtenerCaracteristicaPorId(40), "Sistema de trilla optimizado");

            AltaMaquinaria(c1);
            AltaMaquinaria(c2);
            AltaMaquinaria(c3);
            AltaMaquinaria(c4);
            AltaMaquinaria(c5);
            AltaMaquinaria(c6);
            AltaMaquinaria(c7);
            AltaMaquinaria(c8);
            AltaMaquinaria(c9);
            AltaMaquinaria(c10);
        }
        #endregion

        #region Fertilizadora pre carga
        private void PreCargaCaracteristicasFertilizadora()
        {
            Caracteristica caracteristica41 = new Caracteristica("Fertilizadora autopropulsada", "John Deere", "F4365", new DateTime(2021, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica42 = new Caracteristica("Fertilizadora arrastrada", "Case IH", "Patriot 350", new DateTime(2019, 6, 15), false, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica43 = new Caracteristica("Fertilizadora neumática", "Horsch", "Pronto 12 SW", new DateTime(2020, 3, 10), true, false, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica44 = new Caracteristica("Fertilizadora centrífuga", "Kuhn", "Axis 40.2", new DateTime(2018, 11, 25), false, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica45 = new Caracteristica("Fertilizadora de precisión", "Amazone", "UX 5200", new DateTime(2022, 2, 5), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica46 = new Caracteristica("Fertilizadora de gran escala", "Vicon", "RotaFlow 1500", new DateTime(2017, 7, 20), false, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica47 = new Caracteristica("Fertilizadora de jardín", "Agroplast", "GP1500", new DateTime(2021, 9, 30), true, false, TipoCombustible.NAFTA, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica48 = new Caracteristica("Fertilizadora manual", "Howard", "Manual Spreader", new DateTime(2016, 4, 12), false, false, TipoCombustible.NAFTA, TipoDireccion.MECANICO);
            Caracteristica caracteristica49 = new Caracteristica("Fertilizadora de tambor", "Great Plains", "FX1500", new DateTime(2019, 8, 22), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica50 = new Caracteristica("Fertilizadora pivote móvil", "Gandy", "MPRO 1000", new DateTime(2020, 12, 1), false, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);

            AltaCaracteristica(caracteristica41);
            AltaCaracteristica(caracteristica42);
            AltaCaracteristica(caracteristica43);
            AltaCaracteristica(caracteristica44);
            AltaCaracteristica(caracteristica45);
            AltaCaracteristica(caracteristica46);
            AltaCaracteristica(caracteristica47);
            AltaCaracteristica(caracteristica48);
            AltaCaracteristica(caracteristica49);
            AltaCaracteristica(caracteristica50);
        }
        public void PreCargaDireccionFertilizadora()
        {
            Direccion direccion41 = new Direccion("Uruguay", "Salto", "Centro");
            Direccion direccion42 = new Direccion("Uruguay", "Paysandú", "Norte");
            Direccion direccion43 = new Direccion("Uruguay", "Tacuarembó", "Este");
            Direccion direccion44 = new Direccion("Uruguay", "Rivera", "Oeste");
            Direccion direccion45 = new Direccion("Uruguay", "Melo", "Sur");
            Direccion direccion46 = new Direccion("Uruguay", "Mercedes", "Barrio Sur");
            Direccion direccion47 = new Direccion("Uruguay", "Florida", "Centro");
            Direccion direccion48 = new Direccion("Uruguay", "Durazno", "Barrio Industrial");
            Direccion direccion49 = new Direccion("Uruguay", "Canelones", "Ciudad de la Costa");
            Direccion direccion50 = new Direccion("Uruguay", "Rocha", "La Paloma");

            AltaDireccion(direccion41);
            AltaDireccion(direccion42);
            AltaDireccion(direccion43);
            AltaDireccion(direccion44);
            AltaDireccion(direccion45);
            AltaDireccion(direccion46);
            AltaDireccion(direccion47);
            AltaDireccion(direccion48);
            AltaDireccion(direccion49);
            AltaDireccion(direccion50);
        }
        private void PreCargaMaquinariaFertilizadora()
        {
            Fertilizadora fertilizadora41 = new Fertilizadora("Cummins", 350, true, ObtenerDireccionPorId(41), ObtenerCaracteristicaPorId(41), "Sistema de aplicación variable con GPS");
            Fertilizadora fertilizadora42 = new Fertilizadora("Perkins", 300, false, ObtenerDireccionPorId(42), ObtenerCaracteristicaPorId(42), "Capacidad tanque 4000 litros");
            Fertilizadora fertilizadora43 = new Fertilizadora("John Deere", 320, true, ObtenerDireccionPorId(43), ObtenerCaracteristicaPorId(43), "Control automático de dosis");
            Fertilizadora fertilizadora44 = new Fertilizadora("Cummins", 280, false, ObtenerDireccionPorId(44), ObtenerCaracteristicaPorId(44), "Distribución centrífuga precisa");
            Fertilizadora fertilizadora45 = new Fertilizadora("Kubota", 350, true, ObtenerDireccionPorId(45), ObtenerCaracteristicaPorId(45), "Equipo equipado con sensores de humedad");
            Fertilizadora fertilizadora46 = new Fertilizadora("Volvo Penta", 360, false, ObtenerDireccionPorId(46), ObtenerCaracteristicaPorId(46), "Alta eficiencia en consumo de combustible");
            Fertilizadora fertilizadora47 = new Fertilizadora("Deutz", 200, true, ObtenerDireccionPorId(47), ObtenerCaracteristicaPorId(47), "Diseñada para terrenos irregulares");
            Fertilizadora fertilizadora48 = new Fertilizadora("John Deere", 150, false, ObtenerDireccionPorId(48), ObtenerCaracteristicaPorId(48), "Ideal para pequeñas explotaciones");
            Fertilizadora fertilizadora49 = new Fertilizadora("Cummins", 330, true, ObtenerDireccionPorId(49), ObtenerCaracteristicaPorId(49), "Sistema neumático avanzado");
            Fertilizadora fertilizadora50 = new Fertilizadora("Perkins", 310, false, ObtenerDireccionPorId(50), ObtenerCaracteristicaPorId(50), "Control electrónico del sistema");

            AltaMaquinaria(fertilizadora41);
            AltaMaquinaria(fertilizadora42);
            AltaMaquinaria(fertilizadora43);
            AltaMaquinaria(fertilizadora44);
            AltaMaquinaria(fertilizadora45);
            AltaMaquinaria(fertilizadora46);
            AltaMaquinaria(fertilizadora47);
            AltaMaquinaria(fertilizadora48);
            AltaMaquinaria(fertilizadora49);
            AltaMaquinaria(fertilizadora50);
        }
        #endregion

        private void PreCargaCaracteristicasSembradora()
        {
            Caracteristica caracteristica51 = new Caracteristica("Agrícola", "John Deere", "X9", new DateTime(2021, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica52 = new Caracteristica("Precisión", "Case IH", "Early Riser 2150", new DateTime(2020, 1, 1), false, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica53 = new Caracteristica("Neumática", "New Holland", "P2080", new DateTime(2019, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica54 = new Caracteristica("Mecánica", "Kuhn", "Maxima 3", new DateTime(2022, 1, 1), false, false, TipoCombustible.NAFTA, TipoDireccion.MECANICO);
            Caracteristica caracteristica55 = new Caracteristica("Directa", "Agco", "Tempo L", new DateTime(2018, 1, 1), true, true, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica56 = new Caracteristica("Agrícola", "Gaspardo", "MTR 12", new DateTime(2021, 1, 1), false, false, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica57 = new Caracteristica("Precisión", "Horsch", "Pronto 9 SW", new DateTime(2020, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica58 = new Caracteristica("Neumática", "Vaderstad", "Spirit 600", new DateTime(2019, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);
            Caracteristica caracteristica59 = new Caracteristica("Mecánica", "Great Plains", "CD-4000", new DateTime(2022, 1, 1), true, false, TipoCombustible.GASOIL, TipoDireccion.AUTOMATICO);
            Caracteristica caracteristica60 = new Caracteristica("Directa", "John Deere", "DB60", new DateTime(2021, 1, 1), false, true, TipoCombustible.GASOIL, TipoDireccion.MECANICO);

            AltaCaracteristica(caracteristica51);
            AltaCaracteristica(caracteristica52);
            AltaCaracteristica(caracteristica53);
            AltaCaracteristica(caracteristica54);
            AltaCaracteristica(caracteristica55);
            AltaCaracteristica(caracteristica56);
            AltaCaracteristica(caracteristica57);
            AltaCaracteristica(caracteristica58);
            AltaCaracteristica(caracteristica59);
            AltaCaracteristica(caracteristica60);
        }
        private void PreCargaDireccionSembradora()
        {
            Direccion direccion51 = new Direccion("Uruguay", "Montevideo", "Pocitos");
            Direccion direccion52 = new Direccion("Uruguay", "Montevideo", "Carrasco");
            Direccion direccion53 = new Direccion("Uruguay", "Canelones", "Las Piedras");
            Direccion direccion54 = new Direccion("Uruguay", "Maldonado", "Punta del Este");
            Direccion direccion55 = new Direccion("Uruguay", "Colonia", "Colonia del Sacramento");
            Direccion direccion56 = new Direccion("Uruguay", "Salto", "Centro");
            Direccion direccion57 = new Direccion("Uruguay", "Paysandú", "Parque Rodó");
            Direccion direccion58 = new Direccion("Uruguay", "Durazno", "Barrio Oeste");
            Direccion direccion59 = new Direccion("Uruguay", "Tacuarembó", "Villa Sara");
            Direccion direccion60 = new Direccion("Uruguay", "Rivera", "Centro");

            AltaDireccion(direccion51);
            AltaDireccion(direccion52);
            AltaDireccion(direccion53);
            AltaDireccion(direccion54);
            AltaDireccion(direccion55);
            AltaDireccion(direccion56);
            AltaDireccion(direccion57);
            AltaDireccion(direccion58);
            AltaDireccion(direccion59);
            AltaDireccion(direccion60);
        }

        private void PreCargaMaquinariaSembradora()
        {
            Sembradora sembradora51 = new Sembradora("Neumática", ObtenerDireccionPorId(51), ObtenerCaracteristicaPorId(51), "Equipo bien cuidado");
            Sembradora sembradora52 = new Sembradora("Precisión", ObtenerDireccionPorId(52), ObtenerCaracteristicaPorId(52), "Última revisión hecha");
            Sembradora sembradora53 = new Sembradora("Mecánica", ObtenerDireccionPorId(53), ObtenerCaracteristicaPorId(53), "Muy buen estado general");
            Sembradora sembradora54 = new Sembradora("Directa", ObtenerDireccionPorId(54), ObtenerCaracteristicaPorId(54), "Poco uso en campo");
            Sembradora sembradora55 = new Sembradora("Agrícola", ObtenerDireccionPorId(55), ObtenerCaracteristicaPorId(55), "Incluye accesorios");
            Sembradora sembradora56 = new Sembradora("Precisión", ObtenerDireccionPorId(56), ObtenerCaracteristicaPorId(56), "Perfecta para siembra de precisión");
            Sembradora sembradora57 = new Sembradora("Neumática", ObtenerDireccionPorId(57), ObtenerCaracteristicaPorId(57), "Recién salida de servicio");
            Sembradora sembradora58 = new Sembradora("Mecánica", ObtenerDireccionPorId(58), ObtenerCaracteristicaPorId(58), "Ideal para grandes superficies");
            Sembradora sembradora59 = new Sembradora("Directa", ObtenerDireccionPorId(59), ObtenerCaracteristicaPorId(59), "Alta eficiencia");
            Sembradora sembradora60 = new Sembradora("Agrícola", ObtenerDireccionPorId(60), ObtenerCaracteristicaPorId(60), "Equipamiento completo");

            AltaMaquinaria(sembradora51);
            AltaMaquinaria(sembradora52);
            AltaMaquinaria(sembradora53);
            AltaMaquinaria(sembradora54);
            AltaMaquinaria(sembradora55);
            AltaMaquinaria(sembradora56);
            AltaMaquinaria(sembradora57);
            AltaMaquinaria(sembradora58);
            AltaMaquinaria(sembradora59);
            AltaMaquinaria(sembradora60);
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

        #region ObtenerPorParametros
        public Caracteristica ObtenerCaracteristicaPorId(int id)
        { 
            foreach(Caracteristica c in listaCaracteristicas)
            {
                if(c.IdCaracteristica == id)
                {
                    return c;
                }
            }
            throw new Exception("No existe una característica con este Id");
        
        }

        public Direccion ObtenerDireccionPorId(int id)
        {
            foreach(Direccion d in listaDirecciones)
            {
                if(d.IdDireccion == id)
                {
                    return d;
                }
            }
            throw new Exception("No existe una direccion con ese Id");
        }
        #endregion
    }
}
