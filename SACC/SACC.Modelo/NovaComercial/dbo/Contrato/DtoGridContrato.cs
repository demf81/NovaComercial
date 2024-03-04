using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Contrato
{
    public class DtoGridContrato
    {
        public DtoGridContrato()
        {
            _ContratoDescripcion = String.Empty;
        }


        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoDescripcion;
        [StringLength(200)]
        public String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }

        String _ContratoTipoDescripcion;
        [StringLength(200)]
        public String ContratoTipoDescripcion { get { return _ContratoTipoDescripcion; } set { _ContratoTipoDescripcion = value; } }

        String _EmpresaPlantaDescripcion;
        [StringLength(200)]
        public String EmpresaPlantaDescripcion { get { return _EmpresaPlantaDescripcion; } set { _EmpresaPlantaDescripcion = value; } }

        Int16 _ContratoEstatusId;
        public Int16 ContratoEstatusId { get { return _ContratoEstatusId; } set { _ContratoEstatusId = value; } }
    }
}