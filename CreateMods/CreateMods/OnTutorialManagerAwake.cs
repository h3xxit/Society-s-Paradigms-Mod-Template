using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RenameNamespace
{
    public class OnTutorialManagerAwake
    {
        public static void OnStart(string pathToModFolder, Dictionary<string, Sprite> loadedSprites)
        {
            Debug.Log("Template mod loaded something in TutorialManager awake");
            MecanicsManager.instance.tutorialSteps.Add(
                new CutsceneDialogSteps(
                    "Name of speaker",
                    "Text",
                    //when this returns true tutorial continues to next Dialog
                    () => Mouse.current.press.wasPressedThisFrame,
                    //this is called when after the above function returns true
                    () => Debug.Log("Dialog step completed")
                )
            );
        }
    }
}
