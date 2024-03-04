﻿using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ContratoCobertura
{
    public class DtoComboContratoCobertura
    {
        public DtoComboContratoCobertura()
        {
            _ContratoCoberturaDescripcion = string.Empty;
        }


        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        String _ContratoCoberturaDescripcion;
        [StringLength(100)]
        public String ContratoCoberturaDescripcion { get { return _ContratoCoberturaDescripcion; } set { _ContratoCoberturaDescripcion = value; } }
    }
}