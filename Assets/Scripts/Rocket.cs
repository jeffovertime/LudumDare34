using UnityEngine;

public class Rocket : MonoBehaviour {

    public CameraController cam;
    public static int health;
    public RocketEmoji face;
    public GameObject explosionPrefab;
    public MoonEmoji moonFace;
    public HealthDisplay healthDisplay;
    public GameObject heightDisplay;
    public GameObject HP;
    private AudioSource _audio;

    void Start () {
        _audio = GetComponent<AudioSource>();
        health = 3;
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            health--;
            other.GetComponent<Enemy>().OnDeath();
            if (_audio.isPlaying)
            {
                _audio.Stop();
            }

            _audio.Play();
            face.ShowHurtEmoji();
            healthDisplay.RemoveHealth();
            other.GetComponent<Enemy>().Damage(100);
            if (health == 0)
            {
                OnDeath();
            }
        }
        else if (other.CompareTag("Moon"))
        {
            HitTheMoon();

        }
    }

    void HitTheMoon () {
        moonFace.AngryMoon();
        GameObject.Find("Managers/GameManager").GetComponent<GameManager>().Win();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }

    void OnDeath() {
        heightDisplay.SetActive(false);
        HP.SetActive(false);
        foreach (GameObject starSystem in GameObject.FindGameObjectsWithTag("StarSystem"))
        {
            var starController = starSystem.GetComponent<StarField>();
            starController.SpeedUp();
        }
        GameObject.Find("Managers/GameManager").GetComponent<GameManager>().Lose(transform.position.y);
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Enemy>().Damage(100);
        }
        cam.GoToTheMoon();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}