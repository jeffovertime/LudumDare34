using UnityEngine;
using UnityEngine.UI;

public class PlayerVelocity : MonoBehaviour {

    public Rigidbody2D player;

    private Text _text;

    void Start () {
        _text = GetComponent<Text>();
    }

    void Update () {
        _text.text = "Velocity: " + player.velocity.magnitude;
    }
}