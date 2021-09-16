﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.Core;
using System.Net;
using MelonLoader;

namespace Waypoints.Lib
{
    internal static class CheckWorldAllowed
    {
        internal static bool WorldAllowed = false;

        internal static IEnumerator CheckWorld() {
            Main.Log("Checking World", Main.isDebug);

            string worldId;
            if (RoomManager.field_Internal_Static_ApiWorld_0 == null) {
                Main.Log("Checking World => Halted", Main.isDebug);
                yield break;
            }
            worldId = RoomManager.field_Internal_Static_ApiWorld_0.id;
            Main.Log($"Got WorldID: {worldId}", Main.isDebug);

            WorldAllowed = false;

            // Allow world creators more choice over Risky Functions without relying on our whitelist, we are looking for "eVRCRiskFuncDisable" or "eVRCRiskFuncEnable"
            // If these are present, they will completely override our choice from tags and the online list, and manually disable or enable Risky Functions
            GameObject[] allWorldGameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            if (allWorldGameObjects.Any(a => a.name == "eVRCRiskFuncDisable") || allWorldGameObjects.Any(a => a.name == "UniversalRiskyFuncDisable")) {
                Main.Log("GameObject found: Disabling Fucntions", Main.isDebug);
                WorldAllowed = false;
                yield break;
            } else if (allWorldGameObjects.Any(a => a.name == "eVRCRiskFuncEnable") || allWorldGameObjects.Any(a => a.name == "UniversalRiskyFuncEnable")) {
                Main.Log("GameObject found: Enabling Fucntions", Main.isDebug);
                WorldAllowed = true;
                yield break;
            }

            // Check if black/whitelisted from EmmVRC
            string url = $"https://dl.emmvrc.com/riskyfuncs.php?worldid={worldId}";
            WebClient www = new WebClient();
            //while (www.IsBusy) yield return null;
            string result = www.DownloadString(url)?.Trim().ToLower();
            www.Dispose();
            if (!string.IsNullOrWhiteSpace(result))
                switch (result)
                {
                    case "allowed":
                        WorldAllowed = true;
                        yield break;

                    case "denied":
                        WorldAllowed = false;
                        yield break;
                }

            Main.Log("Checking World Tags, no response from EmmVRC", Main.isDebug);

            // no result from server or they're currently down
            // Check tags then. should also be in cache as it just got downloaded
            API.Fetch<ApiWorld>(worldId, new Action<ApiContainer>(container => {
                ApiWorld apiWorld;
                if ((apiWorld = container.Model.TryCast<ApiWorld>()) != null)
                {
                    foreach (string worldTag in apiWorld.tags)
                        if (worldTag.IndexOf("game", StringComparison.OrdinalIgnoreCase) >= 0) {
                            WorldAllowed = false;
                            return;
                        }

                    WorldAllowed = true;
                    return;
                }
                else MelonLogger.Error("Failed to cast ApiModel to ApiWorld");
            }), disableCache: false);

            // If all else fails, or is errored return false
            WorldAllowed = false;
        }

        public static void OnWorldLeave() => WorldAllowed = false;
    }
}
