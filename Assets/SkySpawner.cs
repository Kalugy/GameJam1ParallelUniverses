using UnityEngine;

public class SkySpawner : MonoBehaviour
{
    [Header("Prefabs a spawnear")]
    public GameObject[] prefabs;

    [Header("Cantidad de objetos a spawnear")]
    public int cantidad = 20;

    [Header("Rango de altura")]
    public float alturaMinima = 20f;
    public float alturaMaxima = 50f;

    [Header("Rango horizontal")]
    public float rangoX = 50f;
    public float rangoZ = 50f;


    void Start()
    {
        SpawnearObjetos();
    }

    void SpawnearObjetos()
    {
        for (int i = 0; i < cantidad; i++)
        {
            // Elegir prefab aleatorio
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Generar posición aleatoria en el cielo
            float x = Random.Range(-rangoX, rangoX);
            float y = Random.Range(alturaMinima, alturaMaxima);
            float z = Random.Range(-rangoZ, rangoZ);
            Vector3 posicion = new Vector3(x, y, z);

            // Instanciar el objeto
            Instantiate(prefab, posicion, Quaternion.identity);
        }
    }
}
