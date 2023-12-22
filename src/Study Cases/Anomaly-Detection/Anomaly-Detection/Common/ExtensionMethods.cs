using System;
using System.Linq;

namespace anomaly_detection.Common
{
    public static class ExtensionMethods
    {
        public static string[] ToPropertyList<T>(this Type objType, string labelName) => objType.GetProperties().Where(a => a.Name != labelName).Select(a => a.Name).ToArray();
    }
}