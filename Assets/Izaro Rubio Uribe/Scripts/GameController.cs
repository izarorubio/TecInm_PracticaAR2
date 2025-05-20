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

    public AudioSource audioSource;     
    public AudioClip contrarelojClip;

    private bool juegoActivo = false;

    void Start()
    {
        panelInicial.SetActive(true); // panel incial activado
        panelContadores.SetActive(false); // oculta el panel al iniciar
    }

    void Update()
    {
        if (!juegoActivo) return;

        // Resta tiempo al cronómetro
        tiempoRestante -= Time.deltaTime;
        tiempoTexto.text = "TIEMPO: " + Mathf.CeilToInt(tiempoRestante).ToString();

        if (tiempoRestante <= 0)
        {
            FinDelJuego(false);  // pierde si se acaba el tiempo sin recoger todas
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

        // Reproducir audio contrareloj
        if (audioSource != null && contrarelojClip != null)
        {
            audioSource.clip = contrarelojClip;
            audioSource.Play();
        }

    }

    public void RecogerGema(GameObject gema)
    {
        // Reproducir el sonido de recogida si existe
        AudioSource audio = gema.GetComponent<AudioSource>();
        if (audio != null && audio.clip != null)
        {
            audio.Play();
            Destroy(gema, audio.clip.length); // espera a que termine el sonido y destruye la gema
        }
        else
        {
            Destroy(gema);
        }

        gemasRecogidas++;
        ActualizarContador();

        if (gemasRecogidas >= totalGemas)
        {
            FinDelJuego(true);  // gana si recoge todas las gemas antes del tiempo
        }
    }

    void ActualizarContador()
    {
        gemasTexto.text = $"GEMAS RECOGIDAS: {gemasRecogidas}/{totalGemas}";
    }

    void FinDelJuego(bool win)
    {
        juegoActivo = false;

        // Detener el audio si está sonando
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Muestra mensaje final dependiendo si se gana o no
        if (win)
        {
            tiempoTexto.text = "Fin del juego. ¡Has ganado!";
        }
        else
        {
            tiempoTexto.text = "Se acabó el tiempo. Has perdido.";
        }
    }
}
