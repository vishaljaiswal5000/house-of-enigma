using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    [SerializeField] private float rayLength = 2;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DoorController rayCastObj;

    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private GameObject playerObj;
    private Text inGameTutorial;
    private string inGameTutorialMessage;
    private void Start()
    {
        playerObj = GameObject.Find(Constants.PLAYER_OBJECT);
        inGameTutorial = GameObject.FindGameObjectWithTag(Constants.TAG_INGAME_TUTORIAL).GetComponent<Text>();
        inGameTutorial.enabled = false;
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            // Interact with door
            if (hit.collider.CompareTag(Constants.TAG_DOOR))
            {
                inGameTutorialMessage = Constants.INGAME_TUTORIAL_INTERACT;
                if (!doOnce)
                {
                    rayCastObj = hit.collider.gameObject.GetComponentInParent<DoorController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey))
                {
                    rayCastObj.interact();
                }
            }

            // Interact with exit door
            if (hit.collider.CompareTag(Constants.TAG_EXITDOOR) && GameController.exitGateOpen)
            {
                inGameTutorialMessage = Constants.INGAME_TUTORIAL_INTERACT;
                if (!doOnce)
                {
                    rayCastObj = hit.collider.gameObject.GetComponentInParent<DoorController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey))
                {
                    //rayCastObj.interact();
                    // Exit the level
                    GameController.levelCompleted = true;
                }
            }

            // Interact with Game clues
            if (hit.collider.CompareTag(Constants.TAG_GAMECLUE))
            {
                inGameTutorialMessage = Constants.INGAME_TUTORIAL_COLLECT;
                if (!doOnce)
                {
                    CrosshairChange(true);
                    OutlineChange(true, hit.collider.gameObject);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey))
                {
                    // Collect Item
                    PlayerInventory playerInventory = playerObj.GetComponent<PlayerInventory>();
                    playerInventory.ItemCollected(hit.collider.gameObject);
                    // remove item from scene
                    hit.collider.gameObject.SetActive(false);

                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    private void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            inGameTutorial.text = inGameTutorialMessage;
            inGameTutorial.enabled = true;
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
            inGameTutorial.enabled = false;
        }
    }

    private void OutlineChange(bool on, GameObject gameObject)
    {
        Outline outline = gameObject.GetComponent<Outline>();
        outline.OutlineColor = on ? Color.yellow : Color.white;
    }
}

