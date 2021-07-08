using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionManager : MonoBehaviour
{
  #region Singleton
    public static InteractionManager instance;
    private void Awake()
    {
        
            instance = this;
         if(GameObject.FindObjectOfType<InteractionManager>() != this)
        {
            Debug.LogWarning("More than one InteractionManager in scene");
            
        }
    }
    #endregion


    

    //Interact text bubble parent
    public Image InteractionBubble;

  //  public Animator DisplayTextAnimator;
    [HideInInspector]
    public Text DialogueBox;
    //Object currently interacting with player
    [HideInInspector]   
    public GameObject currentinteraction;
    [HideInInspector]
    public bool hasbox = false;
    private void Start()
    {
       
   
        DialogueBox = InteractionBubble.GetComponentInChildren<Text>();
    }

  


    public void AddDisplayInteracttext(string Newtext)
    {
        InteractionBubble.gameObject.SetActive(true);
        DialogueBox.text = Newtext;
    }

    public void ResizeTextBox(Vector2 newsize)
    {
        RectTransform Textbox;
        Textbox = InteractionBubble.GetComponent<RectTransform>();

        Textbox.sizeDelta = newsize;
    }
    
}
