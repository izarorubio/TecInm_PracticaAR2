using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    public TMP_Text tiempoTexto;
    public TMP_Text gemasTexto;
    public GameObject panelContadores;
    public GameObject panelInicial;

    private int gemasRecogidas = 0;
    private int totalGemas;
    private float tiempoRestante;

    private bool juegoActivo = false;
    void Start()
    {
        panelInicial.SetActive(true);
        panelContadores.SetActive(false); // <--- esto oculta el panel al iniciar
    }

    void Update()
    {
        if (!juegoActivo) return;

        tiempoRestante -= Time.deltaTime;
        tiempoTexto.text = "Tiempo restante: " + Mathf.CeilToInt(tiempoRestante).ToString();

        if (tiempoRestante <= 0)
        {
            FinDelJuego();
        }
    }


    public void EmpezarJuego(int tiempo)
    {
        tiempoRestante = tiempo;
        totalGemas = GameParameters.gemasHorizontales + GameParameters.gemasVerticales;
        gemasRecogidas = 0;
        ActualizarContador();
        juegoActivo = true;
        panelInicial.SetActive(false);
        panelContadores.SetActive(true);
    }

    public void RecogerGema(GameObject gema)
    {
        AudioSource audio = gema.GetComponent<AudioSource>();
        if (audio != null && audio.clip != null)
        {
            audio.Play();
            Destroy(gema, audio.clip.length); // espera a que termine el sonido
        }
        else
        {
            Destroy(gema);
        }

        gemasRecogidas++;
        ActualizarContador();

        if (gemasRecogidas >= totalGemas)
        {
            FinDelJuego();
        }
    }

    void ActualizarContador()
    {
        gemasTexto.text = $"Gemas recogidas: {gemasRecogidas}/{totalGemas}";
    }

    void FinDelJuego()
    {
        juegoActivo = false;
        tiempoTexto.text = "¡Fin del juego!";
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }
}
