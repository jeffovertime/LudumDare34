using UnityEngine;
using System.Collections;

public class Sniper : Enemy {

    private Vector2 targetVelocity;

    private void Start () {
        //_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        targetVelocity = (Vector2.up * Game.ascensionVelocity) - (Vector2)(transform.position - _player.transform.position).normalized * speed;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Damage(int damageDone) {
        health -= damageDone;
        if (health <= 0)
        {
            OnDeath();
        }
        else
        {
            StartCoroutine(FlashDamage());
        }
    }

    public override void OnDeath() {
        var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        explosion.transform.SetParent(Camera.main.transform);
        Destroy(gameObject);
    }

    private IEnumerator FlashDamage () {
        _renderer.color = damageColor;
        yield return new WaitForSeconds(0.25f);
        _renderer.color = Color.white;
    }

    private void Update () {
        if (Camera.main.WorldToViewportPoint(transform.position).y < -0.1)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate () {
        if (!Game.gameOver)
        {
            _rigidbody.velocity = targetVelocity;
        }
    }
}