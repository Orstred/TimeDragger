using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldBox : MonoBehaviour
{


    InteractionManager interactioncontrol;
    public float dropdistance;
    
    // Start is called before the first frame update
    void Start()
    {
        interactioncontrol = InteractionManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(interactioncontrol.hasbox == true && Input.GetKeyDown(KeyCode.F))
        {
            transform.position = transform.parent.localPosition;
            transform.localPosition = Vector3.forward     * dropdistance;
            transform.parent = null;
            interactioncontrol.hasbox = false;
            GetComponent<BoxPickup>().enabled = true;
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            GetComponent<Rigidbody>().isKinematic = false;
            this.enabled = false;
        }
    }
}
