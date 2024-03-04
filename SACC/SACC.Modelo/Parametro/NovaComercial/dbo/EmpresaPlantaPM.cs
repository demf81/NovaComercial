using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class EmpresaPlantaPM : ModeloBasePM
    {
        public EmpresaPlantaPM()
        {
            _EmpresaPlantaId          = 0;
            _EmpresaPlantaDescripcion = String.Empty;
            _EmpresaId                = 0;
        }


        Int32 _EmpresaPlantaId;
        public Int32 EmpresaPlantaId { get { return _EmpresaPlantaId; } set { _EmpresaPlantaId = value; } }

        String _EmpresaPlantaDescripcion;
        public String EmpresaPlantaDescripcion { get { return _EmpresaPlantaDescripcion; } set { _EmpresaPlantaDescripcion = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }
    }
}