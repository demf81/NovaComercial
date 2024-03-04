using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wsSACC
{
    [ServiceContract]
    public interface IVigencia
    {
        [OperationContract]
        Respuesta AltaAsociado(DatosAlta asociado, Token pToken);

        [OperationContract]
        Respuesta CambioAsociado(DatosCambio asociado, Token pToken);

        [OperationContract]
        Respuesta BajaAsociado(DatosBaja asociado, Token pToken);

        [OperationContract]
        Respuesta ReactivaAsociado(DatosReactivacion asociado, Token pToken);

    }

    [DataContract]
    public class DatosAlta
    {
        [DataMember]
        public int NumeroSocio { get; set; }

        [DataMember]
        public int ClaveFamiliar { get; set ; }

        [DataMember]
        public string Nombre { get; set ; }

        [DataMember]
        public string Paterno { get ; set ; }

        [DataMember]
        public string Materno { get; set; }

        [DataMember]
        public string Curp { get; set; }

        [DataMember]
        public string TipoUsuario { get; set; }

        [DataMember]
        public string ClaveTipoSanguineo { get; set; }

        [DataMember]
        public string ClaveEstadoCivil { get; set; }

        [DataMember]
        public string Sexo { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public DateTime FechaAltaContrato { get; set; }

        [DataMember]
        public DateTime FechaMovimiento { get; set; }

        [DataMember]
        public DateTime? FechaBajaContrato { get; set; }

        [DataMember]
        public string ClaveEmpresaContrato { get; set; }

        [DataMember]
        public string ClavePlantaContrato { get; set; }

        [DataMember]
        public string RFCSocio { get; set; }

        [DataMember]
        public string Calle { get; set; }

        [DataMember]
        public string NumeroExterior { get; set; }

        [DataMember]
        public string CodigoPostal { get; set; }

        [DataMember]
        public string Colonia { get; set; }

        [DataMember]
        public string Pais{ get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string Ciudad { get; set; }

        [DataMember]
        public int TelefonoCasa { get; set; }

        [DataMember]
        public int TelefonoOficina { get; set; }

        [DataMember]
        public int Extension { get; set; }

        [DataMember]
        public int Fax{ get; set; }

        [DataMember]
        public string CorreoElectronico { get; set; }

        [DataMember]
        public int NumeroAfiliacionIMSS { get; set; }

        [DataMember]
        public string ApellidoCasadaEsposa { get; set; }

        [DataMember]
        public string SocioId { get; set; }

        [DataMember]
        public int NumeroPoliza { get; set; }

        [DataMember]
        public int NumeroEndoso { get; set; }

        [DataMember]
        public string TipoTrabajador { get; set; }
    }

    [DataContract]
    public class DatosCambio
    {
        [DataMember]
        public int NumeroSocio { get; set; }

        [DataMember]
        public int ClaveFamiliar { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Paterno { get; set; }

        [DataMember]
        public string Materno { get; set; }

        [DataMember]
        public string Curp { get; set; }

        [DataMember]
        public string TipoUsuario { get; set; }

        [DataMember]
        public string ClaveTipoSanguineo { get; set; }

        [DataMember]
        public string ClaveEstadoCivil { get; set; }

        [DataMember]
        public string Sexo { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public DateTime FechaMovimiento { get; set; }

        [DataMember]
        public string ClaveEmpresaContrato { get; set; }

        [DataMember]
        public string ClavePlantaContrato { get; set; }

        [DataMember]
        public string RFCSocio { get; set; }

        [DataMember]
        public string Calle { get; set; }

        [DataMember]
        public string NumeroExterior { get; set; }

        [DataMember]
        public string CodigoPostal { get; set; }

        [DataMember]
        public int ClaveColonia { get; set; }

        [DataMember]
        public string Colonia { get; set; }

        [DataMember]
        public int ClavePais { get; set; }

        [DataMember]
        public string Pais { get; set; }

        [DataMember]
        public int ClaveEstado { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public int ClaveCiudad { get; set; }

        [DataMember]
        public string Ciudad { get; set; }

        [DataMember]
        public int TelefonoCasa { get; set; }

        [DataMember]
        public int TelefonoOficina { get; set; }

        [DataMember]
        public int Extension { get; set; }

        [DataMember]
        public int Fax { get; set; }

        [DataMember]
        public string CorreoElectronico { get; set; }

        [DataMember]
        public int NumeroAfiliacionIMSS { get; set; }

        [DataMember]
        public string ApellidoCasadaEsposa { get; set; }

        [DataMember]
        public string SocioId { get; set; }

        [DataMember]
        public int NumeroPoliza { get; set; }

        [DataMember]
        public int NumeroEndoso { get; set; }

        [DataMember]
        public string TipoTrabajador { get; set; }
    }

    [DataContract]
    public class DatosBaja
    {
        [DataMember]
        public int NumeroSocio { get; set; }

        [DataMember]
        public int ClaveFamiliar { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Paterno { get; set; }

        [DataMember]
        public string Materno { get; set; }

        [DataMember]
        public string Curp { get; set; }

        [DataMember]
        public string TipoUsuario { get; set; }

        [DataMember]
        public string ClaveTipoSanguineo { get; set; }

        [DataMember]
        public string ClaveEstadoCivil { get; set; }

        [DataMember]
        public string Sexo { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public DateTime FechaMovimiento { get; set; }

        [DataMember]
        public DateTime FechaBajaContrato { get; set; }

        [DataMember]
        public string ClaveEmpresaContrato { get; set; }

        [DataMember]
        public string ClavePlantaContrato { get; set; }

        [DataMember]
        public string RFCSocio { get; set; }

        [DataMember]
        public string Calle { get; set; }

        [DataMember]
        public string NumeroExterior { get; set; }

        [DataMember]
        public string CodigoPostal { get; set; }

        [DataMember]
        public string Colonia { get; set; }

        [DataMember]
        public string Pais { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string Ciudad { get; set; }

        [DataMember]
        public int TelefonoCasa { get; set; }

        [DataMember]
        public int TelefonoOficina { get; set; }

        [DataMember]
        public int Extension { get; set; }

        [DataMember]
        public int Fax { get; set; }

        [DataMember]
        public string CorreoElectronico { get; set; }

        [DataMember]
        public int NumeroAfiliacionIMSS { get; set; }

        [DataMember]
        public string ApellidoCasadaEsposa { get; set; }

        [DataMember]
        public string SocioId { get; set; }

        [DataMember]
        public int NumeroPoliza { get; set; }

        [DataMember]
        public int NumeroEndoso { get; set; }

        [DataMember]
        public string TipoTrabajador { get; set; }
    }

    [DataContract]
    public class DatosReactivacion
    {
        [DataMember]
        public int NumeroSocio { get; set; }

        [DataMember]
        public int ClaveFamiliar { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Paterno { get; set; }

        [DataMember]
        public string Materno { get; set; }

        [DataMember]
        public string Curp { get; set; }

        [DataMember]
        public string TipoUsuario { get; set; }

        [DataMember]
        public string ClaveTipoSanguineo { get; set; }

        [DataMember]
        public string ClaveEstadoCivil { get; set; }

        [DataMember]
        public string Sexo { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public DateTime FechaMovimiento { get; set; }

        [DataMember]
        public DateTime FechaReactivacion { get; set; }

        [DataMember]
        public string ClaveEmpresaContrato { get; set; }

        [DataMember]
        public string ClavePlantaContrato { get; set; }

        [DataMember]
        public string RFCSocio { get; set; }

        [DataMember]
        public string Calle { get; set; }

        [DataMember]
        public string NumeroExterior { get; set; }

        [DataMember]
        public string CodigoPostal { get; set; }

        [DataMember]
        public int ClaveColonia { get; set; }

        [DataMember]
        public string Colonia { get; set; }

        [DataMember]
        public int ClavePais { get; set; }

        [DataMember]
        public string Pais { get; set; }

        [DataMember]
        public int ClaveEstado { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public int ClaveCiudad { get; set; }

        [DataMember]
        public string Ciudad { get; set; }

        [DataMember]
        public int TelefonoCasa { get; set; }

        [DataMember]
        public int TelefonoOficina { get; set; }

        [DataMember]
        public int Extension { get; set; }

        [DataMember]
        public int Fax { get; set; }

        [DataMember]
        public string CorreoElectronico { get; set; }

        [DataMember]
        public int NumeroAfiliacionIMSS { get; set; }

        [DataMember]
        public string ApellidoCasadaEsposa { get; set; }

        [DataMember]
        public string SocioId { get; set; }

        [DataMember]
        public int NumeroPoliza { get; set; }

        [DataMember]
        public int NumeroEndoso { get; set; }

        [DataMember]
        public string TipoTrabajador { get; set; }
    }


    [DataContract]
    public class Respuesta
    {
        [DataMember]
        public Guid TransaccionId { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public string Error { get; set; }
    }

    [DataContract]
    public class Token
    {
        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}