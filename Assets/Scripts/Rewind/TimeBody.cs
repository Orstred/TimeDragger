using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    public bool isRewinding = false;
    CharacterController cr;
    PlayerCharacter pc;
    public List<PointInTime> PointsInTime;

    public float RecordTime;

    void Start()
    {
        cr = GetComponent<CharacterController>();
        pc = GetComponent<PlayerCharacter>();
        PointsInTime = new List<PointInTime>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }



    private void FixedUpdate()
    {
        if (isRewinding)
        {
           Rewind();
        }
        else
        {
            Record();
        }
    }





    public void Record()
    {
        if(PointsInTime.Count > Mathf.Round(RecordTime / Time.fixedDeltaTime))
        {
            PointsInTime.RemoveAt(PointsInTime.Count - 1);
        }
        PointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }
    public void Rewind()
    {
    if(PointsInTime.Count > 0)
        {
            PointInTime pointintime = PointsInTime[0];
            transform.position = pointintime.position;
            transform.rotation = pointintime.rotation;
            PointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }
    public void StartRewind()
    {
        cr.enabled = false;
        pc.enabled = false;
        isRewinding = true;
    }
    public void StopRewind()
    {
        cr.enabled = true;
        pc.enabled = true;
        isRewinding = false;
}
}
