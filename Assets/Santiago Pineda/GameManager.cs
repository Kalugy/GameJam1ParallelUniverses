using System.Collections;
using UnityEngine;


[System.Serializable]
public class Sector
{
    public GameObject lightObject;
    public GameObject floorObject;
}


public class GameManager : MonoBehaviour
{
    public Sector[] sectors; // 4 sectores

    void Start()
    {
        foreach (Sector sector in sectors)
        {
            StartCoroutine(ControlSector(sector));
        }
    }

    IEnumerator ControlSector(Sector sector)
    {
        while (true)
        {
            bool isOn = Random.value > 0.5f;

            sector.lightObject.SetActive(isOn);
            sector.floorObject.SetActive(isOn); // Si la luz se apaga, el piso desaparece

            yield return new WaitForSeconds(Random.Range(1.5f, 3f));
        }
    }
}
