using UnityEngine;

public class GemaTouch : MonoBehaviour
{
    public AudioClip sonidoRecoger; // Sonido a reproducir al recoger
    private GameController gameController;
    private AudioSource audioSource;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        // A�ade un AudioSource al objeto si no lo tiene
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = sonidoRecoger;
    }

    // Detectar colisiones con el trigger de la c�mara
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (audioSource.clip != null)
            {
                audioSource.Play();
            }

            // Llamar al GameController para aumentar el conteo
            if (gameController != null)
            {
                gameController.RecogerGema(gameObject);
            }
        }
    }
}

