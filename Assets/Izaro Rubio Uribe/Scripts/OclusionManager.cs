using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OclusionManager : MonoBehaviour
{
    // Referencia al AROcclusionManager que debe estar en la MainCamera
    public AROcclusionManager occlusionManager;

    void Start()
    {
        Debug.Log("Oclusi�n activa: " + GameParameters.oclusion);
        Debug.Log("Modo de profundidad: " + occlusionManager.requestedEnvironmentDepthMode);

        // Comprueba si el usuario activ� la oclusi�n en el men�
        if (GameParameters.oclusion)
        {
            // Activa el modo de profundidad (para oclusi�n)
            occlusionManager.requestedEnvironmentDepthMode = EnvironmentDepthMode.Medium;
        }
        else
        {
            // Desactiva la oclusi�n
            occlusionManager.requestedEnvironmentDepthMode = EnvironmentDepthMode.Disabled;
        }
    }
}
