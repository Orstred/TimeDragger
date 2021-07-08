using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPickup : Interactable
{


    public override void OnInteract()
    {
        if (InteractionManager.instance.hasbox == false)
        {
            OnInteractionDistanceEnter();
            InteractionManager.instance.hasbox = true;
            PlayerCharacter.GetComponent<PlayerCharacter>().Pickupbox(gameObject);
            GetComponent<HeldBox>().enabled = true;
            this.enabled = false;
           
        }
        else
        {
            OnInteractionDistanceExit();
        }
        base.OnInteract();
     
    }

}
