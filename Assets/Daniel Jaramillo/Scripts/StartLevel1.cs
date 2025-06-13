using UnityEngine;

public class StartLevel1 : MonoBehaviour
{
    private bool alreadystart;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!alreadystart)
            {
                hudControlller.instance.StartLevel1Text();
                alreadystart = true;
            }
           
            
        }
    }
}
