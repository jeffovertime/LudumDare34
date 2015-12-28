using UnityEngine;
using System.Collections;

public abstract class Enemy2 : MonoBehaviour {

    public float fallingSpeed;
    public GameObject explosionPrefab;
    public Color damageColor;

    protected int health;

    protected Vector2 targetVelocity;
    protected Rigidbody2D _rigidbody;
    protected SpriteRenderer _renderer;

    public abstract void Damage(int damageDone);

    public abstract void OnDeath();
}