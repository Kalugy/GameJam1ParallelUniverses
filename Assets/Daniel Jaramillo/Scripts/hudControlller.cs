using System;
using TMPro;
using UnityEngine;

public class hudControlller : MonoBehaviour
{
    public static hudControlller instance;
    public GameObject background;
    public GameObject[] dialogues;
    public bool isUiOpen;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TMP_Text interactionText;

    public void EnableInteraction(string text)
    {
        interactionText.text = text;
        interactionText.gameObject.SetActive(true);

    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    public void CloseBackground()
    {
        background.SetActive(false);
    }

    public void StartLevel1Text()
    {
        dialogues[0].SetActive(true);
        background.SetActive(true);
    }

    public void StartLevel2Text()
    {
        dialogues[1].SetActive(true);
        background.SetActive(true);
    }
    public void StartLevel3Text()
    {
        dialogues[2].SetActive(true);
        background.SetActive(true);
    }
   
}
