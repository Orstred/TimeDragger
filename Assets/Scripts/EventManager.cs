using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Singleton
    public static EventManager instance;
    private void Awake()
    {

        if  (EventManager.instance == null)
        {
            instance = this;
        }      
        else
        {
            Destroy(this);
        }
    }
    #endregion


    //General
    public GameObject MainCamera;
    public GameObject PlayerCharacter;


        

}
