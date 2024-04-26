using Newtonsoft.Json;
using UnityEngine;

namespace quick_settings_streets
{
    public class Config
    {

        public KeyCode SlowMo { get; set; }
        public KeyCode FirstPerson { get; set; }
        
        // Air Tricks
        public bool Frontflip { get; set; }
        public bool Backflip { get; set; }
        public bool Barspin { get; set; }
        public bool Can {  get; set; }
        public bool Candy_Bar { get; set; }
        public bool Crankflip { get; set; }
        public bool Euro {  get; set; }
        public bool Grizz_Air { get; set; }
        public bool Invert {  get; set; }
        public bool Lookback { get; set; }
        public bool Nac {  get; set; }
        public bool No_Foot_Can { get; set; }
        public bool One_Footer { get; set; }
        public bool One_Hander { get; set; }
        public bool Seat_Grab { get; set; }
        public bool Suicide { get; set; }
        public bool Switch_Hander { get; set; }
        public bool Table { get; set; }
        public bool Tire_Grab { get; set; }
        public bool Toboggan { get; set; }
        public bool Tuck_No_Hander { get; set; }
        public bool Tuck_Up {  get; set; }
        public bool Turndown { get; set; }
        public bool Whip { get; set; }
        public bool Whopper { get; set; }

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
