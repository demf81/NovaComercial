using System;


namespace SACC.LogicaNegocio
{
    public static class Util
    {
        public static Entidades.EntidadResponse Consultar(SqlOpciones Opcion, dynamic oBE)
        {
            try
            {
                Type tipoBD = MapaClases.EntityToData(oBE);
                dynamic oBD = Activator.CreateInstance(tipoBD);

                return oBD.Consultar((short)Opcion, oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Entidades.EntidadResponse Consultar(VigenciaOpciones Opcion, dynamic oBE)
        {
            try
            {
                Type tipoBD = MapaClases.EntityToData(oBE);
                dynamic oBD = Activator.CreateInstance(tipoBD);

                return oBD.Consultar((short)Opcion, oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Entidades.EntidadResponse Insertar(SqlOpciones Opcion, dynamic oBE)
        {
            try
            {
                Entidades.EntidadResponse response = new Entidades.EntidadResponse();

                Type tipoBD = MapaClases.EntityToData(oBE);
                dynamic oBD = Activator.CreateInstance(tipoBD);

                response = oBD.Insertar((short)Opcion, oBE);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Entidades.EntidadResponse Actualizar(SqlOpciones Opcion, dynamic oBE)
        {
            try
            {
                Type tipoBD = MapaClases.EntityToData(oBE);
                dynamic oBD = Activator.CreateInstance(tipoBD);

                return oBD.Actualizar((short)Opcion, oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string horaEnEntero(DateTime fecha)
        {
            string respuesta = string.Empty;
            int hora = 0;

            hora = (fecha.Hour * 3600) + (fecha.Minute * 60) + fecha.Second;

            respuesta = hora.ToString("D8");

            return respuesta;
        }
    }
}