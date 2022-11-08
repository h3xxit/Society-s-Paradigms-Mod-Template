using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RenameNamespace
{
    public class OnWeaponManagerAwake
    {
        public static void OnStart(string pathToModFolder, Dictionary<string, Sprite> loadedSprites)
        {
            Debug.Log("Template mod loaded something in weaponmanger awake");
            MecanicsManager.instance.AllWeapons.Add("RenameNamespace.ModTemplateItem", 
                new ModTemplateWeapon(MecanicsManager.instance.Player, loadedSprites["Image.png"], loadedSprites["Image.png"], loadedSprites["Image.png"], "RenameNamespace.ModTemplateItem"));
        }
    }
}

public class ModTemplateWeapon : Weapon //, MagicalWeapon
{
    //add these if you are making a general weapon class(ex: ShortSword)
    //these can be modifies from outside to provide bonuses the whole weapon class(gaining mastery in shortswords gives bonus damage with all shortswords)
    
    //public static float staticDmgPercMOD, staticDmgConstMOD;
    //public static float staticAttSpdPercMOD, staticAttSpdConstMOD;

    //constructor. modify range, baseDmg, name, cost, knockback
    public ModTemplateWeapon(PlayerStats pl, Sprite I, Sprite invI, Sprite dropI, string itemName, bool shouldConstruct = true) : base(pl, I, invI, dropI, itemName)
    {
        if (!shouldConstruct) return;
        Range = 0.6f;
        baseDmg = 0;
        displayName = "ModTemplateWeapon";
        cost = 0;
        knockback = 0;
        wieldType = WieldType.Onehanded;
        damageType = DamageType.Slashing;
        Durability = 50;
        CurrentDurability = 50;
    }

    //mathematical formula for dmg, can modify
    public override float Dmg
    {
        get
        {
            return ((baseDmg + player.STR) * (dmgPercMOD + 100) / 100 + dmgConstMOD);
        }
    }

    //mathematical formula for attackspeed, return the number of attacks per second, can modify
    public override float AttSpd
    {
        get
        {
            return ((baseAttSpd * (player.DEX / 5 + 100) / 100) * (attSpdPercMOD + 100) / 100 + attSpdConstMOD);
        }
    }

    public override Item copy()
    {
        return new ModTemplateWeapon(player, img, inventoryImg, dropImg, itemName);
    }

    public override string FlavourText()
    {
        return "";
    }
}