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

        private enum Setting { SlowMoEffect, GrindSpinAssist, TransitionAssist, TransitionSpinAssists, FirstPersonCamera }
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
            Vector4 customTextColor = new Vector4(0.7843137254901961f, 0.7058823529411765f, 0.9019607843137255f, 1f);

            GUI.backgroundColor = customBackgroundColor;
            GUI.Box(new Rect(7f, 22f, 157f, 370f), "");
            if (GUI.Button(new Rect(10f, this.CalcButtonHeight(0), 150f, 40f), "SlowMo Effect"))
            {
                setting = Setting.SlowMoEffect;
            }
            if (GUI.Button(new Rect(10f, this.CalcButtonHeight(1), 150f, 40f), "First Person Camera"))
            {
                setting = Setting.FirstPersonCamera;
            }
            if (GUI.Button(new Rect(10f, this.CalcButtonHeight(2), 150f, 40f), "Grind Spin Assist"))
            {
                setting = Setting.GrindSpinAssist;
            }
            if (GUI.Button(new Rect(10f, this.CalcButtonHeight(3), 150f, 40f), "Transition Spin Assist"))
            {
                setting = Setting.TransitionSpinAssists;
            }
            if (GUI.Button(new Rect(10f, this.CalcButtonHeight(4), 150f, 40f), "Transition Assist"))
            {
                setting = Setting.TransitionAssist;
            }
            GUI.Box(new Rect(168f, 22f, 424f, 370f), "");
            switch(setting)
            {
                case Setting.SlowMoEffect:
                    GUI.Label(new Rect(xOffset, CalcFieldHeight(0), 200f, 20f), "Slow Motion Effect");
                    slowMoInput = GUI.TextField(new Rect(xOffset, CalcFieldHeight(1), 120f, 20f), slowMoInput);

                    parsedKey = GetKeyCodeFromString(slowMoInput);

                    if (parsedKey == null)
                    {
                        return;
                    }

                    config.SlowMo = parsedKey.Value;
                    break;
                case Setting.FirstPersonCamera:
                    GUI.Label(new Rect(xOffset, CalcFieldHeight(0), 200f, 20f), "First Person Hotkey");
                    firstPersonInput = GUI.TextField(new Rect(xOffset, CalcFieldHeight(1), 120f, 20f), firstPersonInput);

                    parsedKey = GetKeyCodeFromString(firstPersonInput);

                    if (parsedKey == null)
                    {
                        return;
                    }

                    config.FirstPerson = parsedKey.Value;
                    break;
                default:
                    GUI.TextArea(new Rect(xOffset, CalcFieldHeight(0), 200f, 20f), "Fuck you!");
                    break;
            }

            if (GUI.Button(new Rect(xOffset, CalcFieldHeight(2), 120f, 20f), "Save"))
            {
                config.Save(configFilePath);
            }

            GUILayout.EndVertical();
        }

        private float CalcButtonHeight(int index)
        {
            return (float)(27 + 45 * index);
        }

        private float CalcFieldHeight(int index)
        {
            return this.yOffset + (float)(25 * index);
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
