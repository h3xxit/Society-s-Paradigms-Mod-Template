using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RenameNamespace
{
    public class OnItemManagerAwake
    {
        public static void OnStart(string pathToModFolder, Dictionary<string, Sprite> loadedSprites)
        {
            Debug.Log("Template mod loaded something in itemmanger awake");
            MecanicsManager.instance.AllItems.Add("RenameNamespace.ModTemplateItem", new ModTemplateItem(loadedSprites["Image.png"], loadedSprites["Image.png"], "RenameNamespace.ModTemplateItem"));
        }
    }
}

[System.Serializable]
public class ModTemplateItem : Item
{
    public ModTemplateItem(Sprite img, Sprite dropImg, string itemName) : base(img, dropImg, itemName)
    {
        cost = 5;
        displayName = "Wood";
        availableItems = 1;
        isUseable = false;
    }

    //What else should be copied when creating a copy
    public ModTemplateItem(Wood wood) : base(wood)
    {
    }

    //If item is usable, this gets executed before the item is used up
    public override void Use()
    {

    }

    public override Item copy()
    {
        return new Wood(inventoryImg, dropImg, itemName);
    }

    public override string FlavourText()
    {
        return "ModTemplateEffect\nAdd your own flavor text.";
    }
}