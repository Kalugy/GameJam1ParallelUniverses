using UnityEngine;

public class Puzzle3Manager : MonoBehaviour
{
    public static Puzzle3Manager instance;
    private void Awake()
    {
        instance = this;
    }
    private bool isActivated;
    private int currentCounter = 0;
    private int maxCounter = 4;
    public GameObject exitPortal;

    public void TakeItem()
    {
        currentCounter++;
        if(currentCounter== 4) exitPortal.SetActive(true);
    }
    
   
}
