using UnityEngine;
using System.Collections;

public class Sniper : Enemy2 {

    //private Vector3 targetDirection;

    private void Start () {
        _renderer = GetComponent<SpriteRenderer>();
        health = 5;
        //targetVelocity.y = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y - fallingSpeed;
        _rigidbody = GetComponent<Rigidbody2D>();
        //targetDirection = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
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

    private void FixedUpdate () {
        if (!Game.gameOver)
        {

        }
    }
}