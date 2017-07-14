using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace LessLethality
{
    public class ThingDef_BeanBag : ThingDef
    {
        public float AddHediffChance = 1f;
        public HediffDef HediffToAdd = HediffDefOf_Bruising.NNF_Bruising;
    }
}
