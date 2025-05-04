using DevBlinkMod.Scripts;
using HarmonyLib;
using System.Threading.Tasks;
using UnityEngine;

namespace DevBlinkMod.Scripts.Patches
{
    [HarmonyPatch(typeof(VRRig), "Start")]
    class VRRigPatch
    {
        public static void VRRigPostfix(VRRig __instance)
        {
            GameObject instanceObject = __instance.gameObject;
            if (instanceObject.GetComponent<BlinkManager>() != null && instanceObject.activeSelf) return;
            instanceObject.AddComponent<BlinkManager>();
        }
    }
}
