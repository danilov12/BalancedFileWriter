using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BalancedLog
{
    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach(T item in collection)
            {
                action(item);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> collection, Func<T, Task> action)
        {
            foreach (T item in collection)
            {
                await action(item);
            }
        }

        public static string GetFilePath(this string file)
        {
            return $"{FileSystemInfo.rootDirectoryPath}/{file}";
        }
    }
}
