using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EvernoteSharp.Util
{
    internal static class ParamCheck
    {
        /// <summary>
        /// throw exception if param is null
        /// </summary>
        public static void NotNull(string paramName, object param)
        {
            if (param == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// throw exception if you feel like it
        /// </summary>
        public static void NullNorEmpty(string paramName, string param)
        {
            if (string.IsNullOrEmpty(param))
                throw new ArgumentNullException(paramName);
        }

    }
}
