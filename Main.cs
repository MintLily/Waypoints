using MelonLoader;
using System;
using Waypoints.Lib;

namespace Waypoints
{
    public static class BuildInfo
    {
        public const string Name = "Waypoints";
        public const string Author = "Lily";
        public const string Company = "Minty Labs";
        public const string Version = "1.1.0";
        public const string DownloadLink = "https://github.com/MintLily/Waypoints";
        public const string Description = "A standalone waypoint system you can use across worlds.";
    }

    public class Main : MelonMod
    {
        public static bool IsDebug;
        internal MelonMod Waypoints;
        public static MelonPreferences_Category Waypoint;
        public static MelonPreferences_Entry<string> Name_1, Name_2, Name_3, Name_4, Name_5, Name_6, Name_7, Name_8,
            Name_9, Name_10, Name_11, Name_12;
        public static MelonPreferences_Entry<string> Waypoint_1, Waypoint_2, Waypoint_3, Waypoint_4, Waypoint_5, Waypoint_6, Waypoint_7, Waypoint_8,
            Waypoint_9, Waypoint_10, Waypoint_11, Waypoint_12;
        public static MelonPreferences_Entry<string> Rot_1, Rot_2, Rot_3, Rot_4, Rot_5, Rot_6, Rot_7, Rot_8, Rot_9, Rot_10, Rot_11, Rot_12;
        internal static readonly MelonLogger.Instance Logger = new(BuildInfo.Name, ConsoleColor.Yellow);

        public override void OnApplicationStart() {
            MelonLogger.Msg("Initializing . . .");
            Waypoints = this;
            if (MelonDebug.IsEnabled() || Environment.CommandLine.Contains("--way.debug")) {
                IsDebug = true;
                MelonLogger.Msg(ConsoleColor.Green, "Debug mode is active");
            }

            Patches.SetupPacthes();
            Menu.InitUi();

            Waypoint = MelonPreferences.CreateCategory("Waypoints", "Waypoints");

            Name_1 = Waypoint.CreateEntry("Name_1", "Waypoint 1", "Button Name 1", null, true);
            Waypoint_1 = Waypoint.CreateEntry("Waypoint_1", "0 0 0", "Waypoint 1 XYZ Coords");
            Rot_1 = Waypoint.CreateEntry("Rotation_1", "0 0 0 0", "Rotaion 1 Quad Coords", null, true);

            Name_2 = Waypoint.CreateEntry("Name_2", "Waypoint 2", "Button Name 2", null, true);
            Waypoint_2 = Waypoint.CreateEntry("Waypoint_2", "0 0 0", "Waypoint 2 XYZ Coords");
            Rot_2 = Waypoint.CreateEntry("Rotation_2", "0 0 0 0", "Rotaion 2 Quad Coords", null, true);

            Name_3 = Waypoint.CreateEntry("Name_3", "Waypoint 3", "Button Name 3", null, true);
            Waypoint_3 = Waypoint.CreateEntry("Waypoint_3", "0 0 0", "Waypoint 3 XYZ Coords");
            Rot_3 = Waypoint.CreateEntry("Rotation_3", "0 0 0 0", "Rotaion 3 Quad Coords", null, true);

            Name_4 = Waypoint.CreateEntry("Name_4", "Waypoint 4", "Button Name 4", null, true);
            Waypoint_4 = Waypoint.CreateEntry("Waypoint_4", "0 0 0", "Waypoint 4 XYZ Coords");
            Rot_4 = Waypoint.CreateEntry("Rotation_4", "0 0 0 0", "Rotaion 4 Quad Coords", null, true);

            Name_5 = Waypoint.CreateEntry("Name_5", "Waypoint 5", "Button Name 5", null, true);
            Waypoint_5 = Waypoint.CreateEntry("Waypoint_5", "0 0 0", "Waypoint 5 XYZ Coords");
            Rot_5 = Waypoint.CreateEntry("Rotation_5", "0 0 0 0", "Rotaion 5 Quad Coords", null, true);

            Name_6 = Waypoint.CreateEntry("Name_6", "Waypoint 6", "Button Name 6", null, true);
            Waypoint_6 = Waypoint.CreateEntry("Waypoint_6", "0 0 0", "Waypoint 6 XYZ Coords");
            Rot_6 = Waypoint.CreateEntry("Rotation_6", "0 0 0 0", "Rotaion 6 Quad Coords", null, true);

            Name_7 = Waypoint.CreateEntry("Name_7", "Waypoint 7", "Button Name 7", null, true);
            Waypoint_7 = Waypoint.CreateEntry("Waypoint_7", "0 0 0", "Waypoint 7 XYZ Coords");
            Rot_7 = Waypoint.CreateEntry("Rotation_7", "0 0 0 0", "Rotaion 7 Quad Coords", null, true);

            Name_8 = Waypoint.CreateEntry("Name_8", "Waypoint 8", "Button Name 8", null, true);
            Waypoint_8 = Waypoint.CreateEntry("Waypoint_8", "0 0 0", "Waypoint 8 XYZ Coords");
            Rot_8 = Waypoint.CreateEntry("Rotation_8", "0 0 0 0", "Rotaion 8 Quad Coords", null, true);

            Name_9 = Waypoint.CreateEntry("Name_9", "Waypoint 9", "Button Name 9", null, true);
            Waypoint_9 = Waypoint.CreateEntry("Waypoint_9", "0 0 0", "Waypoint 9 XYZ Coords");
            Rot_9 = Waypoint.CreateEntry("Rotation_9", "0 0 0 0", "Rotaion 9 Quad Coords", null, true);

            Name_10 = Waypoint.CreateEntry("Name_10", "Waypoint 10", "Button Name 10", null, true);
            Waypoint_10 = Waypoint.CreateEntry("Waypoint_10", "0 0 0", "Waypoint 10 XYZ Coords");
            Rot_10 = Waypoint.CreateEntry("Rotation_10", "0 0 0 0", "Rotaion 10 Quad Coords", null, true);

            Name_11 = Waypoint.CreateEntry("Name_11", "Waypoint 11", "Button Name 11", null, true);
            Waypoint_11 = Waypoint.CreateEntry("Waypoint_11", "0 0 0", "Waypoint 11 XYZ Coords");
            Rot_11 = Waypoint.CreateEntry("Rotation_11", "0 0 0 0", "Rotaion 11 Quad Coords", null, true);

            Name_12 = Waypoint.CreateEntry("Name_12", "Waypoint 12", "Button Name 12", null, true);
            Waypoint_12 = Waypoint.CreateEntry("Waypoint_12", "0 0 0", "Waypoint 12 XYZ Coords");
            Rot_12 = Waypoint.CreateEntry("Rotation_12", "0 0 0 0", "Rotaion 12 Quad Coords", null, true);
        }

        public override void OnApplicationQuit() => MelonPreferences.Save();

        public override void OnSceneWasInitialized(int buildIndex, string sceneName) => Lib.CheckWorldAllowed.WorldChange(buildIndex);

        public static void Log(string s, bool isDebug = false) {
            var c = Console.ForegroundColor;
            Logger.Msg(isDebug ? ConsoleColor.DarkMagenta : c, s);
        }
    }
}