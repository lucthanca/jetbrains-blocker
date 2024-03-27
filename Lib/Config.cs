using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vadu.Lib
{
    public static class Config
    {
        private static readonly string _configPath = "config.json";
        // get json config by path like config.execPath
        public static object? Get(string path)
        {
            // read json file
            var json = readConfigText();
            // parse json
            var config = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (config.TryGetValue(path, out object? value))
            {
                return value;
            }
            return null;
        }

        // set json config by path like config.execPath
        public static void Set(string path, object value)
        {
            // read json file
            var json = readConfigText();
            // parse json
            var config = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            // set value by path
            config[path] = value;
            // serialize json
            json = JsonConvert.SerializeObject(config);
            // need format json when write text
            json = JToken.Parse(json).ToString(Formatting.Indented);
            // write json file
            File.WriteAllText(_configPath, json);
        }

        /// <summary>
        /// Read json file as raw text
        /// </summary>
        /// <returns></returns>
        private static string readConfigText()
        {
            // must check if file exists
            if (!File.Exists(_configPath))
            {
                // create empty json file
                File.WriteAllText(_configPath, "{}");
            }
            // read json file
            return File.ReadAllText(_configPath);
        }
    }
}
