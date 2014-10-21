using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectBlack.Utilities
{
    public static class JsonUtilities {
        public static T LoadJson<T>(string filename) {
            var str = System.IO.File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static void WriteJson(object obj, string filename) {
            var str = JsonConvert.SerializeObject(obj, Formatting.Indented);
            System.IO.File.WriteAllText(filename, str);
        }
    }
}
