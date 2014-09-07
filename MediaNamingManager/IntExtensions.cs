using System.Runtime.Remoting.Messaging;

namespace MediaNamingManager
{
    public static class IntExtensions
    {
        public static string ToFriendlyName(this int number)
        {
            var str = number.ToString();
            if (str.Length == 1) 
            {
                // Should put in a zero in front to make it sortable in windows.
                return string.Format("0{0}", str);
            }
            return str;
        }
    }
}