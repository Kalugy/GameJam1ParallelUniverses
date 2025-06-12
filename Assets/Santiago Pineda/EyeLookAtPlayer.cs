using UnityEngine;

public class EyeLookAtPlayer : MonoBehaviour
{
    public Transform player; // arrastra aquí al jugador desde el editor

    void Update()
    {
        if (player != null)
        {
            // Rota el ojo para mirar al jugador sin moverse
            Vector3 direction = player.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }
}
