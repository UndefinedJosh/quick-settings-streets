using UnityEngine;

namespace quick_settings_streets
{
    public class Menu
    {
        private Config config;
        private readonly string configFilePath = Path.Combine(Application.persistentDataPath, "quick_settings.json");

        private float xPos = (float)(Screen.width / 2 - 300);
        private float yPos = (float)(Screen.height / 2 - 200);
        private float xOffset = 178f;
        private float yOffset = 32f;

        private enum Setting { SlowMoEffect, GrindSpinAssist, TransitionAssist, TransitionSpinAssists, FirstPersonCamera, AirTricks }
        private Setting setting;
        private KeyCode? parsedKey;

        private string slowMoInput = "";
        private string firstPersonInput = "";

        public Menu()
        {
            config = Config.Load(configFilePath);

            if(config == null)
            {
                return;
            }

            slowMoInput = GetStringFromKeyCode(config.SlowMo);
            firstPersonInput = GetStringFromKeyCode(config.FirstPerson);

            setting = Setting.AirTricks;
        }

        // Menu GUI layout
        public void DrawMenuGUI()
        {
            GUI.backgroundColor = new Vector4(0.12f, 0.12f, 0.12f, 1f);
            GUI.color = Color.white;

            // Create the custom window box with a black header
            Rect windowRect = new Rect(xPos, yPos, 600f, 400f);
            windowRect = GUI.Window(0, windowRect, new Action<int>(this.DoCustomWindow), "Karxem's Quick Settings");
        }

        void DoCustomWindow(int windowID)
        {
            GUILayout.BeginVertical();

            Vector4 customBackgroundColor = new Vector4(0f, 0.5882352941176471f, 0.43137254901960786f, 1f);

            GUI.backgroundColor = customBackgroundColor;
            GUI.Box(new Rect(7f, 22f, 157f, 370f), "");
            if (GUI.Button(new Rect(10f, this.CalculateOptionOffset(0), 150f, 40f), "Air Tricks"))
            {
                setting = Setting.AirTricks;
            }
            if (GUI.Button(new Rect(10f, this.CalculateOptionOffset(1), 150f, 40f), "SlowMo Effect"))
            {
                setting = Setting.SlowMoEffect;
            }
            if (GUI.Button(new Rect(10f, this.CalculateOptionOffset(2), 150f, 40f), "First Person Camera"))
            {
                setting = Setting.FirstPersonCamera;
            }
            GUI.Box(new Rect(168f, 22f, 424f, 370f), "");
            switch(setting)
            {
                case Setting.SlowMoEffect:
                    GUI.Label(new Rect(xOffset, CalculateElementOffset(0), 200f, 20f), "Slow Motion Effect");
                    slowMoInput = GUI.TextField(new Rect(xOffset, CalculateElementOffset(1), 120f, 20f), slowMoInput);

                    parsedKey = GetKeyCodeFromString(slowMoInput);

                    if (parsedKey == null)
                    {
                        return;
                    }

                    config.SlowMo = parsedKey.Value;

                    if (GUI.Button(new Rect(xOffset, 350f, 120f, 20f), "Save"))
                    {
                        config.Save(configFilePath);
                    }
                    break;
                case Setting.FirstPersonCamera:
                    GUI.Label(new Rect(xOffset, CalculateElementOffset(0), 200f, 20f), "First Person Hotkey");
                    firstPersonInput = GUI.TextField(new Rect(xOffset, CalculateElementOffset(1), 120f, 20f), firstPersonInput);

                    parsedKey = GetKeyCodeFromString(firstPersonInput);

                    if (parsedKey == null)
                    {
                        return;
                    }

                    config.FirstPerson = parsedKey.Value;

                    if (GUI.Button(new Rect(xOffset, 350f, 120f, 20f), "Save"))
                    {
                        config.Save(configFilePath);
                    }
                    break;
                case Setting.AirTricks:
                    // 1th column
                    config.Barspin = GUI.Toggle(new Rect(xOffset, CalculateElementOffset(0), 100f, 20f), config.Barspin, "Barspin");
                    config.Whip = GUI.Toggle(new Rect(xOffset, CalculateElementOffset(1), 100f, 20f), config.Whip, "Tailwhip");
                    config.Whopper = GUI.Toggle(new Rect(xOffset, CalculateElementOffset(2), 100f, 20f), config.Whopper, "Whopper");
                    config.Toboggan = GUI.Toggle(new Rect(xOffset, CalculateElementOffset(3), 100f, 20f), config.Toboggan, "Toboggan");
                    config.Seat_Grab = GUI.Toggle(new Rect(xOffset, CalculateElementOffset(4), 100f, 20f), config.Seat_Grab, "Seat Grab");
                    config.Tire_Grab = GUI.Toggle(new Rect(xOffset, CalculateElementOffset(5), 100f, 20f), config.Tire_Grab, "Tire Grab");
                    config.Tuck_Up = GUI.Toggle(new Rect(xOffset, CalculateElementOffset(6), 100f, 20f), config.Tuck_Up, "Tuck Up");

                    // 2th column
                    config.Crankflip = GUI.Toggle(new Rect(xOffset + 100f, CalculateElementOffset(0), 100f, 20f), config.Crankflip, "Crankflip");
                    config.Nac = GUI.Toggle(new Rect(xOffset + 100f, CalculateElementOffset(1), 100f, 20f), config.Nac, "Nac");
                    config.No_Foot_Can = GUI.Toggle(new Rect(xOffset + 100f, CalculateElementOffset(2), 100f, 20f), config.No_Foot_Can, "No Foot Can");
                    config.Can = GUI.Toggle(new Rect(xOffset + 100f, CalculateElementOffset(3), 100f, 20f), config.Can, "Can");
                    config.Candy_Bar = GUI.Toggle(new Rect(xOffset + 100f, CalculateElementOffset(4), 100f, 20f), config.Candy_Bar, "Candy Bar");
                    config.Grizz_Air = GUI.Toggle(new Rect(xOffset + 100f, CalculateElementOffset(5), 100f, 20f), config.Grizz_Air, "Grizz Air");

                    // 3th column
                    config.Euro = GUI.Toggle(new Rect(xOffset + 200f, CalculateElementOffset(0), 100f, 20f), config.Euro, "Euro");
                    config.Lookback = GUI.Toggle(new Rect(xOffset + 200f, CalculateElementOffset(1), 100f, 20f), config.Lookback, "Lookback");
                    config.Switch_Hander = GUI.Toggle(new Rect(xOffset + 200f, CalculateElementOffset(2), 100f, 20f), config.Switch_Hander, "Switch Hander");
                    config.Table = GUI.Toggle(new Rect(xOffset + 200f, CalculateElementOffset(3), 100f, 20f), config.Table, "Table");
                    config.Invert = GUI.Toggle(new Rect(xOffset + 200f, CalculateElementOffset(4), 100f, 20f), config.Invert, "Invert");
                    config.Turndown = GUI.Toggle(new Rect(xOffset + 200f, CalculateElementOffset(5), 100f, 20f), config.Turndown, "Turndown");
                    
                    // 4th column
                    config.One_Footer = GUI.Toggle(new Rect(xOffset + 300f, CalculateElementOffset(0), 100f, 20f), config.One_Footer, "One Footer");
                    config.One_Hander = GUI.Toggle(new Rect(xOffset + 300f, CalculateElementOffset(1), 100f, 20f), config.One_Hander, "One Hander");
                    config.Suicide = GUI.Toggle(new Rect(xOffset + 300f, CalculateElementOffset(2), 100f, 20f), config.Suicide, "Suicide");
                    config.Tuck_No_Hander = GUI.Toggle(new Rect(xOffset + 300f, CalculateElementOffset(3), 100f, 20f), config.Tuck_No_Hander, "Tuck No Hander");
                    config.Backflip = GUI.Toggle(new Rect(xOffset + 300f, CalculateElementOffset(4), 100f, 20f), config.Backflip, "Backflip");
                    config.Frontflip = GUI.Toggle(new Rect(xOffset + 300f, CalculateElementOffset(5), 100f, 20f), config.Frontflip, "Frontflip");

                    if (GUI.Button(new Rect(xOffset, 350f, 120f, 20f), "Save"))
                    {
                        config.Save(configFilePath);
                        TrickManager.SetAirTrickState(config);
                    }
                    break;
                default:
                    GUI.TextArea(new Rect(xOffset, CalculateElementOffset(0), 200f, 20f), "Nothing to display here!");
                    break;
            }

            GUILayout.EndVertical();
        }

        private float CalculateOptionOffset(int index)
        {
            return 27 + 45 * index;
        }

        private float CalculateElementOffset(int index)
        {
            return yOffset + (25 * index);
        }

        private KeyCode? GetKeyCodeFromString(string keyString)
        {
            KeyCode parsedKeyCode;

            // Try parsing the string to a KeyCode
            if (!Enum.TryParse(keyString, out parsedKeyCode))
            {
                return null;
            }

            return parsedKeyCode;
        }

        private string GetStringFromKeyCode(KeyCode keyCode)
        {
            // Convert KeyCode to string
            string keyString = keyCode.ToString();

            return keyString;
        }
    }
}
