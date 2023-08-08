using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties().Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any()).ToArray();

            foreach (var property in properties)
            {
                var attr = property.GetCustomAttribute(typeof(MyValidationAttribute)) as MyValidationAttribute;
                var value = property.GetValue(obj);

                if (!attr.IsValid(value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
