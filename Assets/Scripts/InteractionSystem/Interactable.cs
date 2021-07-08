using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //Dictates at what range can the player interact with the object.
    public float Range;
    //The center from which the distance from the player is calculated.
    public Transform InteractionRoot;
    //The text that shows up on the notification box when in range.
    public string Interactiontext;
    [HideInInspector]
    public GameObject PlayerCharacter;
    InteractionManager interactioncontrol;
    bool hasEnteredInteractionDistance;

    public void Start()
    {
        PlayerCharacter = EventManager.instance.PlayerCharacter;
        interactioncontrol = InteractionManager.instance;


        //Sets up a default interaction text
            if(Interactiontext.Length == 0)
            Interactiontext = "Press \"F\" to interact whit " + transform.name;
     
    }

    private void Update()
    {


        if (DistancefromPlayer() <= Range)
        {
            if (interactioncontrol.currentinteraction == null)
            {
                if (!hasEnteredInteractionDistance)
                {

                    OnInteractionDistanceEnter();
                }
            }
            else if(hasEnteredInteractionDistance)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
              
                    OnInteract();
                }
            }
            
        }
        else if (hasEnteredInteractionDistance)
        {
            OnInteractionDistanceExit();
        }
    }




        
    //Called when the player is within interaction distance and presses F    
    public virtual void OnInteract()
    {
       

        Debug.Log("Interacted whit " + transform.name);
    }
    //This is called when the player leaves interaction range and lowers the notification box by default.
    public virtual void OnInteractionDistanceExit()
    {
        hasEnteredInteractionDistance = false;
        Debug.Log(transform.name + " Out of Range");
        interactioncontrol.InteractionBubble.gameObject.SetActive(false);
        interactioncontrol.currentinteraction = null;
    }
   //This is called when the player is within interaction range and setup the notification box by default.
    public virtual void OnInteractionDistanceEnter()
    {
        interactioncontrol.currentinteraction = gameObject;
        //On interaction distance enter
        Debug.Log(transform.name + " Interactiondistance");
        hasEnteredInteractionDistance = true;
        interactioncontrol.AddDisplayInteracttext(Interactiontext);
    }



    private void OnDrawGizmosSelected()
    {
        if (InteractionRoot == null)
            InteractionRoot = this.transform;


        //Draws a yellow WireSphere from the center of the InteractionRoot Transform
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionRoot.position, Range);

      
    }
    //Returns a float representing the distance between this object and the player.
    public float DistancefromPlayer()
    {
        float Dist;
        if (EventManager.instance.PlayerCharacter != null)
        {
            Dist = Vector3.Distance(transform.position, EventManager.instance.PlayerCharacter.transform.position);
            return Dist;
        }
        return 0f;
    }
}
