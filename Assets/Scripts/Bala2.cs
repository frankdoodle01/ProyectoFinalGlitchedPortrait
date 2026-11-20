using UnityEngine;

public class Bala2 : MonoBehaviour
{
    public float velocidad = 32f;

    void Start()
    {
        // Destruye la bala automáticamente después de 3 segundos si no choca con nada
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        float distanciaAvance = velocidad * Time.deltaTime;
        Debug.DrawRay(transform.position, transform.forward * distanciaAvance, Color.red);

        RaycastHit hit;
        // Detecta colisiones en la trayectoria de este frame
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaAvance + 0.5f))
        {
            if (hit.collider.CompareTag("Enemigo"))
            {
                // Sumar al contador del Canvas
                if (GameManager.instancia != null)
                {
                    GameManager.instancia.SumarPunto();
                }

                // Destruir al enemigo
                Destroy(hit.collider.gameObject);
            }

            // Destruir la bala al impactar cualquier objeto
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * distanciaAvance);
    }
}