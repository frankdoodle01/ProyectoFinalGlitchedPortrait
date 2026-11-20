using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public float tiempoEntreSpawns = 2f;
    public float rangoX = 15f;
    public float rangoZ = 15f;
    public float alturaSpawn = 1f;

    void Start()
    {
        // Llama repetidamente a la función Generar cada X segundos
        InvokeRepeating(nameof(Generar), 1f, tiempoEntreSpawns);
    }

    void Generar()
    {
        if (prefabEnemigo == null) return;

        float randomX = Random.Range(-rangoX, rangoX);
        float randomZ = Random.Range(-rangoZ, rangoZ);
        Vector3 posicionAleatoria = new Vector3(randomX, alturaSpawn, randomZ);

        Instantiate(prefabEnemigo, posicionAleatoria, Quaternion.identity);
    }
}