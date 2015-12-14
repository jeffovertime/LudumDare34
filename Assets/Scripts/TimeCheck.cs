using UnityEngine;
using UnityEngine.UI;

public class TimeCheck : MonoBehaviour {
    private Text _text;

    void Start () {
        _text = GetComponent<Text>();
    }

    void Update () {
        _text.text = "Time: " + Time.time.ToString("#.#");
    }
}