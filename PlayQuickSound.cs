using UnityEngine;

public class PlayQuickSound : MonoBehaviour
{
    [SerializeField] private AudioClip sound = null;
    [SerializeField] private float volume = 1.0f;
    [Range(0, 1)] [SerializeField] private float randomPitchVariance = 0.0f;

    private AudioSource audioSource = null;

    private float defaultPitch = 1.0f;

    private void Awake()
    {
        // Audiosource wird zugewiesen
        audioSource = GetComponent<AudioSource>();
    }

    //Funktion zum abspielen
    public void Play()
    {
        // zufalls wert würfelm
        float randomVariance = Random.Range(-randomPitchVariance, randomPitchVariance);
        randomVariance += defaultPitch;
        // Zufallswert pitch zuweißen
        audioSource.pitch = randomVariance;
        // Sound Spielen
        audioSource.PlayOneShot(sound, volume);
        // pitch wieder auf anfangwert setzten
        audioSource.pitch = defaultPitch;
    }

    // Funktions um das Script neu zu laden wenn was im inspector geändert wurde
    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
}
