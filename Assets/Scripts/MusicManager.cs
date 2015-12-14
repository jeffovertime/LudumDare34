using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource _audio;

    void Start () {
        _audio = GetComponent<AudioSource>();
    }

    void Update() {
        if (!_audio.isPlaying)
        {
            _audio.Play();
        }
    }
}