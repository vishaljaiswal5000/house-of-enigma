using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource footstepsSound;
    [SerializeField] private AudioSource sprintSound;
    [SerializeField] private AudioSource collectSound;

    public static bool isItemCollected = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }


        if (isItemCollected)
        {

            collectSound.PlayOneShot(collectSound.clip);
            isItemCollected = false;
        }
    }
}