namespace PG.Utilities
{
    public class StringHelper
    {
        public static string JsonForDeserialize(string rawString) 
        {
            rawString = rawString.Replace("\"{", "{");
            rawString = rawString.Replace("}\"", "}");
            return rawString.Replace("\\", "");
        }
    }
}
