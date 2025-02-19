using UnityEngine;

public class AmbientAudioPlayer : MonoBehaviour
{
    private static AmbientAudioPlayer _instance = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private AmbientAudioPlayer() { }

    public void FadeMusic(AudioClip clip)
    {
        //TODO
    }
}
