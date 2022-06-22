using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGW_Mechanics___ConfigParser.Models;

namespace TGW_Mechanics___ConfigParser.Extensions
{
    public static class ModelExtension
    {
        public static string[] ToStringProperties(this object @this, string valueIfEmpty)
        {
            List<string> props = new List<string>();
            foreach (var prop in @this.GetType().GetProperties())
            {
                var value = prop.GetValue(@this);
                if (value != null)
                {
                    props.Add(prop.Name + ": " + value);
                }
                else
                {
                    props.Add(prop.Name + ": " + valueIfEmpty);
                }
            }
            return props.ToArray();
        }

        public static IBaseModel AssignPropertyValue<T>(this IBaseModel @this, string propertyName, string propertyValue)
        {
            if (!string.IsNullOrWhiteSpace(propertyValue))
            {
                var prop = @this.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    T value = (T)Convert.ChangeType(propertyValue, typeof(T));
                    prop.SetValue(@this, value);
                }
            }
            return @this;
        }
    }
}
