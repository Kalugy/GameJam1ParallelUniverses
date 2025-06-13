using UnityEngine;

public class StartLevel3 : MonoBehaviour
{
    private bool alreadystart;
    public AudioSource[] audioTips;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!alreadystart)
            {
                BackgroundMusicController.Instance.StartLevel3Music();
                hudControlller.instance.StartLevel3Text();
                alreadystart = true;

                foreach (var VARIABLE in audioTips)
                {
                    AudioSource audioSource = VARIABLE.GetComponent<AudioSource>();
                    audioSource.Play();
                }
            }
           
            
        }
    }
}
