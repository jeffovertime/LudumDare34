using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    private AudioSource _audio;

    void Awake () {
        _audio = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Damage(1);
        }
    }

    void OnEnable () {
        StartCoroutine("PewPew");
    }

    IEnumerator PewPew () {
        while (this.enabled)
        {
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
            yield return null;
        }
    }
}