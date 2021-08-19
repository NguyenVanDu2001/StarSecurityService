using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace StarSecurityService.Web.Helpers
{
    public static class GetControllerHelper
    {
        public static List<string> GetThumb(string Thumbs)
        {
            List<string> lst = new List<string>();
            string[] subs = Thumbs.Split(' ');
            if (subs.Length > 0)
            {
                foreach (var item in subs)
                {
                    if (!String.IsNullOrWhiteSpace(item))
                    {
                        lst.Add(item);
                    }
                }
            }
            return lst;
        }

        public static List<Type> GetController(string namespaces)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = asm.GetTypes()
                .Where(t => typeof(Controller).IsAssignableFrom(t) && t.Namespace.Contains(namespaces))
                .OrderBy(x => x.Name);
            return types.ToList();
        }
        public static List<string> GetActions(Type controller)
        {
            List<string> actions = new List<string>();
            actions = controller
                .GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Where(m =>
                    !m.GetCustomAttributes(typeof(CompilerGeneratedAttribute), true).Any() &&
                    !m.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any() &&
                    !m.IsDefined(typeof(NonActionAttribute)) &&
                    m.ReflectedType.IsPublic)
                .OrderBy(x => x.Name).Select(x => x.Name).ToList();
            return actions;
        }
    }
}