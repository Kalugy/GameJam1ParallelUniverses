using System;
using UnityEngine;

public class SlartLevel2 : MonoBehaviour
{
    private bool alreadystart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!alreadystart)
            {
                BackgroundMusicController.Instance.StartLevel2Music();
                alreadystart = true;
            }
           
            
        }
    }
}
