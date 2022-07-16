using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Blazor2.Data
{
    public class TodoItemService
    {
        private static List<TodoTask> _data = new List<TodoTask>();

        private readonly string _file = "Data\\todo1.json";

        public List<TodoTask> GetData()
        {
            if (File.Exists(_file))
            {
                using var file = File.OpenText(_file);
                var serializer = new JsonSerializer();
                _data = serializer.Deserialize(file, typeof(List<TodoTask>)) as List<TodoTask>;
            }
            return _data;
        }

        public void SaveChanges()
        {
            using var file = File.CreateText(_file);
            var serializer = new JsonSerializer();
            serializer.Serialize(file, _data);
        }
    }
}
