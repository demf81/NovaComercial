using System;


namespace SACC.LogicaNegocio
{
    public class Common
    {
        public static Boolean? ConvertEstatusIdToBoolean(Int16 pEstatusId)
        {
            Boolean? pBaja;

            switch (pEstatusId)
            {
                case 0:
                    pBaja = false;
                    break;
                case 1:
                    pBaja = true;
                    break;
                default:
                    pBaja = null;
                    break;
            }

            return pBaja;
        }
    }
}