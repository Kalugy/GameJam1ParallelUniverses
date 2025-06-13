using System;
using UnityEngine;

public class SlartLevel2 : MonoBehaviour
{
    private bool alreadystart;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!alreadystart)
            {
                BackgroundMusicController.Instance.StartLevel2Music();
                hudControlller.instance.StartLevel2Text();
                alreadystart = true;
            }
           
            
        }
    }
}
