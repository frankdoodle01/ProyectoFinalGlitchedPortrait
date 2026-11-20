using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    // Posición recomendada para vista isométrica/cenital (arriba y atrás)
    public Vector3 offset = new Vector3(0f, 15f, -10f);
    public float suavizado = 10f;
    public bool mirarAlJugador = true;

    void LateUpdate()
    {
        if (jugador == null) return;

        // Calcular la posición deseada
        Vector3 posicionDeseada = jugador.position + offset;

        // Mover la cámara suavemente hacia esa posición
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);

        // Hacer que la cámara siempre apunte al jugador
        if (mirarAlJugador)
        {
            transform.LookAt(jugador);
        }
    }
}