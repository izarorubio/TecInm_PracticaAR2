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
        // Inicializar los textos
        tiempoText.text = tiempoSlider.value.ToString("0");
        gemasHorizontalesText.text = gemasHorizontalesSlider.value.ToString("0");
        gemasVerticalesText.text = gemasVerticalesSlider.value.ToString("0");

        // Añadir listeners a los sliders para actualizar los textos al cambiar
        tiempoSlider.onValueChanged.AddListener(UpdateTiempo);
        gemasHorizontalesSlider.onValueChanged.AddListener(UpdateGemasHorizontales);
        gemasVerticalesSlider.onValueChanged.AddListener(UpdateGemasVerticales);
    }

    // Actualizar el texto del tiempo cuando cambia el slide
    void UpdateTiempo(float value)
    {
        tiempoText.text = value.ToString("0");
    }

    // Actualizar el texto de gemas horizontales
    void UpdateGemasHorizontales(float value)
    {
        gemasHorizontalesText.text = value.ToString("0");
    }

    // Actualizar el texto de gemas horizontales
    void UpdateGemasVerticales(float value)
    {
        gemasVerticalesText.text = value.ToString("0");
    }

    // Al pulsar el botón "Comenzar"...
    public void OnStartButtonPressed()
    {
        // Guardar parámetros en la clase GameParameters
        GameParameters.tiempo = (int)tiempoSlider.value;
        GameParameters.gemasHorizontales = (int)gemasHorizontalesSlider.value;
        GameParameters.gemasVerticales = (int)gemasVerticalesSlider.value;
        GameParameters.oclusion = oclusionToggle.isOn;

        // Cargar Scene1
        SceneManager.LoadScene(1);
    }
}
