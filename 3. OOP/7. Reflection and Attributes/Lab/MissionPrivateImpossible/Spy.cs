using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            MethodInfo[] publicMethod = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var item in publicMethod)
            {
                sb.AppendLine($"{item.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
