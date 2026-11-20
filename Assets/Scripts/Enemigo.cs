using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 4f;
    public float tiempoEntreAtaques = 1.5f; // Segundos de espera entre golpes
    private float siguienteAtaque = 0f;
    private Transform objetivo;

    void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            objetivo = jugador.transform;
        }
    }

    void Update()
    {
        if (objetivo != null)
        {
            Vector3 posicionObjetivo = new Vector3(objetivo.position.x, transform.position.y, objetivo.position.z);
            transform.LookAt(posicionObjetivo);
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }

    // Se ejecuta si los colliders chocan físicamente
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IntentarAtacar();
        }
    }

    // Se ejecuta si alguno de los colliders tiene marcado "Is Trigger"
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IntentarAtacar();
        }
    }

    void IntentarAtacar()
    {
        if (Time.time >= siguienteAtaque)
        {
            siguienteAtaque = Time.time + tiempoEntreAtaques;

            if (GameManager.instancia != null)
            {
                GameManager.instancia.QuitarVida(1);
            }
        }
    }
}