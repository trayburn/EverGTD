using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CF64BitConverterLib
{
    /// <summary>
    /// A supoort class: the purpose is to integrate System.BitConverter 
    /// methods not presents in .NET Compact Framework.
    /// http://nettopologysuite.googlecode.com/svn/tags/v2.0/2008-06-21%20Drop/NetTopologySuite/Utilities/BitConverter.cs
    /// </summary>
    public class CF64BitConverter
    {
        public static Int64 DoubleToInt64Bits(Double x)
        {
#if UNSAFE
            unsafe
            {
                return *(Int64*)&x;
            }
#else
            Byte[] bytes = System.BitConverter.GetBytes(x);
            Int64 value = System.BitConverter.ToInt64(bytes, 0);
            return value;
#endif
        }

        public static Double Int64BitsToDouble(Int64 x)
        {
#if UNSAFE
            unsafe
            {
                return *(Double*)&x;
            }
#else
            Byte[] bytes = System.BitConverter.GetBytes(x);
            Double value = System.BitConverter.ToDouble(bytes, 0);
            return value;
#endif
        }
    }
}
