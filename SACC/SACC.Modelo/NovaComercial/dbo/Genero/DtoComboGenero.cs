using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Genero
{
    public class DtoComboGenero
    {
        public DtoComboGenero()
        {
            _GeneroDescripcion = String.Empty;
        }


        Int32 _GeneroId;
        public Int32 GeneroId { get { return _GeneroId; } set { _GeneroId = value; } }

        String _GeneroDescripcion;
        [StringLength(200)]
        public String GeneroDescripcion { get { return _GeneroDescripcion; } set { _GeneroDescripcion = value; } }
    }
}