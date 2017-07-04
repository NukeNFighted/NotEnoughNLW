using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Harmony;
using Verse;

namespace LessLethality
{
    [StaticConstructorOnStartup]
     class Main
    {
        static Main()
        {
            var harmony = HarmonyInstance.Create("com.github.rimworld.mod.notenoughNLW");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

        }


    }
}
