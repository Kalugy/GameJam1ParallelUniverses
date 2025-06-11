using UnityEngine;

public class Puzzle1Controller : MonoBehaviour
{
    private bool isActivated;
    private int currentCounter = 0;
    private int maxCounter = 4;

    public void chechNumber(int number)
    {
        if (number == currentCounter + 1 && !isActivated) 
        {
            currentCounter ++;
            Debug.Log("Vas bien");
            if (currentCounter == maxCounter)
            {
                Debug.Log("Desbloqueado");
                isActivated = true;
            }
            
        }
        else
        {
            Debug.Log("Intenta otra vez");
            currentCounter = 0;
        }
        
        
    }
}
