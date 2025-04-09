using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source -----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("---------- Audio Clips -----------")]
    public AudioClip background;


    public static AudioManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
}
