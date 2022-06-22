using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGW_Mechanics___ConfigParser.Models;

namespace TGW_Mechanics___ConfigParser.Extensions
{
    public static class ViweModelBuliderExtension
    {
        #region Extensions
        public static IViewModel AssignValueToProperty(this IViewModel @this, string propertyName, string propertyValue)
        {
            var prop = @this.GetType().GetProperty(propertyName);
            if(prop != null)
            {
                prop.SetValue(@this, propertyValue);
            }
            return @this;
        }

        public static IViewModel AssignValuesToObject(this IViewModel @this, List<KeyValuePair<string, string>> props)
        {
            props.ForEach(prop =>
            {
                @this.AssignValueToProperty(prop.Key, prop.Value);
            });
            return @this;
        }

        public static IViewModel OverrideFrom(this IViewModel target, IViewModel source)
        {
            var props = source.GetType().GetProperties().ToList();
            props.ForEach(prop =>
            {
                if(prop != null)
                {
                    var value = prop.GetValue(source, null);
                    if(value != null)
                    {
                        target.AssignValueToProperty(prop.Name, value.ToString());
                    }
                }
            });
            return target;
        }
        
        #endregion
    }
}
