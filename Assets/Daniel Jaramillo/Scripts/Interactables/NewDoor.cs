using System;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    public bool isOpen = false;
    private Animator animator;
    private AudioSource audioSource;
    private Interactable interactableScript;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        interactableScript = GetComponent<Interactable>();

    }

    private void Update()
    {
        if (!GameManagerX.Instance.haveKey)
        {
            interactableScript.message = "Is blocked, you will need the key";
        }
        else if (!isOpen) interactableScript.message = "Press to open";
        else interactableScript.message = "Press to close";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InteracDoor()
    {

        if (GameManagerX.Instance.haveKey)
        {
            if (!isOpen)
            {
                audioSource.Play();
                animator.SetTrigger("Open");
                isOpen = true;
            }
            else
            {
                audioSource.Play();
                animator.SetTrigger("Close");
                isOpen = false;
            }
        }
        
        
        
    }
}
