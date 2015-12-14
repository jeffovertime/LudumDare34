using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float fallingSpeed;
    public GameObject explosionPrefab;
    public int health;
    public Color damageColor;

    private Vector2 velocity;
    private Rigidbody2D _rigidbody;
    private Rigidbody2D player;
    private SpriteRenderer _renderer;
    
    public void Damage (int damageDone) {
        health -= damageDone;
        if (health <= 0)
        {
            Explode();
        }
        else
        {
            StartCoroutine(FlashDamage());
        }
    }

    IEnumerator FlashDamage () {
        _renderer.color = damageColor;
        yield return new WaitForSeconds(0.25f);
        _renderer.color = Color.white;
    }

    void Start () {
        _renderer = GetComponent<SpriteRenderer>();
        if (health == 0)
            health = 10;
        velocity = Vector2.zero;
        velocity.y = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y - fallingSpeed;
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update () {
        transform.Rotate(new Vector3(0, 0, 0.5f));
    }

    void FixedUpdate () {
        if (player != null)
        {
            Vector3 velocity = player.velocity;
            velocity.y -= fallingSpeed;
            if (Mathf.Abs(player.position.x - transform.position.x) > 0.5f)
                velocity.x = (player.transform.position.x > transform.position.x ? 1 : -1) * (30 / transform.localScale.x);
            else
                velocity.x = 0;
            _rigidbody.velocity = velocity;
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, -100, 0);
        }
    }

    public void Explode () {
        var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        explosion.transform.SetParent(Camera.main.transform);
        Destroy(gameObject);
    }
}