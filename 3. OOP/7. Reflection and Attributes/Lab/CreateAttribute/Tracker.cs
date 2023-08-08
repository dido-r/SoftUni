using System;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            foreach (var method in type.GetMethods((BindingFlags)60))
            {
                var attrs = method.GetCustomAttributes(false);

                foreach (var item in attrs)
                {
                    AuthorAttribute author = item as AuthorAttribute;

                    if (author != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {author.Name}");
                    }
                }
            }
        }
    }
}
