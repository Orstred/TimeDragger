using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{

    #region Singleton
    public static DialogueManager instance;
    public void Awake()
    {
        instance = this;
    }
    #endregion



     Vector2 DialogueBoxSize = new Vector2(535.1477f, 143.0132f);
     Vector2 NotificationBoxSize = new Vector2(266.9126f, 88.687f);



    //The textbox parent
    [HideInInspector]
    public Transform TextBoxBounds;
    //Text box that shows the dialogue and notifications
    [HideInInspector]
    public Text DialogueBox;
    //Manages all interactions
    InteractionManager Interactionmanager;

   public  MainDialogue DialogueFile;

    public void Start()
    {
        Interactionmanager = InteractionManager.instance;
        DialogueBox = InteractionManager.instance.InteractionBubble.GetComponentInChildren<Text>();
        TextBoxBounds = InteractionManager.instance.InteractionBubble.transform;
    }


    public  IEnumerator SayNextLine(string Page)
    {

        DialogueBox.text = "";

        foreach (char letter in Page.ToCharArray())
        {
            DialogueBox.text += letter;
            yield return new WaitForSeconds (0.01f);

        }
    }
    public void SetUpDialogueBox()
    {
        Interactionmanager.ResizeTextBox(DialogueBoxSize);
        DialogueBox.alignment = TextAnchor.UpperLeft;
        DialogueBox.fontSize = 60;
    }
    public void SetUpNotificationBox()
    {
        Interactionmanager.ResizeTextBox(NotificationBoxSize);
        DialogueBox.alignment = TextAnchor.MiddleCenter;
        DialogueBox.fontSize = 40;
    }
}
