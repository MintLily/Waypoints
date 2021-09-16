using System;
using System.Collections.Generic;
using System.Linq;
using MelonLoader;
using HarmonyLib;
using System.Reflection;

namespace Waypoints.Lib
{
    public static class Patches
    {
        private static void applyPatches(Type type) {
            if (Main.isDebug) MelonLogger.Msg($"Applying {type.Name} patches!");
            try {
                HarmonyLib.Harmony.CreateAndPatchAll(type, BuildInfo.Name + "_Hooks");
            } catch (Exception e) {
                MelonLogger.Error($"Failed while patching {type.Name}!\n{e}");
            }
        }

        public static void SetupPacthes() {
            if (Main.isDebug) MelonLogger.Msg("Setting up Patches ...");
            applyPatches(typeof(FadeToPatches));
            applyPatches(typeof(LeftRoomPatches));
            if (Main.isDebug) MelonLogger.Msg("Finished with patching.");
        }
    }

    [HarmonyPatch]
    class FadeToPatches {
        static IEnumerable<MethodBase> TargetMethods() {
            return typeof(VRCUiBackgroundFade).GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name.Contains("Method_Public_Void_Single_Action")
            && !x.Name.Contains("PDM")).Cast<MethodBase>();
        }
        static void Postfix() => MelonCoroutines.Start(CheckWorldAllowed.CheckWorld());
    }

    [HarmonyPatch(typeof(NetworkManager))]
    class LeftRoomPatches {
        [HarmonyPostfix]
        [HarmonyPatch("OnLeftRoom")]
        static void Yeet() => CheckWorldAllowed.OnWorldLeave();
    }
}
