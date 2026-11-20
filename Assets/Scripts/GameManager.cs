using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Necesario si quieres reiniciar la escena

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("Interfaz (Canvas)")]
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoVidas;
    public GameObject panelGameOver; // Opcional: panel de derrota

    [Header("Estadísticas")]
    public int vidasMaximas = 3;
    private int vidasActuales;
    private int enemigosEliminados = 0;

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        vidasActuales = vidasMaximas;
        if (panelGameOver != null) panelGameOver.SetActive(false);
        ActualizarUI();
    }

    public void SumarPunto()
    {
        enemigosEliminados++;
        ActualizarUI();
    }

    public void QuitarVida(int cantidad)
    {
        vidasActuales -= cantidad;
        if (vidasActuales < 0) vidasActuales = 0;

        ActualizarUI();

        if (vidasActuales <= 0)
        {
            GameOver();
        }
    }

    void ActualizarUI()
    {
        if (textoContador != null)
            textoContador.text = "Enemigos: " + enemigosEliminados;

        if (textoVidas != null)
            textoVidas.text = "Vidas: " + vidasActuales + " / " + vidasMaximas;
    }

    void GameOver()
    {
        Debug.Log("¡Juego Terminado!");
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
        }
        else
        {
            // Si no tienes panel, reinicia la escena automáticamente
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}