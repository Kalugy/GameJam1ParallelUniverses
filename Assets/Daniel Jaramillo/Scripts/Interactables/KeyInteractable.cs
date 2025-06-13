using UnityEngine;

public class KeyInteractable : MonoBehaviour
{
    public void GetKey()
    {
        GameManagerX.Instance.haveKey = true;
        Destroy(gameObject);
    }
}
