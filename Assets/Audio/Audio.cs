using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource musica;

    void Start()
    {
        musica = GetComponent<AudioSource>();
        if (musica != null)
        {
            musica.Play();
        }
    }
}
