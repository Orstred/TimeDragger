using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Transform player;
    public Vector3 offset;
    public float CameraSmooth;
    // Start is called before the first frame update
    void Start()
    {
        player = EventManager.instance.PlayerCharacter.transform;
      
    }

    private void Update()
    {
        transform.LookAt(player);
    }
    // Update is called once per frame
    void LateUpdate()
    {
      
        transform.position =  Vector3.Lerp(transform.position,   player.transform.position - offset, Time.deltaTime * CameraSmooth);
    }
}
