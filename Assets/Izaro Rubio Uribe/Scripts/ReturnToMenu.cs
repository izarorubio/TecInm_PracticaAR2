using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void OnReturnButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
