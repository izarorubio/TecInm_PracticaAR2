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

        if (win)
        {
            tiempoTexto.text = "Fin del juego. ¡Has ganado!";
        }
        else
        {
            tiempoTexto.text = "Se acabó el tiempo. Has perdido.";
        }
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }
}
