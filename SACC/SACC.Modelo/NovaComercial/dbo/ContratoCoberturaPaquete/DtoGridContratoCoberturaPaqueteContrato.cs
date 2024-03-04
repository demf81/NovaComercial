using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACC.Modelo.NovaComercial.dbo.ContratoCoberturaPaquete
{
    public class DtoGridContratoCoberturaPaqueteContrato
    {
        public DtoGridContratoCoberturaPaqueteContrato()
        {

        }


        String _PaqueteDescripcion;
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        String _CoberturaCondicion;
        public String CoberturaCondicion { get { return _CoberturaCondicion; } set { _CoberturaCondicion = value; } }
    }
}