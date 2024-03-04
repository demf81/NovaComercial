using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class PersonaMoperPM : ModeloBasePM
    {
        public PersonaMoperPM()
        {

        }


        Int32 _PersonaMoperId;
        public Int32 PersonaMoperId { get { return _PersonaMoperId; } set { _PersonaMoperId = value; } }
    }
}