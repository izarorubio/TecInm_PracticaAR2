using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SliderController : MonoBehaviour
{
    public Slider tiempoSlider;
    public Slider gemasHorizontalesSlider;
    public Slider gemasVerticalesSlider;
    public TMP_Text tiempoText;
    public TMP_Text gemasHorizontalesText;
    public TMP_Text gemasVerticalesText;
    public Toggle oclusionToggle;

    void Start()
    {
        // Inicializa los textos
        tiempoText.text = tiempoSlider.value.ToString("0");
        gemasHorizontalesText.text = gemasHorizontalesSlider.value.ToString("0");
        gemasVerticalesText.text = gemasVerticalesSlider.value.ToString("0");

        // A�adir listeners a los sliders
        tiempoSlider.onValueChanged.AddListener(UpdateTiempo);
        gemasHorizontalesSlider.onValueChanged.AddListener(UpdateGemasHorizontales);
        gemasVerticalesSlider.onValueChanged.AddListener(UpdateGemasVerticales);
    }

    void UpdateTiempo(float value)
    {
        tiempoText.text = value.ToString("0");
    }

    void UpdateGemasHorizontales(float value)
    {
        gemasHorizontalesText.text = value.ToString("0");
    }

    void UpdateGemasVerticales(float value)
    {
        gemasVerticalesText.text = value.ToString("0");
    }

    public void OnStartButtonPressed()
    {
        // Guardar par�metros
        GameParameters.tiempo = (int)tiempoSlider.value;
        GameParameters.gemasHorizontales = (int)gemasHorizontalesSlider.value;
        GameParameters.gemasVerticales = (int)gemasVerticalesSlider.value;
        GameParameters.oclusion = oclusionToggle.isOn;

        // Cargar la escena del juego
        SceneManager.LoadScene(1);
    }
}
