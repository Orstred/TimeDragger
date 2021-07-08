using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public Interactable Movable;
    public bool STAYON;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag.Contains("HasWeight"))
        {


            Movable.OnInteract();
            
            
          
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.transform.tag.Contains("HasWeight") && !STAYON)
        {


            Movable.OnInteractionDistanceExit();



        }

    }

}
