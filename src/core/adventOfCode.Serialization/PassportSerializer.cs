using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace adventOfCode.Serialization
{
    public class PassportSerializer
    {
        public IEnumerable<T> Deserialize<T>(string input) where T : class, new()
        {
            var inputList = input.Split(separator: $"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries).ToList();

            var items = new List<T>();
            foreach(string item in inputList)
                items.Add(CreateItem<T>(item));

            return items;
        }

        private T CreateItem<T>(string input) where T : class, new()
        {
            input = FormatAndClean(input);

            var obj = new T();
            foreach (string field in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                SetProperty(obj, field.Split(':')[0], field.Split(':')[1]);

            return obj;
        }

        private void SetProperty(object obj, string name, string value)
        {
            PropertyInfo prop = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if(null != prop && prop.CanWrite)
            {
                Type type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                prop.SetValue(obj, Convert.ChangeType(value, type), null);
            }
        }

        private string FormatAndClean(string input)
        {
            return input.Replace(Environment.NewLine, " ");
        }
    }
}
