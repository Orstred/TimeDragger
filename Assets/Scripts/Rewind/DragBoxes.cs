using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBoxes : MonoBehaviour
{

    public Vector3 dragcenter;
    public Vector3 boxsize;
    public GameObject VFX;

    List<GameObject> boxes;

    private void Update()
    {


        #region inputlogic
        if (Input.GetKeyDown(KeyCode.Return))
        {
           EnterDragMode();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            Collider[] hitColliders = Physics.OverlapBox(dragcenter + transform.position, boxsize, Quaternion.identity);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].tag == "Box HasWeight")
                {
                    hitColliders[i].transform.parent = transform;
                }
                i++;
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            ExitDragMode();
        }
        #endregion

    
    }



    public void EnterDragMode()
    {
        VFX.SetActive(true);
    }
    public void ExitDragMode()
    {
        BoxPickup[] lit;
        lit = GetComponentsInChildren<BoxPickup>();
        int i = 0;
        foreach(BoxPickup b in lit)
        {
            b.transform.parent = null;
        }



        VFX.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(dragcenter + transform.position, boxsize * 2);
    }
}
 
