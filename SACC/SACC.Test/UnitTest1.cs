using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SACC.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WS_Alta_Test()
        {
            ServiceReference1.DatosAlta datosAlta = new ServiceReference1.DatosAlta {
                NumeroSocio          = 350238,
                ClaveFamiliar        = 0,
                Nombre               = "DANIELA SARAY",
                Paterno              = "MARTINEZ",
                Materno              = "FERNANDEZ",
                Curp                 = "",
                TipoUsuario          = "TI", 
                ClaveTipoSanguineo   = "",
                ClaveEstadoCivil     = "C",
                Sexo                 = "0",
                FechaNacimiento      = DateTime.Parse("2017-01-20"),
                FechaAltaContrato    = DateTime.Parse("2017-01-06"),
                FechaMovimiento      = DateTime.Parse("2018-01-06"),
                FechaBajaContrato    = DateTime.Parse("2018-01-06"),
                ClaveEmpresaContrato = "GSS",
                ClavePlantaContrato  = "001",
                RFCSocio             = "",
                Calle                = "LUIS G COINDREAU",
                NumeroExterior       = "540",
                CodigoPostal         = "66417",
                Colonia              = "LA NOGALERA",
                Pais                 = "MEXICO",
                Estado               = "NUEVO LEON",
                Ciudad               = "SAN NICOLAS DE LOS GARZA",
                TelefonoCasa         = 0,
                TelefonoOficina      = 0,
                Extension            = 0,
                Fax                  = 0,
                CorreoElectronico    = "",
                NumeroAfiliacionIMSS = 0,
                ApellidoCasadaEsposa = "",
                SocioId              = "883513",
                NumeroPoliza         = 376,
                NumeroEndoso         = 0,
                TipoTrabajador       = "E",
            };

            ServiceReference1.Token token = new ServiceReference1.Token {
                Usuario  = "GENERALSALUD",
                Password = "TE$T1",
            };

            ServiceReference1.VigenciaClient vigencia = new ServiceReference1.VigenciaClient();
            vigencia.AltaAsociado(datosAlta, token);
        }


        [TestMethod]
        public void WS_Baja_Test()
        {
        }


        [TestMethod]
        public void WS_Cambio_Test()
        {
        }
    }
}