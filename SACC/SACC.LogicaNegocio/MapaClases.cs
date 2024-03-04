using System.Collections.Generic;


namespace SACC.LogicaNegocio
{
    public static class MapaClases
    {
        public static dynamic EntityToData(object oBE)
        {
            Dictionary<object, object> DataList = new Dictionary<object, object>();


            DataList.Add(typeof(Entidades.Nova_ServiciosMedicos.dbo.CatAsociado)       , typeof(AccesoDatos.Nova_ServiciosMedicos.dbo.CatAsociado));
            DataList.Add(typeof(Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado) , typeof(AccesoDatos.Nova_ServiciosMedicos.dbo.TranDatosAfiliado));
            DataList.Add(typeof(Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa)  , typeof(AccesoDatos.Nova_ServiciosMedicos.dbo.TranDatosEmpresa));
            DataList.Add(typeof(Entidades.Nova_ServiciosMedicos.dbo.tblVentasUnitarias), typeof(AccesoDatos.Nova_ServiciosMedicos.dbo.tblVentasUnitarias));


            //DataList.Add(typeof(SACC.Entidades.NovaComercial.dbo.AreaNegocio)             , typeof(SACC.AccesoDatos.NovaComercial.dbo.AreaNegocio));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Asociado)                  , typeof(AccesoDatos.NovaComercial.dbo.Asociado));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Cirugia)                   , typeof(AccesoDatos.NovaComercial.dbo.Cirugia));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Contrato)                  , typeof(AccesoDatos.NovaComercial.dbo.Contrato));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.ContratoCobertura)         , typeof(AccesoDatos.NovaComercial.dbo.ContratoCobertura));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.ContratoCoberturaPaquete)  , typeof(AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.ContratoProductoPaquete)   , typeof(AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.ContratoProducto)          , typeof(AccesoDatos.NovaComercial.dbo.ContratoProducto));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.ContratoTipo)              , typeof(AccesoDatos.NovaComercial.dbo.ContratoTipo));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Empresa)                   , typeof(AccesoDatos.NovaComercial.dbo.Empresa));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.EmpresaContrato)           , typeof(AccesoDatos.NovaComercial.dbo.EmpresaContrato));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.EmpresaPlanta)             , typeof(AccesoDatos.NovaComercial.dbo.EmpresaPlanta));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Estudio)                   , typeof(AccesoDatos.NovaComercial.dbo.Estudio));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.LogImportacionesSACC)      , typeof(AccesoDatos.NovaComercial.dbo.LogImportacionesSACC));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Material)                  , typeof(AccesoDatos.NovaComercial.dbo.Material));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Medicamento)               , typeof(AccesoDatos.NovaComercial.dbo.Medicamento));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.MedicamentoCuadroTipo)     , typeof(AccesoDatos.NovaComercial.dbo.MedicamentoCuadroTipo));

            DataList.Add(typeof(Entidades.NovaComercial.dbo.Paquete)                   , typeof(AccesoDatos.NovaComercial.dbo.Paquete));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.PaqueteDetalle)            , typeof(AccesoDatos.NovaComercial.dbo.PaqueteDetalle));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.PaqueteTipo)               , typeof(AccesoDatos.NovaComercial.dbo.PaqueteTipo));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Persona)                   , typeof(AccesoDatos.NovaComercial.dbo.Persona));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.PersonaAsociado)           , typeof(AccesoDatos.NovaComercial.dbo.PersonaAsociado));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.PersonaContrato)           , typeof(AccesoDatos.NovaComercial.dbo.PersonaContrato));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.PersonaNumeroSocio)        , typeof(AccesoDatos.NovaComercial.dbo.PersonaNumeroSocio));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.PersonaPaquete)            , typeof(AccesoDatos.NovaComercial.dbo.PersonaPaquete));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.Servicio)                  , typeof(AccesoDatos.NovaComercial.dbo.Servicio));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.ServicioTipo)              , typeof(AccesoDatos.NovaComercial.dbo.ServicioTipo));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.VentaUnitaria)             , typeof(AccesoDatos.NovaComercial.dbo.VentaUnitaria));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.VentaUnitariaDetalle)      , typeof(AccesoDatos.NovaComercial.dbo.VentaUnitariaDetalle));
            DataList.Add(typeof(Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo)  , typeof(AccesoDatos.NovaComercial.dbo.VentaUnitariaDetalleTipo));

            //DataList.Add(typeof(Entidades.NovaComercial.PortalEmpresa.Perfil)          , typeof(AccesoDatos.NovaComercial.PortalEmpresa.Perfil));
            //DataList.Add(typeof(Entidades.NovaComercial.PortalEmpresa.Usuario)         , typeof(AccesoDatos.NovaComercial.PortalEmpresa.Usuario));
            //DataList.Add(typeof(Entidades.NovaComercial.PortalEmpresa.UsuarioContrato) , typeof(AccesoDatos.NovaComercial.PortalEmpresa.UsuarioContrato));

            DataList.Add(typeof(Entidades.Registro.dbo.CheckUp_Persona)                , typeof(AccesoDatos.Registro.dbo.CheckUp_Persona));

            DataList.Add(typeof(Entidades.VigenciaII.PUB.ccu_usuarios)                 , typeof(AccesoDatos.VigenciaII.PUB.ccu_usuarios));
            DataList.Add(typeof(Entidades.VigenciaII.PUB.tmu_usuarios)                 , typeof(AccesoDatos.VigenciaII.PUB.tmu_usuarios));
            DataList.Add(typeof(Entidades.VigenciaII.PUB.us_usuarios)                  , typeof(AccesoDatos.VigenciaII.PUB.us_usuarios));

            dynamic valor;

            if (DataList.TryGetValue(oBE.GetType(), out valor))
            {
                return valor;
            }

            return typeof(object);
        }
    }
}
