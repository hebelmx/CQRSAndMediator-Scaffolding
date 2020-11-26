using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }

    //public class MappingProfile<T> : Profile
    //{
    //    public MappingProfile()
    //    {
    //        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

    // // Get a Type object. // Type t = typeof(T); // Instantiate an Assembly class to the assembly
    // housing the Integer type. //Assembly assem = Assembly.GetAssembly(t);
    // ApplyMappingsFromAssembly((typeof(T)).Assembly); }

    // private void ApplyMappingsFromAssembly(Assembly assembly) { var types =
    // assembly.GetExportedTypes() .Where(t => t.GetInterfaces().Any(i => i.IsGenericType &&
    // i.GetGenericTypeDefinition() == typeof(IMapFrom<>))) .ToList();

    //        foreach (var type in types)
    //        {
    //            var instance = Activator.CreateInstance(type);
    //            var methodInfo = type.GetMethod("Mapping");
    //            methodInfo?.Invoke(instance, new object[] { this });
    //        }
    //    }
    //}
}