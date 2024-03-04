using System;
using System.ComponentModel.DataAnnotations;

namespace SACC.Entidades.Nova_ServiciosMedicos.dbo
{
    public class tblVentasUnitarias
    {
        public tblVentasUnitarias()
        {

        }


        Int32 _IdVentaUnitaria;
        public Int32 IdVentaUnitaria { get { return _IdVentaUnitaria; } set { _IdVentaUnitaria = value; } }


        String _vcDescripcion;
        [StringLength(1000)]
        public String vcDescripcion { get { return _vcDescripcion; } set { _vcDescripcion = value; } }

        
        Int32 _IdNumeroSocio;
        public Int32 IdNumeroSocio { get { return _IdNumeroSocio; } set { _IdNumeroSocio = value; } }
        

        String _vcAfiliado;
        [StringLength(50)]
        public String vcAfiliado { get { return _vcAfiliado; } set { _vcAfiliado = value; } }

        
        Int16 _bActivo;
        public Int16 bActivo { get { return _bActivo; } set { _bActivo = value; } }


        DateTime _dtFechaVencimiento;
        public DateTime dtFechaVencimiento { get { return _dtFechaVencimiento; } set { _dtFechaVencimiento = value; } }
    }
}