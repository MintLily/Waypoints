using System;
using System.Collections.Generic;
using System.Linq;
using MelonLoader;
using HarmonyLib;
using System.Reflection;

namespace Waypoints.Lib
{
    public static class Patches {
        private static void applyPatches(Type type) {
            Main.Log($"Applying {type.Name} patches!", Main.IsDebug);
            try {
                HarmonyLib.Harmony.CreateAndPatchAll(type, BuildInfo.Name + "_Hooks");
            } catch (Exception e) {
                Main.Logger.Error($"Failed while patching {type.Name}!\n{e}");
            }
        }

        public static void SetupPacthes() {
            Main.Log("Setting up Patches ...", Main.IsDebug);
            applyPatches(typeof(LeftRoomPatches));
            Main.Log("Finished with patching.", Main.IsDebug);
        }
    }

    [HarmonyPatch(typeof(NetworkManager))]
    internal class LeftRoomPatches {
        [HarmonyPostfix]
        [HarmonyPatch("OnLeftRoom")]
        private static void Yeet() => CheckWorldAllowed.OnWorldLeave();
    }
}
