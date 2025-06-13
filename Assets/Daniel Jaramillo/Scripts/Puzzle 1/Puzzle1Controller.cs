using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Puzzle1Controller : MonoBehaviour
{
    private bool isActivated;
    private int currentCounter = 0;
    private int maxCounter = 4;

    [Header("PostProcecing")]
    
    public Color correctColor;
    public Color wrongColor;
    public Color defaultColor;
    public Volume globalVolume;
    private Bloom bloom;

    [Header("Audios")] 
    public AudioClip goodButton;
    public AudioClip wrongButton;
    public AudioClip openPortal;
    private AudioSource audioSource;  

    [SerializeField] private GameObject portal;

    private void Start()
    {
        if (globalVolume.profile.TryGet(out bloom))
        {
            bloom.tint.overrideState = true;
            defaultColor = bloom.tint.value;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void chechNumber(int number)
    {
        if (number == currentCounter + 1 && !isActivated) 
        {
            currentCounter ++;
            StartCoroutine("CorrectColor");
            if (currentCounter == maxCounter)
            {
                Debug.Log("Desbloqueado");
                portal.SetActive(true);
                isActivated = true;
            }
            
        }
        else
        {
            StartCoroutine("WrongColor");
            currentCounter = 0;
        }
    }

    IEnumerator CorrectColor()
    {
        audioSource.clip = goodButton;
        audioSource.Play();
        bloom.tint.value = correctColor;
        yield return new WaitForSeconds(1);
        bloom.tint.value = defaultColor;
    }

    IEnumerator WrongColor()
    {
        audioSource.clip = wrongButton;
        audioSource.Play();
        bloom.tint.value = wrongColor;
        yield return new WaitForSeconds(1);
        bloom.tint.value = defaultColor;
    }
    
}
