using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.EmpresaPlanta
{
    public class DtoEmpresaPlanta : ModeloBase
    {
        public DtoEmpresaPlanta()
        {
            _EmpresaPlantaDescripcion = String.Empty;
        }


        Int32 _EmpresaPlantaId;
        public Int32 EmpresaPlantaId { get { return _EmpresaPlantaId; } set { _EmpresaPlantaId = value; } }

        String _EmpresaPlantaDescripcion;
        [StringLength(200)]
        public String EmpresaPlantaDescripcion { get { return _EmpresaPlantaDescripcion; } set { _EmpresaPlantaDescripcion = value; } }
    }
}