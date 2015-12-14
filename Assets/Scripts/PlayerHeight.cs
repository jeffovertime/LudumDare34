using UnityEngine;
using UnityEngine.UI;

public class PlayerHeight : MonoBehaviour {

    private Transform player;
    private Text _text;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _text = GetComponent<Text>();
    }

    void Update () {
        if (player != null)
        {
            _text.text = "Elevation: " + player.position.y.ToString("#") + "m";
        }
    }
}