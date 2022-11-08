using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RenameNamespace
{
    public class OnActionManagerAwake
    {
        public static void OnStart(string pathToModFolder, Dictionary<string, Sprite> loadedSprites)
        {
            Debug.Log("Template mod loaded something in actionmanager awake");
            PlayerStats player = MecanicsManager.instance.Player;
            MecanicsManager.instance.AllActions.Add("RenameNamespace.ModTemplateAction", new ModTemplateAction(player, "RenameNamespace.ModTemplateAction"));
        }
    }
}

public class ModTemplateAction : Action
{
    public ModTemplateAction(PlayerStats pl, string actionName) : base(pl, actionName)
    {
        name = "ModTemplateAction";
    }

    //requirement for the action to show up in the action bar
    override public bool req()
    {
        return !player.isMoving;
    }

    //happens when action button is clicked
    override public void toggle()
    {
        active = !active;
    }

    //req for the action to remain visible once it is shown
    override public void checkReq()
    {
        if (active)
        {
            if (!req())
                toggle();
        }
    }
}