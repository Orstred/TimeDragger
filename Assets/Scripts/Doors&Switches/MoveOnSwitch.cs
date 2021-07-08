using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnSwitch : Interactable
{
    public float MovementSpeed = 1;
    public Vector3 MoveTo;
    Vector3 startpos;

    private void Awake()
    {
        startpos = transform.position;
    }

    public override void OnInteract()
    {

  
            transform.localPosition = Vector3.Lerp(transform.localPosition, MoveTo, Time.deltaTime * MovementSpeed);
     
            
    }
    public override void OnInteractionDistanceExit()
    {
        base.OnInteractionDistanceExit();
        transform.localPosition = startpos;

    }
    private void OnDrawGizmosSelected() 
    {
        if(MoveTo == new Vector3(0, 0, 0))
        {
            MoveTo = transform.position;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.localPosition, MoveTo);
       Gizmos.DrawWireCube(MoveTo, Vector3.Scale(transform.GetComponent<MeshFilter>().sharedMesh.bounds.size, transform.localScale));
     
    }
}
