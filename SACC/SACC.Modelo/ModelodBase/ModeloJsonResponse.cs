using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Modelo
{
    public class ModeloJsonResponse
    {
        public ModeloJsonResponse()
        {
            _Id            = -1;
            _TituloError   = "Error no registrado";
            _Mensaje       = "";
            _TipoMensaje   = "success";
            _Error         = false;
            _MensajeError  = "Error Inesperado";
            _StatusCode    = 200;
            _MuestraAlerta = false;
            _DelayTime     = false;
        }

        Int32 _Id;
        public Int32 Id { get { return _Id; } set { _Id = value; } }

        String _TituloError;
        public String TituloError { get { return _TituloError; } set { _TituloError = value; } }

        String _Mensaje;
        public String Mensaje { get { return _Mensaje; } set { _Mensaje = value; } }

        String _TipoMensaje;
        public String TipoMensaje { get { return _TipoMensaje; } set { _TipoMensaje = value; } }
        
        Boolean _Error;
        public Boolean Error { get { return _Error; } set { _Error = value; } }
        
        String _MensajeError;
        public String MensajeError { get { return _MensajeError; } set { _MensajeError = value; } }

        Int32 _StatusCode;
        public Int32 StatusCode { get { return _StatusCode; } set { _StatusCode = value; } }
        
        Boolean _MuestraAlerta;
        public Boolean MuestraAlert { get { return _MuestraAlerta; } set { _MuestraAlerta = value; } }
        
        Boolean _DelayTime;
        public Boolean DelayTime { get { return _DelayTime; } set { _DelayTime = value; } }
        
        public List<SelectListItem> Lista { get; set; }
    }


    public class ModeloJsonResponse<T>
    {
        public ModeloJsonResponse()
        {
            _Id            = -1;
            _TituloError   = String.Empty; // "Error no registrado";
            _Mensaje       = "";
            _TipoMensaje   = String.Empty; // "success";
            _Error         = false;
            _MensajeError  = String.Empty; // "Error Inesperado";
            _StatusCode    = 200;
            _MuestraAlerta = false;
            _DelayTime     = false;
        }

        Int32 _Id;
        public Int32 Id { get { return _Id; } set { _Id = value; } }

        String _TituloError;
        public String TituloError { get { return _TituloError; } set { _TituloError = value; } }

        String _Mensaje;
        public String Mensaje { get { return _Mensaje; } set { _Mensaje = value; } }

        String _TipoMensaje;
        public String TipoMensaje { get { return _TipoMensaje; } set { _TipoMensaje = value; } }
        
        Boolean _Error;
        public Boolean Error { get { return _Error; } set { _Error = value; } }

        String _MensajeError;
        public String MensajeError { get { return _MensajeError; } set { _MensajeError = value; } }

        Int32 _StatusCode;
        public Int32 StatusCode { get { return _StatusCode; } set { _StatusCode = value; } }
        
        Boolean _MuestraAlerta;
        public Boolean MuestraAlert { get { return _MuestraAlerta; } set { _MuestraAlerta = value; } }
        
        Boolean _DelayTime;
        public Boolean DelayTime { get { return _DelayTime; } set { _DelayTime = value; } }
        
        public IList<T> Datos { get; set; }
        
        public List<SelectListItem> Lista { get; set; }
    }
}