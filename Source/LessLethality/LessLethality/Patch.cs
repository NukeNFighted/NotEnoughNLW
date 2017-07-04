using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Harmony;
using Verse;

namespace LessLethality
{
    [HarmonyPatch(typeof(Pawn_HealthTracker))]
    [HarmonyPatch("CheckForStateChange")]
     public class Patch
    {
        static FieldInfo pawnField = AccessTools.Field(typeof(Pawn_HealthTracker), "pawn");



        [HarmonyPrefix]
        static void Prefix(Pawn_HealthTracker __instance, ref DamageInfo? dinfo, ref Hediff hediff)
        {

            Pawn pawn = pawnField.GetValue(__instance) as Pawn;


            if (pawn.RaceProps.IsFlesh && pawn.health.hediffSet.HasHediff(HediffDef.Named("NNF_Incapacitated")))
            {
                __instance.forceIncap = true;
                return;
            }
        }

    }
}
