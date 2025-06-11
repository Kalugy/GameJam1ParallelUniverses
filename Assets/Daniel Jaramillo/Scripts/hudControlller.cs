using System;
using TMPro;
using UnityEngine;

public class hudControlller : MonoBehaviour
{
    public static hudControlller instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TMP_Text interactionText;

    public void EnableInteraction(string text)
    {
        interactionText.text = text + " (E)";
        interactionText.gameObject.SetActive(true);

    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
   
}
