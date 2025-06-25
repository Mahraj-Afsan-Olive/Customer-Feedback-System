using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public static class UniversalMapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
            where TDestination : new()
        {
            if (source == null) return default;

            TDestination dest = new TDestination();
            var sourceProps = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var destProps = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var sProp in sourceProps)
            {
                var dProp = destProps.FirstOrDefault(p => p.Name == sProp.Name && p.PropertyType == sProp.PropertyType);
                if (dProp != null && dProp.CanWrite)
                {
                    dProp.SetValue(dest, sProp.GetValue(source));
                }
            }

            return dest;
        }

        public static List<TDestination> MapList<TSource, TDestination>(List<TSource> sourceList)
            where TDestination : new()
        {
            return sourceList.Select(Map<TSource, TDestination>).ToList();
        }
    }
}
