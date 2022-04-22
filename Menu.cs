using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UIExpansionKit;
using UIExpansionKit.API;
using UIExpansionKit.API.Controls;
using UnityEngine;
using UnityEngine.UI;
using Waypoints.Lib;

namespace Waypoints
{
    internal static class Menu {
        private static ICustomShowableLayoutedMenu
            wa = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns),
            re = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns),
            r  = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns),
            s  = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.QuickMenu4Columns),
            really = ExpansionKitApi.CreateCustomQuickMenuPage(LayoutDescription.WideSlimList);

        private static string Color(string color, string text) => $"<color={color}>{text}</color> ";

        private static Dictionary<string, IMenuButton> _menuButtons = new();

        private static bool _started, _ranOnce;

        public static void InitUi() {
            try {
                ExpansionKitApi.GetExpandedMenu(ExpandedMenu.QuickMenu).AddSimpleButton("Waypoints", () => {
                    switch (_started) {
                        case false:
                            Main.Log("Setting up Menus");
                            WaypointMenu();
                            _started = true;
                            wa.Show();
                            break;
                        case true:
                            wa.Show();
                            UpdateText();
                            break;
                    }
                });
            } catch (Exception e) { Main.Logger.Error($"UIXMenu:\n{e}"); }
        }

        private static void WaypointMenu() {
            _menuButtons.Clear();

            var b = CheckWorldAllowed.RiskyFunctionAllowed;
            var updateText = Color(b ? "#00ff00" : "red", b ? "Allowed" : "Disallowed");

            _menuButtons["BackBtn"] = wa.AddSimpleButton($"{Color("red", "Close") + "Menu"}\nWorld {updateText}", () => { wa.Hide(); UpdateText(); });
            wa.AddSimpleButton(Color("#00ffff", "Rename") + "Menu", () => re.Show());
            wa.AddSimpleButton(Color("#00ff00", "Set") + "Menu", () => s.Show());
            wa.AddSimpleButton(Color("yellow", "Reset") + "Menu", () => r.Show());

            _menuButtons["main_1"] = wa.AddSimpleButton(Main.Name_1.Value, () => Teleport(Main.Waypoint_1, Main.Rot_1));
            _menuButtons["main_2"] = wa.AddSimpleButton(Main.Name_2.Value, () => Teleport(Main.Waypoint_2, Main.Rot_2));
            _menuButtons["main_3"] = wa.AddSimpleButton(Main.Name_3.Value, () => Teleport(Main.Waypoint_3, Main.Rot_3));
            _menuButtons["main_4"] = wa.AddSimpleButton(Main.Name_4.Value, () => Teleport(Main.Waypoint_4, Main.Rot_4));

            _menuButtons["main_5"] = wa.AddSimpleButton(Main.Name_5.Value, () => Teleport(Main.Waypoint_5, Main.Rot_5));
            _menuButtons["main_6"] = wa.AddSimpleButton(Main.Name_6.Value, () => Teleport(Main.Waypoint_6, Main.Rot_6));
            _menuButtons["main_7"] = wa.AddSimpleButton(Main.Name_7.Value, () => Teleport(Main.Waypoint_7, Main.Rot_7));
            _menuButtons["main_8"] = wa.AddSimpleButton(Main.Name_8.Value, () => Teleport(Main.Waypoint_8, Main.Rot_8));

            _menuButtons["main_9"] = wa.AddSimpleButton(Main.Name_9.Value, () => Teleport(Main.Waypoint_9, Main.Rot_9));
            _menuButtons["main_10"] = wa.AddSimpleButton(Main.Name_10.Value, () => Teleport(Main.Waypoint_10, Main.Rot_10));
            _menuButtons["main_11"] = wa.AddSimpleButton(Main.Name_11.Value, () => Teleport(Main.Waypoint_11, Main.Rot_11));
            _menuButtons["main_12"] = wa.AddSimpleButton(Main.Name_12.Value, () => Teleport(Main.Waypoint_12, Main.Rot_12));

            if (!_ranOnce) {
                RenameMenu();
                ResetMenu();
                SetMenu();
                ReallyResetAll();
                _ranOnce = true;
            }
        }

        private static void RenameMenu() {
            re.AddSimpleButton(Color("#B9BBBE", "Go Back"), () => { re.Hide(); wa.Show(); UpdateText(); });
            re.AddSpacer();
            re.AddSpacer();
            re.AddSpacer();

            re.AddSimpleButton("Rename\nWaypoint 1", () => Type("1", Main.Name_1));
            re.AddSimpleButton("Rename\nWaypoint 2", () => Type("2", Main.Name_2));
            re.AddSimpleButton("Rename\nWaypoint 3", () => Type("3", Main.Name_3));
            re.AddSimpleButton("Rename\nWaypoint 4", () => Type("4", Main.Name_4));

            re.AddSimpleButton("Rename\nWaypoint 5", () => Type("5", Main.Name_5));
            re.AddSimpleButton("Rename\nWaypoint 6", () => Type("6", Main.Name_6));
            re.AddSimpleButton("Rename\nWaypoint 7", () => Type("7", Main.Name_7));
            re.AddSimpleButton("Rename\nWaypoint 8", () => Type("8", Main.Name_8));

            re.AddSimpleButton("Rename\nWaypoint 7", () => Type("9", Main.Name_9));
            re.AddSimpleButton("Rename\nWaypoint 10", () => Type("10", Main.Name_10));
            re.AddSimpleButton("Rename\nWaypoint 11", () => Type("11", Main.Name_11));
            re.AddSimpleButton("Rename\nWaypoint 12", () => Type("12", Main.Name_12));
        }

        private static void ResetMenu() {
            r.AddSimpleButton(Color("#B9BBBE", "Go Back"), () => { r.Hide(); wa.Show(); UpdateText(); });
            r.AddSpacer();
            r.AddSpacer();
            r.AddSimpleButton(Color("red", "Reset All"), () => { r.Hide(); really.Show(); });

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

        private static void SetMenu() {
            s.AddSimpleButton(Color("#B9BBBE", "Go Back"), () => { s.Hide(); wa.Show(); UpdateText(); });
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

        private static void ReallyResetAll() {
            really.AddLabel("Would you really like to reset all Waypoints?");
            really.AddLabel($"<i>{Color("#B9BBBE", "This will set all waypoint values to ZERO and also reset all custom names.")}</i>");
            // Waiting for deprecated code to be removed, to add <size=12></size> later
            really.AddSpacer();
            really.AddSimpleButton(Color("red", "Yes, Reset All"), () => {
                ResetWaypointAndRotation(Main.Waypoint_1, Main.Rot_1);
                ResetWaypointAndRotation(Main.Waypoint_2, Main.Rot_2);
                ResetWaypointAndRotation(Main.Waypoint_3, Main.Rot_3);
                ResetWaypointAndRotation(Main.Waypoint_4, Main.Rot_4);
                ResetWaypointAndRotation(Main.Waypoint_5, Main.Rot_5);
                ResetWaypointAndRotation(Main.Waypoint_6, Main.Rot_6);
                ResetWaypointAndRotation(Main.Waypoint_7, Main.Rot_7);
                ResetWaypointAndRotation(Main.Waypoint_8, Main.Rot_8);
                ResetWaypointAndRotation(Main.Waypoint_9, Main.Rot_9);
                ResetWaypointAndRotation(Main.Waypoint_10, Main.Rot_10);
                ResetWaypointAndRotation(Main.Waypoint_11, Main.Rot_11);
                ResetWaypointAndRotation(Main.Waypoint_12, Main.Rot_12);
                SavePref(Main.Name_1, "Waypoint 1");
                SavePref(Main.Name_2, "Waypoint 2");
                SavePref(Main.Name_3, "Waypoint 3");
                SavePref(Main.Name_4, "Waypoint 4");
                SavePref(Main.Name_5, "Waypoint 5");
                SavePref(Main.Name_6, "Waypoint 6");
                SavePref(Main.Name_7, "Waypoint 7");
                SavePref(Main.Name_8, "Waypoint 8");
                SavePref(Main.Name_9, "Waypoint 9");
                SavePref(Main.Name_10, "Waypoint 10");
                SavePref(Main.Name_11, "Waypoint 11");
                SavePref(Main.Name_12, "Waypoint 12");
                // Yes, I know there is a MelonPref.ResetToDefault() this is easier to read for me. I understand the logic better this way.
                MelonPreferences.Save();
                UpdateText();
            });
            really.AddSimpleButton("No, Go Back", () => {
                really.Hide();
                r.Show();
            });
        }

        private static string[] SplitWaypoint(string waypoint) => waypoint.Split(' ');

        private static void AssignWaypointAndRotation(MelonPreferences_Entry<string> waypoint, MelonPreferences_Entry<string> rotation) {
            if (!CheckWorldAllowed.RiskyFunctionAllowed) return;
            var vectorX = PlayerUtils.GetPlayerPosition().x;
            var vectorY = PlayerUtils.GetPlayerPosition().y;
            var vectorZ = PlayerUtils.GetPlayerPosition().z;

            var quatX = PlayerUtils.GetPlayerRotation().x;
            var quatY = PlayerUtils.GetPlayerRotation().y;
            var quatZ = PlayerUtils.GetPlayerRotation().z;
            var quatW = PlayerUtils.GetPlayerRotation().w;

            waypoint.Value = $"{vectorX} {vectorY} {vectorZ}";
            rotation.Value = $"{quatX} {quatY} {quatZ} {quatW}";
            MelonPreferences.Save();
        }

        private static void ResetWaypointAndRotation(MelonPreferences_Entry<string> name, string num, MelonPreferences_Entry<string> waypoint, MelonPreferences_Entry<string> rotation) {
            //name.Value = "Waypoint " + num;
            waypoint.Value = "0 0 0";
            rotation.Value = "0 0 0 0";
            MelonPreferences.Save();
        }
        
        private static void ResetWaypointAndRotation(MelonPreferences_Entry<string> waypoint, MelonPreferences_Entry<string> rotation) {
            //name.Value = "Waypoint " + num;
            waypoint.Value = "0 0 0";
            rotation.Value = "0 0 0 0";
            MelonPreferences.Save();
        }

        internal static void Teleport(MelonPreferences_Entry<string> waypoint, MelonPreferences_Entry<string> rotation) {
            if (!CheckWorldAllowed.RiskyFunctionAllowed) return;
            var pos = SplitWaypoint(waypoint.Value);
            var rot = SplitWaypoint(rotation.Value);

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

        private static string GetButtonText(string buttonName, string text) {
            if (_menuButtons[buttonName] == null) return null;
            _menuButtons[buttonName].CurrentInstance!.GetComponentInChildren<TextMeshProUGUI>().richText = true;
            return _menuButtons[buttonName].Text = text;
        }

        private static void UpdateText() {
            var b = CheckWorldAllowed.RiskyFunctionAllowed;
            var updateText = Color(b ? "#00ff00" : "red", b ? "Allowed" : "Disallowed");

            GetButtonText("BackBtn", $"{Color("red", "Close") + "Menu"}\nWorld {updateText}");
            GetButtonText("main_1", Main.Name_1.Value);
            GetButtonText("main_2", Main.Name_2.Value);
            GetButtonText("main_3", Main.Name_3.Value);
            GetButtonText("main_4", Main.Name_4.Value);
            GetButtonText("main_5", Main.Name_5.Value);
            GetButtonText("main_6", Main.Name_6.Value);
            GetButtonText("main_7", Main.Name_7.Value);
            GetButtonText("main_8", Main.Name_8.Value);
            GetButtonText("main_9", Main.Name_9.Value);
            GetButtonText("main_10", Main.Name_10.Value);
            GetButtonText("main_11", Main.Name_11.Value);
            GetButtonText("main_12", Main.Name_12.Value);
        }

        private static void Type(string waypointNumber, MelonPreferences_Entry entry) {
            UI.ShowInputPopup($"Rename Waypoint {waypointNumber}", "", InputField.InputType.Standard, false, "Rename",
                (text, __, ___) => {
                    SavePref(entry, text);
                    MelonPreferences.Save();
                    UpdateText();
                }, null, $"Name of waypoint #{waypointNumber}");
        }

        private static void SavePref(MelonPreferences_Entry entry, string text) =>
            MelonPreferences.GetEntry<string>(Main.Waypoint.Identifier, entry.Identifier).Value = text;
    }
}
