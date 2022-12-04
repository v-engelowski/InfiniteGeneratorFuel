using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStorm;
using UnityEngine;

namespace InfiniteGeneratorFuel
{
    [BepInPlugin("forza.infinitefuel", "InfinteFuel", "1.0")]
    public class InfiniteFuel : BaseUnityPlugin
    {
        void Awake()
        {
            new Harmony("forza.infinitefuel").PatchAll();

            Logger.LogMessage("Loaded and patched");
        }
    }

    [HarmonyPatch(typeof(HomeGenerator), "Tick")]
    public class Patch
    {
        [HarmonyPrefix]
        public static bool TickPatch(int tick, HomeGenerator __instance, ref Part_FuelTank ___FuelTank)
        {
            ___FuelTank.Get_FuelLevel = ___FuelTank.Get_FuelCapacity;

            return true;
        }
    }
}
