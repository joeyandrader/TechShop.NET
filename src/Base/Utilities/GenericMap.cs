using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BackEndAPI.src.Base.Utilities
{
    public static class GenericMap
    {
        public static TTarget MapTo<TTarget>(this object source, TTarget target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Type typeFromHandle = typeof(TTarget);
            PropertyInfo[] properties = source.GetType().GetProperties();
            PropertyInfo[] properties2 = typeFromHandle.GetProperties();
            PropertyInfo[] array = properties;

            foreach (PropertyInfo sourceProperty in array)
            {
                try
                {
                    if (!(sourceProperty.Name == "Id"))
                    {
                        goto IL_00be;
                    }

                    object value = sourceProperty.GetValue(target);
                    if (value == null || !(value.GetType().Name == "Int32") || (int)value <= 0)
                    {
                        goto IL_00be;
                    }

                    goto end_IL_0053;
                IL_00be:
                    if (!(sourceProperty.Name == "Password"))
                    {
                        PropertyInfo propertyInfo = properties2.FirstOrDefault((PropertyInfo p) => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(target, sourceProperty.GetValue(source));
                        }
                    }
                end_IL_0053:
                    ;
                }
                catch (System.Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return target;
        }

        public static void ChangePropertyValue<TTarget>(this TTarget source, string propertyName, object value)
        {
            if (source != null)
            {
                PropertyInfo property = source.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    property.SetValue(source, value);
                }
            }
        }
    }
}