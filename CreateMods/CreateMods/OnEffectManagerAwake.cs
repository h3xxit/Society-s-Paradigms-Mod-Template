using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RenameNamespace
{
    public class OnEffectManagerAwake
    {
        public static void OnStart(string pathToModFolder, Dictionary<string, Sprite> loadedSprites)
        {
            Debug.Log("Template mod loaded something in effectmanger awake");
            PlayerStats player = MecanicsManager.instance.Player;
            MecanicsManager.instance.AllEffects.Add("RenameNamespace.ModTemplateEffect", new ModTemplateEffect(player, "RenameNamespace.ModTemplateEffect", loadedSprites["Image.png"]));
        }
    }

    public class ModTemplateEffect : Effect
    {
        //constructor for stats type = 0, replace effectName with current effect number and maxCD with the duration in s, if effect is negative decomment isNegative = true;
        public ModTemplateEffect(Stats stats, string effectName = "", Sprite I = null) : base(stats, effectName, I)
        {
            maxCD = 1f;
            //is this considered a negative effect?
            isNegative = false;
        }

        //happens on effect start
        public override void OnActivate()
        {

        }

        // happens on effect end
        public override void OnEnd()
        {

        }

        //happens every frame the effect is active
        public override void whileActive()
        {

        }

        public override Effect copy()
        {
            return new EffectTemplate(stats, effectName, img);
        }

        public override string FlavourText()
        {
            return "";
        }
    }
}
