using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class FinalPortal : MonoBehaviour
{
    public GameObject finalText;
    public GameObject backGround;
    public Volume volume;
    private Vignette vignette;

    private void Start()
    {
        if (volume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = 0.5f;
        }
    }

    public void FinalScene()
    {
        StartCoroutine(FinalCountDown(0.5f, 1f));
    }

    IEnumerator FinalCountDown(float from, float to)
    {
        float elapse = 0f;

        while (elapse < 3)
        {
            elapse += Time.deltaTime;
            float t = elapse / 3;

            vignette.intensity.value = Mathf.Lerp(from, to, t);
            yield return null;
        }

        vignette.intensity.value = to;
        SceneManager.LoadScene("Game/StartedScene");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Palyer"))
        {
            finalText.SetActive(true);
            backGround.SetActive(true);
        }
    }
}
