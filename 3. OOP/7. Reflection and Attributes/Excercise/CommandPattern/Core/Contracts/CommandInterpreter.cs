using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] data = args.Split();
            string commandName = data[0] + "Command";
            string[] arg = data.Skip(1).ToArray();
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);
            var instance = Activator.CreateInstance(type) as ICommand;
            return instance.Execute(arg);
        }
    }
}
