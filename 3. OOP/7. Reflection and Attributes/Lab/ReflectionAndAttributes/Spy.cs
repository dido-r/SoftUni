using System;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            sb.AppendLine($"Class under investigation: {type.FullName}");

            foreach (var item in fields)
            {
                var instance = (Hacker)Activator.CreateInstance(type);
                FieldInfo fieldInfo = type.GetField(item, (BindingFlags)60);
                sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
