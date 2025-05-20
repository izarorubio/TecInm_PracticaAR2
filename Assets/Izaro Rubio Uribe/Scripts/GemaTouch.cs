using UnityEngine;

public class GemaTouch : MonoBehaviour
{
    public AudioClip sonidoRecoger; // Puedes asignar el sonido desde el inspector
    private GameController gameController;
    private AudioSource audioSource;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        // Asegura que el objeto tenga un AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = sonidoRecoger;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Necesitas asignar este tag a la cámara
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

