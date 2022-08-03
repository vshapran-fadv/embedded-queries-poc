using System;
using System.IO;

namespace DataLayer
{
    internal static class QueryLoader
    {
        public static string Get(string name)
        {
            var thisType = typeof(QueryLoader);

            using var resource = thisType.Assembly
                .GetManifestResourceStream(thisType, $"SQL.{name}.sql");

            if (resource is null)
            {
                throw new ArgumentException($"Cannot find query with name \"{name}\"");
            }

            using var reader = new StreamReader(resource);
            return reader.ReadToEnd();
        }
    }
}