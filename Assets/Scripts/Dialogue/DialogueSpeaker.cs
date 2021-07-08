using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : Interactable
{


    DialogueManager speachmanager;
    int CurrentPage = 2;

   [HideInInspector]
    public MainDialogue DialogueFile;

    public string CharacterName;



    public override void OnInteractionDistanceEnter()
    {
        base.OnInteractionDistanceEnter();

        speachmanager = DialogueManager.instance;
        DialogueFile = DialogueManager.instance.DialogueFile;
    }

    public override void OnInteract()
    {
        base.OnInteract();
  

        //Resizes the notification box
       // DialogueManager.instance.SetUpDialogueBox();

        if (CurrentPage < DialogueFile.Sheet1.Count)
        {
            StopAllCoroutines();
            StartCoroutine(speachmanager.SayNextLine(CharacterSelect()[CurrentPage].RouteA));
            CurrentPage++;
        }


    }

public  List<DialogueTree> CharacterSelect()
    {
        if(CharacterName == "Sheet1")
        {
            return DialogueFile.Sheet1;
        }
        if (CharacterName == "Sheet2")
        {
            return DialogueFile.Sheet2;
        }
        if (CharacterName == "Sheet3")
        {
            return DialogueFile.Sheet3;
        }
        if (CharacterName == "Sheet4")
        {
            return DialogueFile.Sheet4;
        }
        if (CharacterName == "Sheet5")
        {
            return DialogueFile.Sheet5;
        }
        if (CharacterName == "Sheet6")
        {
            return DialogueFile.Sheet6;
        }
        if (CharacterName == "Sheet7")
        {
            return DialogueFile.Sheet7;
        }
        if (CharacterName == "Sheet8")
        {
            return DialogueFile.Sheet8;
        }
        if (CharacterName == "Sheet9")
        {
            return DialogueFile.Sheet9;
        }
        if (CharacterName == "Sheet10")
        {
            return DialogueFile.Sheet10;
        }
        if (CharacterName == "Sheet11")
        {
            return DialogueFile.Sheet11;
        }
        if (CharacterName == "Sheet12")
        {
            return DialogueFile.Sheet12;
        }
        if (CharacterName == "Sheet13")
        {
            return DialogueFile.Sheet13;
        }
        if (CharacterName == "Sheet14")
        {
            return DialogueFile.Sheet14;
        }
        if (CharacterName == "Sheet15")
        {
            return DialogueFile.Sheet15;
        }
        if (CharacterName == "Sheet16")
        {
            return DialogueFile.Sheet16;
        }
        if (CharacterName == "Sheet17")
        {
            return DialogueFile.Sheet17;
        }
        if (CharacterName == "Sheet18")
        {
            return DialogueFile.Sheet18;
        }
        if (CharacterName == "Sheet19")
        {
            return DialogueFile.Sheet19;
        }
        if (CharacterName == "Sheet20")
        {
            return DialogueFile.Sheet20;
        }
        if (CharacterName == "Sheet21")
        {
            return DialogueFile.Sheet21;
        }
        if (CharacterName == "Sheet22")
        {
            return DialogueFile.Sheet22;
        }
        if (CharacterName == "Sheet23")
        {
            return DialogueFile.Sheet23;
        }
        if (CharacterName == "Sheet24")
        {
            return DialogueFile.Sheet24;
        }
        if (CharacterName == "Sheet25")
        {
            return DialogueFile.Sheet25;
        }
        if (CharacterName == "Sheet26")
        {
            return DialogueFile.Sheet26;
        }
        if (CharacterName == "Sheet27")
        {
            return DialogueFile.Sheet27;
        }
        if (CharacterName == "Sheet28")
        {
            return DialogueFile.Sheet28;
        }
        if (CharacterName == "Sheet29")
        {
            return DialogueFile.Sheet29;
        }
        if (CharacterName == "Sheet30")
        {
            return DialogueFile.Sheet30;
        }
        return null;
    }



    public override void OnInteractionDistanceExit()
    {
        base.OnInteractionDistanceExit();
        //DialogueManager.instance.SetUpNotificationBox();
      
        CurrentPage = 2;
    }

}
