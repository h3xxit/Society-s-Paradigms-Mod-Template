using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
using UnityEngine;

namespace RenameNamespace
{
    public class OnQuestManagerStart
    {
        public static void OnStart(string pathToModFolder, Dictionary<string, Sprite> loadedSprites)
        {
            Debug.Log("Template mod loaded something in QuestManager start");
            MecanicsManager.instance.AllQuests.Add("RenameNamespace.ModTemplateQuest", () => new ModTemplateQuest("Visible name of the quest"));
        }
    }
}

public class ModTemplateQuest : Quest
{
    public ModTemplateQuest(string name) : base(name)
    {
        //targetIdentifier is the name of the object that the quest arrow shoud point to. Only Objects that have the QuestTarget component can be chosen
        targetIdentifier = "RandomSpawner (2)";
        description = "Kill slimes";
        moneyReward = 10;
        itemReward = new List<Item> { MecanicsManager.instance.AllWeapons["shortBow"].copy() };
        MecanicsManager.instance.onKillMonsters += OnKill;
    }

    public override void OnQuestDestroy()
    {
        base.OnQuestDestroy();
        MecanicsManager.instance.onKillMonsters -= OnKill;
    }

    private int count;

    public void OnKill(Stats monsterName)
    {
        Debug.Log(monsterName);
        if (monsterName.statsName == "IceSlimes")
        {
            count++;
        }
    }

    public override void Req()
    {
        if (isCompleted)
            return;
        if (count > 1)
        {
            isCompleted = true;
        }
    }
}