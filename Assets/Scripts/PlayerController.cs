using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static int health = 3;
    
    public float speed = 20.0f;
    public float rotationSpeed = 2.0f;
    public float maxRotation = 45.0f;
    public GameObject rocketSparks;

    private Rigidbody2D _rigidbody;
    private bool moveLeft;
    private bool moveRight;
    private GameObject laser;
    private bool launched;

    void Awake () {
        Game.ascensionVelocity = speed;
    }

    void Start() {
        launched = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        laser = transform.FindChild("Laser").gameObject;
    }

    public void Launch () {
        rocketSparks.SetActive(true);
        launched = true;
    }

    void Update() {
        moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    }

    void FixedUpdate() {
        if (launched)
        {
            float screenX = Camera.main.WorldToViewportPoint(transform.position).x;
            if (moveLeft && moveRight)
            {
                laser.SetActive(true);
            }
            else if (moveLeft || moveRight)
            {
                laser.SetActive(false);
                if (screenX > 0.05f && moveLeft)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 30), Time.deltaTime * rotationSpeed);
                }
                else if (screenX < 0.95 && moveRight)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -30), Time.deltaTime * rotationSpeed);
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed * 2f);
                }
            }
            else
            {
                laser.SetActive(false);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed * 0.75f);
            }

            _rigidbody.velocity = transform.up * speed;
            if (screenX < 0.01f && _rigidbody.velocity.x < 0 || screenX > 0.99f && _rigidbody.velocity.x > 0)
            {
                Vector2 velocity = _rigidbody.velocity;
                velocity.x = 0.0f;
                _rigidbody.velocity = velocity;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed * 2f);
            }
        }
    }
}