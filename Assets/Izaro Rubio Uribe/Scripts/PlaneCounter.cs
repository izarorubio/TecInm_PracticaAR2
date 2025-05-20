using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class PlaneCounter : MonoBehaviour
{
    public TMP_Text planosHorizontalesText;
    public TMP_Text planosVerticalesText;
    public Button crearGemasButton;

    private HashSet<TrackableId> horizontalesEncontrados = new HashSet<TrackableId>();
    private HashSet<TrackableId> verticalesEncontrados = new HashSet<TrackableId>();

    private ARPlaneManager planeManager;

    void Start()
    {
        crearGemasButton.interactable = false;
        planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            if (plane.alignment == PlaneAlignment.HorizontalUp && horizontalesEncontrados.Add(plane.trackableId)) { }
            else if (plane.alignment == PlaneAlignment.Vertical && verticalesEncontrados.Add(plane.trackableId)) { }
        }

        planosHorizontalesText.text = $"HORIZONTALES: {horizontalesEncontrados.Count}/{GameParameters.gemasHorizontales}";
        planosVerticalesText.text = $"VERTICALES: {verticalesEncontrados.Count}/{GameParameters.gemasVerticales}";

        if (horizontalesEncontrados.Count >= GameParameters.gemasHorizontales &&
            verticalesEncontrados.Count >= GameParameters.gemasVerticales)
        {
            crearGemasButton.interactable = true;
        }
    }

    public List<ARPlane> ObtenerPlanosHorizontales()
    {
        var planos = new List<ARPlane>();
        foreach (var p in planeManager.trackables)
        {
            if (p.alignment == PlaneAlignment.HorizontalUp)
                planos.Add(p);
        }
        return planos;
    }

    public List<ARPlane> ObtenerPlanosVerticales()
    {
        var planos = new List<ARPlane>();
        foreach (var p in planeManager.trackables)
        {
            if (p.alignment == PlaneAlignment.Vertical)
                planos.Add(p);
        }
        return planos;
    }
}
