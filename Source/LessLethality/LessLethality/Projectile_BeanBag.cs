using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;


namespace LessLethality
{
    public class Projectile_BeanBag : Bullet
    {

        public ThingDef_BeanBag Def
        {
            get
            {
                return this.def as ThingDef_BeanBag;
            }
}
        protected override void Impact(Thing hitThing)
        {



            base.Impact(hitThing);


            Pawn hitPawn = hitThing as Pawn;
            if (Def != null && hitThing != null) 
            {
                var rand = Rand.Value; 
                if (rand <= Def.AddHediffChance) 
                {
                 

                    var bruisingOnPawn = hitPawn?.health?.hediffSet?.GetFirstHediffOfDef(Def.HediffToAdd);
                    var randomSeverity = Rand.Range(0.10f, 0.15f);
                    if (bruisingOnPawn != null)
                    {
                        bruisingOnPawn.Severity += randomSeverity;
                    }
                    else if (hitPawn != null)
                    {
                        //These three lines create a new health differential or Hediff,
                        //put them on the character, and increase its severity by a random amount.
                        Hediff hediff = HediffMaker.MakeHediff(Def.HediffToAdd, hitPawn, null);
                        hediff.Severity = randomSeverity;
                        hitPawn.health.AddHediff(hediff, null, null);
                    }
                }               
            }
        }
    }
}
