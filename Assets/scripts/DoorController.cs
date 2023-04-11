using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;
    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {            
            doorAnim.SetBool("Opened", true);
            doorOpen = true;
        }
        else
        {
            doorAnim.SetBool("Opened", false);
            doorOpen = false;
        }
    }
}
