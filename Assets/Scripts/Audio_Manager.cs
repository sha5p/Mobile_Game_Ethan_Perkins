using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] public AudioClip Swip_Sound;
    [SerializeField] public AudioClip RopeAttachSound;
    [SerializeField] public AudioClip ClickSound;
    [SerializeField] public AudioClip music;
    [SerializeField] public AudioClip death;
    [SerializeField] public AudioClip coin;

    [Header("Audio Source")]
    [SerializeField] private AudioSource SFX_source;
    [SerializeField] private AudioSource musicSource;

    public static Audio_Manager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX_source.PlayOneShot(clip);
    }
}
