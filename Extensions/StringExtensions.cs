using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGW_Mechanics___ConfigParser.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Only for test purpose.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        #region String Extensions
        public static string ToJointString(this string[] @this)
        {
            return string.Join("\n", @this);
        }
        #endregion
    }
}
