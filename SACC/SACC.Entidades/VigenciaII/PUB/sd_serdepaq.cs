using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class sd_serdepaq
    {
        public sd_serdepaq()
        {
            _sd_paquete_id  = string.Empty;
            _sd_servicio_id = string.Empty;
        }


        String _sd_paquete_id;
        [StringLength(4)]
        public String sd_paquete_id { get { return _sd_paquete_id; } set { _sd_paquete_id = value; } }


        String _sd_servicio_id;
        [StringLength(4)]
        public String sd_servicio_id { get { return _sd_servicio_id; } set { _sd_servicio_id = value; } }


        String _socio_id;
        [StringLength(10)]
        public String socio_id { get { return _socio_id; } set { _socio_id = value; } }


        String _clavefamiliar;
        [StringLength(5)]
        public String clavefamiliar { get { return _clavefamiliar; } set { _clavefamiliar = value; } }


        String _co_contrat_id;
        [StringLength(50)]
        public String co_contrat_id { get { return _co_contrat_id; } set { _co_contrat_id = value; } }


        String _co_contrato_id;
        [StringLength(50)]
        public String co_contrato_id { get { return _co_contrato_id; } set { _co_contrato_id = value; } }


        Boolean _procesotitular;
        public Boolean procesotitular { get { return _procesotitular; } set { _procesotitular = value; } }
    }
}