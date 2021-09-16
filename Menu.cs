using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIExpansionKit;
using UIExpansionKit.API;
using UnityEngine;
using UnityEngine.UI;
using Waypoints.Lib;

namespace Waypoints
{
    class Menu
    {
        static ICustomShowableLayoutedMenu wa = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns);
        static ICustomShowableLayoutedMenu re = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns);
        static ICustomShowableLayoutedMenu r = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns);
        static ICustomShowableLayoutedMenu s = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns);

        static string color(string c, string s) { return $"<color={c}>{s}</color> "; }

        static Dictionary<string, Transform> buttons = new Dictionary<string, Transform>();

        static bool runOnce_start, runOnce;

        public static void InitUi() {
            try {
                ExpansionKitApi.GetExpandedMenu(ExpandedMenu.QuickMenu).AddSimpleButton("Waypoints", () => {
                    if (!runOnce_start) {
                        MelonLogger.Msg("Setting up Menus");
                        WaypointMenu();
                        runOnce_start = true;
                        wa.Show();
                    } else if (runOnce_start) {
                        wa.Show();
                        UpdateText();
                    }
                });
            } catch (Exception e) { MelonLogger.Error("UIXMenu:\n" + e.ToString()); }
        }

        static void WaypointMenu() {
            buttons.Clear();
            wa.AddSimpleButton($"{color("red", "Close") + "Menu"}\nWorld " +
                $"{(CheckWorldAllowed.WorldAllowed ? color("#00ff00", "Allowed") : color("red", "Disallowed"))}", 
                () => { wa.Hide(); UpdateText(); }, (button) => buttons["BackBtn"] = button.transform);
            wa.AddSimpleButton(color("cyan", "Rename") + "Menu", () => re.Show());
            wa.AddSimpleButton(color("#00ff00", "Set") + "Menu", () => s.Show());
            wa.AddSimpleButton(color("yellow", "Reset") + "Menu", () => r.Show());

            wa.AddSimpleButton(Main.Name_1.Value, () => Teleport(Main.Waypoint_1, Main.Rot_1), (button) => buttons["main_1"] = button.transform);
            wa.AddSimpleButton(Main.Name_2.Value, () => Teleport(Main.Waypoint_2, Main.Rot_2), (button) => buttons["main_2"] = button.transform);
            wa.AddSimpleButton(Main.Name_3.Value, () => Teleport(Main.Waypoint_3, Main.Rot_3), (button) => buttons["main_3"] = button.transform);
            wa.AddSimpleButton(Main.Name_4.Value, () => Teleport(Main.Waypoint_4, Main.Rot_4), (button) => buttons["main_4"] = button.transform);

            wa.AddSimpleButton(Main.Name_5.Value, () => Teleport(Main.Waypoint_5, Main.Rot_5), (button) => buttons["main_5"] = button.transform);
            wa.AddSimpleButton(Main.Name_6.Value, () => Teleport(Main.Waypoint_6, Main.Rot_6), (button) => buttons["main_6"] = button.transform);
            wa.AddSimpleButton(Main.Name_7.Value, () => Teleport(Main.Waypoint_7, Main.Rot_7), (button) => buttons["main_7"] = button.transform);
            wa.AddSimpleButton(Main.Name_8.Value, () => Teleport(Main.Waypoint_8, Main.Rot_8), (button) => buttons["main_8"] = button.transform);

            wa.AddSimpleButton(Main.Name_9.Value, () => Teleport(Main.Waypoint_9, Main.Rot_9), (button) => buttons["main_9"] = button.transform);
            wa.AddSimpleButton(Main.Name_10.Value, () => Teleport(Main.Waypoint_10, Main.Rot_10), (button) => buttons["main_10"] = button.transform);
            wa.AddSimpleButton(Main.Name_11.Value, () => Teleport(Main.Waypoint_11, Main.Rot_11), (button) => buttons["main_11"] = button.transform);
            wa.AddSimpleButton(Main.Name_12.Value, () => Teleport(Main.Waypoint_12, Main.Rot_12), (button) => buttons["main_12"] = button.transform);

            if (!runOnce) {
                RenameMenu();
                ResetMenu();
                SetMenu();
                runOnce = true;
            }
        }

        static void RenameMenu() {
            re.AddSimpleButton(color("red", "Close") + "Menu", () => { re.Hide(); wa.Show(); });
            re.AddSpacer();
            re.AddSpacer();
            re.AddSpacer();

            re.AddSimpleButton("Rename\nWaypoint 1", () => Type("1", Main.Name_1.Value));
            re.AddSimpleButton("Rename\nWaypoint 2", () => Type("2", Main.Name_2.Value));
            re.AddSimpleButton("Rename\nWaypoint 3", () => Type("3", Main.Name_3.Value));
            re.AddSimpleButton("Rename\nWaypoint 4", () => Type("4", Main.Name_4.Value));

            re.AddSimpleButton("Rename\nWaypoint 5", () => Type("5", Main.Name_5.Value));
            re.AddSimpleButton("Rename\nWaypoint 6", () => Type("6", Main.Name_6.Value));
            re.AddSimpleButton("Rename\nWaypoint 7", () => Type("7", Main.Name_7.Value));
            re.AddSimpleButton("Rename\nWaypoint 8", () => Type("8", Main.Name_8.Value));

            re.AddSimpleButton("Rename\nWaypoint 7", () => Type("9", Main.Name_9.Value));
            re.AddSimpleButton("Rename\nWaypoint 10", () => Type("10", Main.Name_10.Value));
            re.AddSimpleButton("Rename\nWaypoint 11", () => Type("11", Main.Name_11.Value));
            re.AddSimpleButton("Rename\nWaypoint 12", () => Type("12", Main.Name_12.Value));
        }

        static void ResetMenu() {
            r.AddSimpleButton(color("red", "Close") + "Menu", () => { r.Hide(); wa.Show(); });
            r.AddSpacer();
            r.AddSpacer();
            r.AddSpacer();

            r.AddSimpleButton("Reset\nWaypoint 1", () => ResetWaypointAndRotation(Main.Name_1, "1", Main.Waypoint_1, Main.Rot_1));
            r.AddSimpleButton("Reset\nWaypoint 2", () => ResetWaypointAndRotation(Main.Name_2, "2", Main.Waypoint_2, Main.Rot_2));
            r.AddSimpleButton("Reset\nWaypoint 3", () => ResetWaypointAndRotation(Main.Name_3, "3", Main.Waypoint_3, Main.Rot_3));
            r.AddSimpleButton("Reset\nWaypoint 4", () => ResetWaypointAndRotation(Main.Name_4, "4", Main.Waypoint_4, Main.Rot_4));

            r.AddSimpleButton("Reset\nWaypoint 5", () => ResetWaypointAndRotation(Main.Name_5, "5", Main.Waypoint_5, Main.Rot_5));
            r.AddSimpleButton("Reset\nWaypoint 6", () => ResetWaypointAndRotation(Main.Name_6, "6", Main.Waypoint_6, Main.Rot_6));
            r.AddSimpleButton("Reset\nWaypoint 7", () => ResetWaypointAndRotation(Main.Name_7, "7", Main.Waypoint_7, Main.Rot_7));
            r.AddSimpleButton("Reset\nWaypoint 8", () => ResetWaypointAndRotation(Main.Name_8, "8", Main.Waypoint_8, Main.Rot_8));

            r.AddSimpleButton("Reset\nWaypoint 9", () => ResetWaypointAndRotation(Main.Name_9, "9", Main.Waypoint_9, Main.Rot_9));
            r.AddSimpleButton("Reset\nWaypoint 10", () => ResetWaypointAndRotation(Main.Name_10, "10", Main.Waypoint_10, Main.Rot_10));
            r.AddSimpleButton("Reset\nWaypoint 11", () => ResetWaypointAndRotation(Main.Name_11, "11", Main.Waypoint_11, Main.Rot_11));
            r.AddSimpleButton("Reset\nWaypoint 12", () => ResetWaypointAndRotation(Main.Name_12, "12", Main.Waypoint_12, Main.Rot_12));
        }

        static void SetMenu() {
            s.AddSimpleButton(color("red", "Close") + "Menu", () => { s.Hide(); wa.Show(); });
            s.AddSpacer();
            s.AddSpacer();
            s.AddSpacer();

            s.AddSimpleButton("Set\nWaypoint 1", () => AssignWaypointAndRotation(Main.Waypoint_1, Main.Rot_1));
            s.AddSimpleButton("Set\nWaypoint 2", () => AssignWaypointAndRotation(Main.Waypoint_2, Main.Rot_2));
            s.AddSimpleButton("Set\nWaypoint 3", () => AssignWaypointAndRotation(Main.Waypoint_3, Main.Rot_3));
            s.AddSimpleButton("Set\nWaypoint 4", () => AssignWaypointAndRotation(Main.Waypoint_4, Main.Rot_4));

            s.AddSimpleButton("Set\nWaypoint 5", () => AssignWaypointAndRotation(Main.Waypoint_5, Main.Rot_5));
            s.AddSimpleButton("Set\nWaypoint 6", () => AssignWaypointAndRotation(Main.Waypoint_6, Main.Rot_6));
            s.AddSimpleButton("Set\nWaypoint 7", () => AssignWaypointAndRotation(Main.Waypoint_7, Main.Rot_7));
            s.AddSimpleButton("Set\nWaypoint 8", () => AssignWaypointAndRotation(Main.Waypoint_8, Main.Rot_8));

            s.AddSimpleButton("Set\nWaypoint 9", () => AssignWaypointAndRotation(Main.Waypoint_9, Main.Rot_9));
            s.AddSimpleButton("Set\nWaypoint 10", () => AssignWaypointAndRotation(Main.Waypoint_10, Main.Rot_10));
            s.AddSimpleButton("Set\nWaypoint 11", () => AssignWaypointAndRotation(Main.Waypoint_11, Main.Rot_11));
            s.AddSimpleButton("Set\nWaypoint 12", () => AssignWaypointAndRotation(Main.Waypoint_12, Main.Rot_12));
        }

        internal static string[] splitWaypoint(string waypoint) => waypoint.Split(' ');

        internal static void AssignWaypointAndRotation(MelonPreferences_Entry<string> waypoint, MelonPreferences_Entry<string> rotaion) {
            if (!CheckWorldAllowed.WorldAllowed) return;
            float vectorX = PlayerUtils.GetPlayerPosition().x;
            float vectorY = PlayerUtils.GetPlayerPosition().y;
            float vectorZ = PlayerUtils.GetPlayerPosition().z;

            float QuatX = PlayerUtils.GetPlayerRotation().x;
            float QuatY = PlayerUtils.GetPlayerRotation().y;
            float QuatZ = PlayerUtils.GetPlayerRotation().z;
            float QuatW = PlayerUtils.GetPlayerRotation().w;

            waypoint.Value = $"{vectorX} {vectorY} {vectorZ}";
            rotaion.Value = $"{QuatX} {QuatY} {QuatZ} {QuatW}";
            MelonPreferences.Save();
        }

        internal static void ResetWaypointAndRotation(MelonPreferences_Entry<string> name, string num, MelonPreferences_Entry<string> waypoint, MelonPreferences_Entry<string> rotaion) {
            //name.Value = "Waypoint " + num;
            waypoint.Value = "0 0 0";
            rotaion.Value = "0 0 0 0";
            MelonPreferences.Save();
        }

        internal static void Teleport(MelonPreferences_Entry<string> waypoint, MelonPreferences_Entry<string> rotaion) {
            if (!CheckWorldAllowed.WorldAllowed) return;
            string[] pos = splitWaypoint(waypoint.Value);
            string[] rot = splitWaypoint(rotaion.Value);

            float _1, _2, _3, __1, __2, __3, __4;
            float.TryParse(pos[0], out _1);
            float.TryParse(pos[1], out _2);
            float.TryParse(pos[2], out _3);

            float.TryParse(rot[0], out __1);
            float.TryParse(rot[1], out __2);
            float.TryParse(rot[2], out __3);
            float.TryParse(rot[3], out __4);

            PlayerUtils.SendToLocation(new Vector3(_1, _2, _3), new Quaternion(__1, __2, __3, __4));
        }

        static string text(string buttonName, string text) {
            if (buttons[buttonName] != null)
                return buttons[buttonName].GetComponentInChildren<Text>().text = text;
            else return null;
        }

        static void UpdateText() {
            text("BackBtn", $"{color("red", "Close") + "Menu"}\nWorld " + $"{(CheckWorldAllowed.WorldAllowed ? color("#00ff00", "Allowed") : color("red", "Disallowed"))}");
            text("main_1", Main.Name_1.Value);
            text("main_2", Main.Name_2.Value);
            text("main_3", Main.Name_3.Value);
            text("main_4", Main.Name_4.Value);
            text("main_5", Main.Name_5.Value);
            text("main_6", Main.Name_6.Value);
            text("main_7", Main.Name_7.Value);
            text("main_8", Main.Name_8.Value);
            text("main_9", Main.Name_9.Value);
            text("main_10", Main.Name_10.Value);
            text("main_11", Main.Name_11.Value);
            text("main_12", Main.Name_12.Value);
        }

        static void Type(string WaypointNumber, string NameTarget) {
            UI.ShowInputPopup($"Rename Waypoint {WaypointNumber}", "", InputField.InputType.Standard, false, "Rename",
                (s, __, ___) => {
                    NameTarget = s;
                    MelonPreferences.Save();
                    UpdateText();
                }, null, $"Name of waypoint #{WaypointNumber}");
        }
    }
}
