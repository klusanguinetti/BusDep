using System.Web.Script.Serialization;

namespace BusDep.Common
{
    public static class JsonSerialization
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
    }
}