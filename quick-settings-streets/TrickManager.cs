using Il2Cpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace quick_settings_streets
{
    public class TrickManager
    {
        public static void SetAirTrickState(Config config)
        {
            GameObject airTricks = GameObject.Find("BMXS Game World PIPE Sytle/Player Components/BMX Components (PIPE STYLE) 2/State Machine/Air (1)/Air Trick Ability List/");

            if (config == null || airTricks == null)
            {
                Logger.Log("Tricks could not be initialized!", Logger.LogLevel.Error);
                return;
            }

            airTricks.GetChild("Backflip").SetActive(config.Backflip);
            airTricks.GetChild("Barspin Left").SetActive(config.Barspin);
            airTricks.GetChild("Barspin Right").SetActive(config.Barspin);
            airTricks.GetChild("Can Left").SetActive(config.Can);
            airTricks.GetChild("Can Right").SetActive(config.Can);
            airTricks.GetChild("Candy Bar Left").SetActive(config.Candy_Bar);
            airTricks.GetChild("Candy Bar Right").SetActive(config.Candy_Bar);
            airTricks.GetChild("Crankflip").SetActive(config.Crankflip);
            airTricks.GetChild("Euro").SetActive(config.Euro);
            airTricks.GetChild("Frontflip").SetActive(config.Frontflip);
            airTricks.GetChild("Grizz Air Left").SetActive(config.Grizz_Air);
            airTricks.GetChild("Grizz Air Right").SetActive(config.Grizz_Air);
            airTricks.GetChild("Invert").SetActive(config.Invert);
            airTricks.GetChild("Lookback").SetActive(config.Lookback);
            airTricks.GetChild("Nac Left").SetActive(config.Nac);
            airTricks.GetChild("Nac Right").SetActive(config.Nac);
            airTricks.GetChild("No Foot Can Left").SetActive(config.No_Foot_Can);
            airTricks.GetChild("No Foot Can Right").SetActive(config.No_Foot_Can);
            airTricks.GetChild("One Footer Left").SetActive(config.One_Footer);
            airTricks.GetChild("One Footer Right").SetActive(config.One_Footer);
            airTricks.GetChild("One Hander Left").SetActive(config.One_Hander);
            airTricks.GetChild("One Hander Right").SetActive(config.One_Hander);
            airTricks.GetChild("Seat Grab Right").SetActive(config.Seat_Grab);
            // airTricks.GetChild("Seat Grab Left").SetActive(config.Seat_Grab);
            airTricks.GetChild("Suicide").SetActive(config.Suicide);
            airTricks.GetChild("Switch Hander").SetActive(config.Switch_Hander);
            airTricks.GetChild("Table").SetActive(config.Table);
            airTricks.GetChild("Tire Grab Left").SetActive(config.Tire_Grab);
            airTricks.GetChild("Tire Grab Right").SetActive(config.Tire_Grab);
            airTricks.GetChild("Toboggan Left").SetActive(config.Toboggan);
            airTricks.GetChild("Toboggan Right").SetActive(config.Toboggan);
            airTricks.GetChild("Tuck No Hander").SetActive(config.Tuck_No_Hander);
            airTricks.GetChild("Tuck Up").SetActive(config.Tuck_Up);
            airTricks.GetChild("Turndown").SetActive(config.Turndown);
            airTricks.GetChild("Whip Left").SetActive(config.Whip);
            airTricks.GetChild("Whip Right").SetActive(config.Whip);
            airTricks.GetChild("Whopper Left").SetActive(config.Whopper);
            airTricks.GetChild("Whopper Right").SetActive(config.Whopper);
        }
    }
}
