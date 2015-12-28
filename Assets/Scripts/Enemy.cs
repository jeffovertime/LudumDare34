using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public GameObject explosionPrefab;
    public Color damageColor;
    public float speed = 15.0f;

    protected int health;

    protected Rigidbody2D _player;
    protected Rigidbody2D _rigidbody;
    protected SpriteRenderer _renderer;

    public abstract void Damage(int damageDone);

    public abstract void OnDeath();
}