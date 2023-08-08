using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            FieldInfo[] info = type.GetFields((BindingFlags)60);

            foreach (var item in info)
            {
                if (item.IsPublic)
                {
                    sb.AppendLine($"{item.Name} must be private!");
                }
            }

            MethodInfo[] publicMethod = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] nonPublicMethod = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var item in nonPublicMethod.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }
            foreach (var item in publicMethod.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }
    }
}
