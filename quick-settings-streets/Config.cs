using Newtonsoft.Json;
using UnityEngine;

namespace quick_settings_streets
{
    public class Config
    {

        public KeyCode SlowMo { get; set; }
        public KeyCode FirstPerson { get; set; }

        public void Save(string filePath)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, json);

            Logger.Log("Config saved successfully.", Logger.LogLevel.Info);
        }

        public static Config Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Logger.Log("No config found, creating one...", Logger.LogLevel.Warning);

                return new Config();
            }

            string json = File.ReadAllText(filePath);

            Logger.Log("Config loaded successfully.", Logger.LogLevel.Info);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
