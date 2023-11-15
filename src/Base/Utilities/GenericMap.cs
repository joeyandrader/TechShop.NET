using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BackEndAPI.src.Base.Utilities
{
    public static class GenericMap
    {
        public static T MapTo<T>(T current, object updateModel)
        {
            if (current == null)
            {
                throw new ArgumentNullException(nameof(current));
            }
            var type = current.GetType();
            foreach (var property in type.GetProperties())
            {
                try
                {
                    if (!(property.Name == "Id"))
                    {
                        goto pula;
                    }

                    object value = property.GetValue(current);
                    if (value == null || !(value.GetType().Name == "Int32") || (int)value <= 0)
                    {
                        goto pula;
                    }
                    goto end_Pula;
                pula:
                    var updateValue = updateModel.GetType().GetProperty(property.Name)?.GetValue(updateModel, null);
                    if (updateValue != null)
                    {
                        property.SetValue(current, updateValue, null);
                    }
                end_Pula:
                    ;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return current;
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