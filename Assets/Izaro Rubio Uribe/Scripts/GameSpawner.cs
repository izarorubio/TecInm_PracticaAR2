using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GemaSpawner : MonoBehaviour
{
    public GameObject gemaHorizontalPrefab;
    public GameObject gemaVerticalPrefab;
    public GameController gameController;

    private PlaneCounter planeCounter;

    void Start()
    {
        planeCounter = FindObjectOfType<PlaneCounter>();
    }

    public void CrearGemas()
    {
        // Obtener los planos detectados
        List<ARPlane> horizontales = planeCounter.ObtenerPlanosHorizontales();
        List<ARPlane> verticales = planeCounter.ObtenerPlanosVerticales();

        // Instanciar las gemas horizontales sobre los planos horizontales
        for (int i = 0; i < GameParameters.gemasHorizontales && i < horizontales.Count; i++)
        {
            Vector3 pos = horizontales[i].transform.position + Vector3.up * 0.05f;
            GameObject gema = Instantiate(gemaHorizontalPrefab, pos, Quaternion.identity);
            gema.tag = "Gema";
        }

        // Instanciar las gemas verticales con rotación
        for (int i = 0; i < GameParameters.gemasVerticales && i < verticales.Count; i++)
        {
            Vector3 pos = verticales[i].transform.position + Vector3.forward * 0.05f;
            Quaternion rotacionVertical = Quaternion.Euler(0, 0, 90);
            GameObject gema = Instantiate(gemaVerticalPrefab, pos, rotacionVertical);
            gema.tag = "Gema";
        }

        // Inicia el juego
        gameController.EmpezarJuego(GameParameters.tiempo);
    }
}
