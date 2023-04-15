using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //private Animator doorAnim;
    //private bool doorOpen = false;
    //private void Awake()
    //{
    //    doorAnim = gameObject.GetComponent<Animator>();
    //}

    //public void PlayAnimation()
    //{
    //    if (!doorOpen)
    //    {            
    //        doorAnim.SetBool("Opened", true);
    //        doorOpen = true;
    //    }
    //    else
    //    {
    //        doorAnim.SetBool("Opened", false);
    //        doorOpen = false;
    //    }
    //}


    public Animator openandclose;
    public bool open;
    public Transform Player;

    void Start()
    {
        open = false;
    }

    public void interact()
    {
        if (open == false)
        {
            StartCoroutine(opening());

        }
        else
        {
            if (open == true)
            {

                StartCoroutine(closing());
            }

        }

    }



    IEnumerator opening()
    {
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }

}
