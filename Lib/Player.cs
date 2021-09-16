using System;
using VRC;
using VRC.Core;
using UnityEngine;

namespace Waypoints.Lib
{
    public static class PlayerUtils
    {
        public static VRCPlayer GetLocalVRCPlayer() => VRCPlayer.field_Internal_Static_VRCPlayer_0;
        public static Quaternion GetPlayerRotation() => GetLocalVRCPlayer().transform.rotation;
        public static Vector3 GetPlayerPosition() => GetLocalVRCPlayer().transform.position;
        public static void SendToLocation(Vector3 pos, Quaternion rot) {
            GetLocalVRCPlayer().transform.position = pos;
            GetLocalVRCPlayer().transform.rotation = rot;
        }
    }
}
