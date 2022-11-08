using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RenameNamespace
{
    public class OnSkillManagerAwake
    {
        public static void OnStart(string pathToModFolder, Dictionary<string, Sprite> loadedSprites)
        {
            Debug.Log("Template mod loaded something in skillmanager awake");
            PlayerStats player = MecanicsManager.instance.Player;
            MecanicsManager.instance.AllSkills.Add("RenameNamespace.ModTemplateSkill", new ModTemplateSkill(player, loadedSprites["Image.png"], "RenameNamespace.ModTemplateSkill"));
        }
    }

    //can implement hintable interface to appear as hint when talking to exclamation mark npc's
    class ModTemplateSkill : skill //, hintable
    {
        //constructor, replace 0 with current skill number, name and description is what will be shown in the skill tab 
        //after implementing the skill please write "player.AllSkills.Add(new 'class name'(player, allImg['index of the image in the allImg list']));" in the awake function above
        public ModTemplateSkill(PlayerStats pl, Sprite s, string skillName) : base(pl, s, skillName)
        {
            displayName = "Mod Template Skill";
            description = () => "Passive/Active Skill - Does nothing";
            baseMaxCD = 1;
            
            //add links to other skills to display skills as connected to each other in the skill viewer graph
            link.Add("dash");
        }

        //the requirement to get the skill, checked every frame(once getSkill is called it will never be executed again, return true to show new skill notification to player)
        override public bool req()
        {
            if(MecanicsManager.instance.Player.STR > 10)
            {
                getSkill();
                return true;
            }
            return false;
        }

        //triggers when skill is cast
        override public void activeEffect()
        {
            //example for a toggled skill
            if (!isToggled)
            {
                //sets the skill on cooldown
                canCast = false;

                SkillExp++;
                isToggled = true;
                MecanicsManager.instance.Player.addEffect("ModTemplateEffect");
            }
            else if (isToggled)
            {
                isToggled = false;
            }
        }

        //happens every frame the ability is toggled (variable isToggled is true)
        override public void toggleEffect()
        {

        }

        //happens every frame once the skill is obtained
        override public void passiveEffect()
        {

        }

        public override int expToLevel
        {
            get
            {
                return 4 + skillLvl * 4;
            }
        }

        //level up requirement, automatically called after incrementing exp
        override public void checkIfLevel()
        {
            if (SkillExp >= expToLevel)
            {
                skillLvl++;
                SkillExp = 0;
            }
        }
    }
}
