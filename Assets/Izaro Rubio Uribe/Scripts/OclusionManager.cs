using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OclusionManager : MonoBehaviour
{
    // Referencia al AROcclusionManager que debe estar en la MainCamera
    public AROcclusionManager occlusionManager;

    void Start()
    {
        Debug.Log("Oclusión activa: " + GameParameters.oclusion);
        Debug.Log("Modo de profundidad: " + occlusionManager.requestedEnvironmentDepthMode);

        // Comprueba si el usuario activó la oclusión en el menú
        if (GameParameters.oclusion)
        {
            // Activa el modo de profundidad (para oclusión)
            occlusionManager.requestedEnvironmentDepthMode = EnvironmentDepthMode.Medium;
        }
        else
        {
            // Desactiva la oclusión
            occlusionManager.requestedEnvironmentDepthMode = EnvironmentDepthMode.Disabled;
        }
    }
}
