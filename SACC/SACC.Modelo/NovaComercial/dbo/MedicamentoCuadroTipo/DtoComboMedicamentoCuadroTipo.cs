﻿using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.MedicamentoCuadroTipo
{
    public class DtoComboMedicamentoCuadroTipo
    {
        public DtoComboMedicamentoCuadroTipo()
        { }
        
        Int32 _MedicamentoCuadroTipoId;
        public Int32 MedicamentoCuadroTipoId { get { return _MedicamentoCuadroTipoId; } set { _MedicamentoCuadroTipoId = value; } }
        
        String _MedicamentoCuadroTipoDescripcion;
        [StringLength(150)]
        public String MedicamentoCuadroTipoDescripcion { get { return _MedicamentoCuadroTipoDescripcion; } set { _MedicamentoCuadroTipoDescripcion = value; } }
    }
}