using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class EmpresaPlanta : EntidadBase
    {
        public EmpresaPlanta()
        {
            _EmpresaPlantaDescripcion = string.Empty;
            _CodigoVigencia           = string.Empty;
            _CodigoAlternoNexus       = string.Empty;
            _Real                     = true;
        }


        Int32 _EmpresaPlantaId;
        public Int32 EmpresaPlantaId { get { return _EmpresaPlantaId; } set { _EmpresaPlantaId = value; } }

        String _EmpresaPlantaDescripcion;
        [StringLength(250)]
        public String EmpresaPlantaDescripcion { get { return _EmpresaPlantaDescripcion; } set { _EmpresaPlantaDescripcion = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        String _CodigoVigencia;
        [StringLength(10)]
        public String CodigoVigencia { get { return _CodigoVigencia; } set { _CodigoVigencia = value; } }

        Boolean _Real;
        public Boolean Real { get { return _Real; } set { _Real = value; } }

        String _CodigoAlternoNexus;
        [StringLength(10)]
        public String CodigoAlternoNexus { get { return _CodigoAlternoNexus; } set { _CodigoAlternoNexus = value; } }

        Int32 _EmpresaNexusId;
        public Int32 EmpresaNexusId { get { return _EmpresaNexusId; } set { _EmpresaNexusId = value; } }
    }
}