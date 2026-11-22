
using UnityEngine;

public class RecolectarResiduo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("El residuo detectó: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Residuo recolectado!");
            Destroy(gameObject);
        }
    }
}


