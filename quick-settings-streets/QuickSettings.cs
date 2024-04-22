using MelonLoader;
using System.Reflection;
using UnityEngine;

namespace quick_settings_streets
{
    public class QuickSettings : MelonMod
    {
        private bool menuOpen = false;
        private Menu menu;

        private Config config;
        private readonly string configFilePath = Path.Combine(Application.persistentDataPath, "quick_settings.json");
        
        public static bool isFirstPersonCameraActive = false;
        public static bool isSloMoEffectActive = true;

        // Get the assembly where the MelonInfo attribute is defined
        private readonly Assembly melonAssembly = Assembly.GetExecutingAssembly();

        public override void OnInitializeMelon()
        {
            // Get the MelonInfo attribute
            var melonInfoAttribute = (MelonInfoAttribute)melonAssembly.GetCustomAttribute(typeof(MelonInfoAttribute));

            if (melonInfoAttribute == null)
            {
                LoggerInstance.Error("No MelonInfo attribute found!");
                return;
            }

            string version = melonInfoAttribute.Version;
            string name = melonInfoAttribute.Name;

            LoggerInstance.Msg($"{melonInfoAttribute.Name} v{melonInfoAttribute.Version} by {melonInfoAttribute.Author} - Initializing...");

            LoadConfig();
            menu = new Menu();
        }

        public override void OnUpdate()
        {
            if(Input.GetKeyUp(KeyCode.J))
            {
                menuOpen =! menuOpen;

                if (!menuOpen)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    // When the menu gets closed we do reload the config in order to get any updated value
                    LoadConfig();

                    return;
                }

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (config == null)
            {
                return;
            }

            if(Input.GetKeyUp(config.SlowMo)) {
                GameObject sloMoEffect = GameObject.Find("BMXS Game World PIPE Sytle/Player Components/TimeInterpolator/SloMoEffect");

                if (sloMoEffect == null)
                {
                    return;
                }

                isSloMoEffectActive =! isSloMoEffectActive;
                sloMoEffect.SetActive(isSloMoEffectActive);

                Logger.Log(sloMoEffect.active.ToString(), Logger.LogLevel.Debug);
            }

            if (Input.GetKeyDown(config.FirstPerson))
            {
                GameObject fpCamera = GameObject.Find("BMXS Game World PIPE Sytle/Player Components/Character Manager/Character Controller/FirstPerson Camera Root/FirstPerson Camera");

                if (fpCamera == null)
                {
                    return;
                }

                isFirstPersonCameraActive =! isFirstPersonCameraActive;
                fpCamera.SetActive(isFirstPersonCameraActive);

                Logger.Log(fpCamera.active.ToString(), Logger.LogLevel.Debug);
            }

        }

        public override void OnGUI()
        {
            // Display menu GUI if open
            if (!menuOpen)
            {
                return;
            }

            menu.DrawMenuGUI();
        }

        private void LoadConfig()
        {
            config = Config.Load(configFilePath);
        }
    }
}
