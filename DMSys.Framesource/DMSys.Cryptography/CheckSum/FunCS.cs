using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Cryptography.CheckSum
{
    public static class FunCS
    {
        /// <summary>
        /// Деление с модул
        /// </summary>
        public static Int32 Mod(Int32 aIntValue, Int32 aModValue)
        {
            Int32 iMod = ((Int32)(aIntValue / aModValue));

            return (aIntValue - (iMod * aModValue));
        }
    }
}
