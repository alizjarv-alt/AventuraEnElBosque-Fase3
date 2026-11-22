
using UnityEngine;
using System.Collections;

public class AnimalPatrulla : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaRecorrido = 3f;
    public float tiempoEspera = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 puntoInicial;
    private int direccion = 1;
    private bool esperando = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        puntoInicial = rb.position;

        StartCoroutine(Patrullar());
    }

    void FixedUpdate()
    {
        if (rb == null || esperando) return;

        rb.velocity = new Vector2(direccion * velocidad, 0);
    }

    IEnumerator Patrullar()
    {
        while (true)
        {
            esperando = true;
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(tiempoEspera);

            esperando = false;
            direccion = 1;
            if (sprite != null) sprite.flipX = false;

            while (rb.position.x < puntoInicial.x + distanciaRecorrido)
                yield return null;

            esperando = true;
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(tiempoEspera);

            esperando = false;
            direccion = -1;
            if (sprite != null) sprite.flipX = true;

            while (rb.position.x > puntoInicial.x)
                yield return null;
        }
    }
}
