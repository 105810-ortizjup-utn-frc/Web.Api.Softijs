using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.Comun.Extensiones
{
    public static class Extensiones
    {
        public static string? FirstLetterToUpperCase(this string? value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return null;

            return $"{ char.ToUpper(value[0])}{value.Substring(1,value.Length-1).ToLower()}";
        }


    }
}
