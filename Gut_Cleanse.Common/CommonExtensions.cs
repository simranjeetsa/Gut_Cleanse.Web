using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Common
{
    public static class CommonExtensions
    {
        public static TDestination AutoMap<TDestination>(this object entitysource) where TDestination : new()
        {
            TDestination destination = new TDestination();

            // If source null then return TDestination as null using default
            if (entitysource == null)
                return default(TDestination);

            // Getting the Types of the objects
            Type typeDestination = destination.GetType();
            Type typeSource = entitysource.GetType();

            PropertyInfo[] sourceProperties = typeSource.GetProperties();
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                if (!sourceProperty.CanRead)
                    continue;

                PropertyInfo targetProperty = typeDestination.GetProperty(sourceProperty.Name);
                if (targetProperty == null)
                    continue;

                if (!targetProperty.CanWrite)
                    continue;

                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                    continue;

                if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                    continue;

                if (!targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    continue;

                // Passed all tests, lets set the value
                targetProperty.SetValue(destination, sourceProperty.GetValue(entitysource, null), null);
            }

            return destination;
        }
    }
}
