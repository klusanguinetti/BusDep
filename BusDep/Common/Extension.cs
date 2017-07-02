using System;
using System.Web.Script.Serialization;

namespace BusDep.Common
{
    public static class Extension
    {
        
        #region atributos
        static JavaScriptSerializer json => new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
        #endregion

        #region metodos
        public static T DeserializarToJson<T>(this string jsonString)
        {
            try
            {
                return json.Deserialize<T>(jsonString);
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public static string SerializarToJson<T>(this T obj)
        {
            try
            {
                return json.Serialize(obj);
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        public static decimal NextDecimal(this Random rnd, decimal from, decimal to)
        {
            byte fromScale = new System.Data.SqlTypes.SqlDecimal(from).Scale;
            byte toScale = new System.Data.SqlTypes.SqlDecimal(to).Scale;

            byte scale = (byte)(fromScale + toScale);
            if (scale > 28)
                scale = 28;

            decimal r = new decimal(rnd.Next(), rnd.Next(), rnd.Next(), false, scale);
            if (Math.Sign(from) == Math.Sign(to) || from == 0 || to == 0)
                return decimal.Remainder(r, to - from) + from;

            bool getFromNegativeRange = (double)from + rnd.NextDouble() * ((double)to - (double)from) < 0;
            return getFromNegativeRange ? decimal.Remainder(r, -from) + from : decimal.Remainder(r, to);
        }
    }
}