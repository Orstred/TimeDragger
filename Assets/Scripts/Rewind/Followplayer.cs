using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{


    Transform player;
    private void Start()
    {
        player = EventManager.instance.PlayerCharacter.transform;
    }
    void LateUpdate()
    {
        transform.position = player.position;
    }
}
