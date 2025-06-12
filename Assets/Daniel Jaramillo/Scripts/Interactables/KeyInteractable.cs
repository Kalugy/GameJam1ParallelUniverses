using UnityEngine;

public class KeyInteractable : MonoBehaviour
{
    public void GetKey()
    {
        GameManager.Instance.haveKey = true;
        Destroy(gameObject);
    }
}
