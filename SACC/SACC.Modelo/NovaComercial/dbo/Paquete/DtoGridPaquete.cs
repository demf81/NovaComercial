using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Paquete
{
    public class DtoGridPaquete : ModeloBasePM
    {
        public DtoGridPaquete()
        {

        }


        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _Codigo;
        [StringLength(50)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        String _PaqueteDescripcion;
        [StringLength(250)]
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        String _Genero;
        [StringLength(50)]
        public String Genero { get { return _Genero; } set { _Genero = value; } }

        String _RangoEdad;
        [StringLength(50)]
        public String RangoEdad { get { return _RangoEdad; } set { _RangoEdad = value; } }

        String _PaqueteTipoDescripcion;
        [StringLength(100)]
        public String PaqueteTipoDescripcion { get { return _PaqueteTipoDescripcion; } set { _PaqueteTipoDescripcion = value; } }

        Decimal _PrecioLista;
        [StringLength(50)]
        public Decimal PrecioLista { get { return _PrecioLista; } set { _PrecioLista = value; } }
    }
}