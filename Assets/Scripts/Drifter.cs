using UnityEngine;
using System.Collections;

public class Drifter : Enemy {

    public float swingDistance = 5.0f;
    public float swingSpeed = 5.0f;

    //private float center;
    private bool facingRight;
    private bool shouldFlip;
    private float fallSpeed;

    private void Start() {
        //center = transform.position.x;
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        fallSpeed = Game.ascensionVelocity - speed;
        _rigidbody.velocity = new Vector2(swingSpeed, fallSpeed);
        InvokeRepeating("Flip", 1.0f, 1.0f);
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

    private IEnumerator FlashDamage() {
        _renderer.color = damageColor;
        yield return new WaitForSeconds(0.25f);
        _renderer.color = Color.white;
    }

    private void Update() {
        if (Camera.main.WorldToViewportPoint(transform.position).y < -0.5 || Game.gameOver)
        {
            OnDeath();
        }
    }

    private void FixedUpdate () {
        if (!shouldFlip)
        {
            _rigidbody.velocity = new Vector2(Mathf.Lerp(_rigidbody.velocity.x, 0.0f, Time.deltaTime), fallSpeed);
        }
        else
        {
            _rigidbody.velocity = new Vector2(facingRight ? swingSpeed : -swingSpeed, fallSpeed);
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            shouldFlip = false;
        }

    }

    private void Flip () {
        shouldFlip = true;
    }
}